using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Classes
{
  public class Encyclopedie<TCle, TValeur> : RotomecaObject, IDictionary<TCle, TValeur>
  {
    ConcurrentDictionary<TCle, TValeur> _datas;
    IDictionary<TCle, TValeur> _interfaceDatas => _datas;

    public Encyclopedie() { _datas = new ConcurrentDictionary<TCle, TValeur>(); }

    public Encyclopedie(IDictionary<TCle, TValeur> datas)
    {
      _datas = new ConcurrentDictionary<TCle, TValeur>(datas);
    }

    public Encyclopedie(IDictionary<TCle, TValeur> datas, params (TCle cle, TValeur valeur)[] datasToAdd)
    {
      _datas = new ConcurrentDictionary<TCle, TValeur>(datas);
      if (datasToAdd.Length > 0)
      {
        foreach (var item in datasToAdd)
        {
          this[item.cle] = item.valeur;
        }
      }
    }

    public Encyclopedie(IDictionary<TCle, TValeur> datas, params KeyValuePair<TCle, TValeur>[] datasToAdd)
    {
      _datas = new ConcurrentDictionary<TCle, TValeur>(datas);
      if (datasToAdd.Length > 0)
      {
        foreach (var item in datasToAdd)
        {
          this[item.Key] = item.Value;
        }
      }
    }

    public TValeur this[TCle key] { get => ContainsKey(key) ? _datas[key] : default;
      set {
        if (ContainsKey(key))
          _datas[key] = value;
        else
          Add(key, value);
      } }

    public ICollection<TCle> Keys => _datas.Keys;

    public ICollection<TValeur> Values => _datas.Values;

    public int Count => _datas.Count;

    public bool IsReadOnly => _interfaceDatas.IsReadOnly;

    public void Add(TCle key, TValeur value)
    {
      _datas.TryAdd(key, value);
    }

    public void Add(KeyValuePair<TCle, TValeur> item)
    {
      ((IDictionary<TCle, TValeur>)_datas).Add(item);
    }

    public void Clear()
    {
      _datas.Clear();
    }

    public bool Contains(KeyValuePair<TCle, TValeur> item)
    {
      return _datas.Contains(item);
    }

    public bool ContainsKey(TCle key)
    {
      return _datas.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<TCle, TValeur>[] array, int arrayIndex)
    {
      _interfaceDatas.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<TCle, TValeur>> GetEnumerator()
    {
      return _datas.GetEnumerator();
    }

    public bool Remove(TCle key)
    {
      return _datas.TryRemove(key, out _);
    }

    public bool Remove(KeyValuePair<TCle, TValeur> item)
    {
      return _interfaceDatas.Remove(item);
    }

    public bool TryGetValue(TCle key, out TValeur value)
    {
      return _datas.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _datas.GetEnumerator();
    }
  }
}

namespace RotomecaLib.Classes.Extentions
{
  public class EncyclopedieException<TCle, TValeur> : Exception
  {
    public Encyclopedie<TCle, TValeur> ObjetErreur {get; private set;}
    public object[] Informations { get; private set; }

    public EncyclopedieException(Encyclopedie<TCle, TValeur> objetErreur, string message, params object[] infos) : base(message)
    {
      ObjetErreur = objetErreur;
      Informations = infos;
    }

  }
}

namespace System.Linq
{
  public static class RotomecaLib_Extention_Encyclopedie
  {
    public static RotomecaLib.Classes.Encyclopedie<TCle, TValeur> ToEncyclopedie<TOriginal,TCle, TValeur>(this IEnumerable<TOriginal> originals, RotomecaLib.Delegates.EnCleEncyclopedie<TOriginal,TCle> selectionneurDeCle, RotomecaLib.Delegates.EnValueEncyclopedie<TOriginal, TValeur> selectionneurDeValeur, bool errorOnDouble = true)
    {
      return _ToEncyclopedie(originals, (item) => selectionneurDeCle(item), (item) => selectionneurDeValeur(item), errorOnDouble);
    }

    private static RotomecaLib.Classes.Encyclopedie<TCle, TValeur> _ToEncyclopedie<TOriginal, TCle, TValeur>(this IEnumerable<TOriginal> originals, Func<TOriginal, TCle> selectionneurDeCle, Func<TOriginal, TValeur> selectionneurDeValeur, bool errorOnDouble = true)
    {
      if (originals.Any())
      {
        if (errorOnDouble)
        {
          try
          {
            return new RotomecaLib.Classes.Encyclopedie<TCle, TValeur>(originals.ToDictionary(selectionneurDeCle, selectionneurDeValeur));
          }
          catch (Exception e)
          {

            throw new RotomecaLib.Classes.Extentions.EncyclopedieException<TCle, TValeur>(null, e.Message, originals, selectionneurDeCle, selectionneurDeValeur);
          }
        }
        else
        {
          RotomecaLib.Classes.Encyclopedie<TCle, TValeur> retour = new RotomecaLib.Classes.Encyclopedie<TCle, TValeur>();
          Parallel.ForEach(originals, (item) =>
          {
            retour[selectionneurDeCle(item)] = selectionneurDeValeur(item);
          });
          return retour;
        }
      }
      return new RotomecaLib.Classes.Encyclopedie<TCle, TValeur>();
    }
  }
}
