using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RotomecaLib.Interfaces;

namespace RotomecaLib.Classes.Abstraite
{
  public abstract class ADoubleDictionnaire<TCle1, TCle2, TValeur> : RotomecaObject, IDoubleDictionnaire<TCle1, TCle2, TValeur>
  {
    IDictionary<(TCle1, TCle2), TValeur> _datas;

    public ADoubleDictionnaire(IDoubleDictionnaire<TCle1, TCle2, TValeur> dictionary)
    {
      _datas = dictionary;
    }

    public ADoubleDictionnaire(IDictionary<(TCle1, TCle2), TValeur> dictionary)
    {
      _datas = dictionary;
    }

    public TValeur this[(TCle1, TCle2) key] { get => _datas[key]; set => _datas[key] = value; }
    public TValeur this[TCle1 key1, TCle2 key2] { get => this[(key1, key2)]; set => _datas[(key1, key2)] = value; }

    public ICollection<(TCle1, TCle2)> Keys => _datas.Keys;

    public ICollection<TValeur> Values => _datas.Values;

    public int Count => _datas.Count;

    public bool IsReadOnly => false;

    public void Add((TCle1, TCle2) key, TValeur value)
    {
      _datas.Add(key, value);
    }

    public void Add(KeyValuePair<(TCle1, TCle2), TValeur> item)
    {
      AddOrUpdate(item.Key.Item1, item.Key.Item2, item.Value);
    }

    public void Add(TCle1 key1, TCle2 key2, TValeur value)
    {
      Add((key1, key2), value);
    }

    public void AddOrUpdate(TCle1 key1, TCle2 key2, TValeur value)
    {
      if (ContainsKey(key1, key2))
        this[key1, key2] = value;
      else
        Add(key1, key2, value);
    }

    public void Clear()
    {
      _datas.Clear();
    }

    public bool Contains(KeyValuePair<(TCle1, TCle2), TValeur> item)
    {
      return _datas.Contains(item);
    }

    public bool ContainsKey((TCle1, TCle2) key)
    {
      return _datas.ContainsKey(key);
    }

    public bool ContainsKey(TCle1 key1, TCle2 key2)
    {
      return ContainsKey((key1, key2));
    }

    public void CopyTo(KeyValuePair<(TCle1, TCle2), TValeur>[] array, int arrayIndex)
    {
      _datas.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<(TCle1, TCle2), TValeur>> GetEnumerator()
    {
      return _datas.GetEnumerator();
    }

    public bool Remove((TCle1, TCle2) key)
    {
      return _datas.Remove(key);
    }

    public bool Remove(KeyValuePair<(TCle1, TCle2), TValeur> item)
    {
      return _datas.Remove(item);
    }

    public bool Remove(TCle1 key1, TCle2 key2)
    {
      return Remove((key1, key2));
    }

    public bool TryGetValue((TCle1, TCle2) key, out TValeur value)
    {
      return _datas.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _datas.GetEnumerator();
    }
  }
}
