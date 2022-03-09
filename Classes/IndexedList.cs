using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RotomecaLib
{
  public class IndexedList<T> : RotomecaObject, IList<ObjetIndexe<T>>
  {
    List<ObjetIndexe<T>> _datas;

    public IndexedList()
    {
      _datas = new List<ObjetIndexe<T>>();
    }

    public IndexedList(IEnumerable<ObjetIndexe<T>> datas)
    {
      _datas = new List<ObjetIndexe<T>>(datas);
    }

    public ObjetIndexe<T> this[int index] { get => _datas[index]; set => _datas[index] = value; }
    public T this[uint index] { get => _datas[(int)index].Objet; set => _datas[(int)index].Objet = value; }

    public int Count => _datas.Count;

    public bool IsReadOnly => false;

    protected void ReloadIndexes()
    {
      for (int i = 0; i < Count; ++i)
        _datas[i].Index = (uint)i;
    }

    public void Add(ObjetIndexe<T> item)
    {
      _datas.Add(item);
      ReloadIndexes();
    }

    public void Add(T item)
    {
      _datas.Add(new ObjetIndexe<T>(Count, item));
    }

    public void Clear()
    {
      _datas.Clear();
    }

    public bool Contains(ObjetIndexe<T> item)
    {
      return _datas.Contains(item);
    }

    public bool Contains(T item)
    {
      return _datas.Any(x => x.Objet.Equals(item));
    }

    public bool ContainsIndex(int index)
    {
      return Count > index;
    }

    public bool ContainsIndex(uint index)
    {
      return Count > index;
    }

    public void CopyTo(ObjetIndexe<T>[] array, int arrayIndex)
    {
      _datas.CopyTo(array, arrayIndex);
    }

    public IEnumerator<ObjetIndexe<T>> GetEnumerator()
    {
      return _datas.GetEnumerator();
    }

    public int IndexOf(ObjetIndexe<T> item)
    {
      return _datas.IndexOf(item);
    }

    public void Insert(int index, ObjetIndexe<T> item)
    {
      _datas.Insert(index, item);
      ReloadIndexes();
    }

    public bool Remove(ObjetIndexe<T> item)
    {
      var tmp = _datas.Remove(item);
      ReloadIndexes();
      return tmp;
    }

    public void RemoveAt(int index)
    {
      _datas.RemoveAt(index);
      ReloadIndexes();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _datas.GetEnumerator();
    }
  }
}
