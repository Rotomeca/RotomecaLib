using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public class RotomecaList<T> : Classes.Abstraite.ARotomecaList<List<T>, T>
  {
    public RotomecaList() : base() { }

    public RotomecaList(IEnumerable<T> values) : base(values) { }

    public override void Add(T item)
    {
      _array.Add(item);
    }

    public override void Add(object item)
    {
      _array.Add((T)item);
    }

    public override void Clear()
    {
      _array.Clear();
    }

    public override bool Contains(T item)
    {
      return _array.Contains(item);
    }

    public override RotomecaNumber IndexOf(T item)
    {
      return _array.IndexOf(item);
    }

    public override void Insert(RotomecaNumber index, T item)
    {
      _array.Insert(index.ToInt32(null), item);
    }

    public override bool Remove(T item)
    {
      return _array.Remove(item);
    }

    public override T Remove(RotomecaNumber index, T defaultItem)
    {
      var tmp = this[index];
      this[index] = defaultItem;
      return tmp;
    }

    public override void RemoveAt(RotomecaNumber index)
    {
      _array.RemoveAt(index.ToInt32(null));
    }

    public override void Set(RotomecaNumber index, T item)
    {
      _Set(index, item);
    }

    public override T[] ToArray()
    {
      return _array.ToArray();
    }

    public override List<T> ToList()
    {
      return new List<T>(_array);
    }

    protected override void _CopyTo(T[] array, RotomecaNumber arrayIndex)
    {
      _array.CopyTo(array, arrayIndex.ToInt32(null));
    }

    protected override T _Get(RotomecaNumber index)
    {
      return _array[index.ToInt32(null)];
    }

    protected override IEnumerator<T> _GetEnumerator()
    {
      return _array.GetEnumerator();
    }

    protected override List<T> _InitArray()
    {
      return new List<T>();
    }

    protected override List<T> _InitArray(IEnumerable<T> items)
    {
      return new List<T>(items);
    }

    protected override RotomecaNumber _Length()
    {
      return _array.Count;
    }

    protected override void _Set(RotomecaNumber index, T item)
    {
      _array[index.ToInt32(null)] = item;
    }
  }
}
