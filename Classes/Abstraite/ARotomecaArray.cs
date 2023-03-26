using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes.Abstraite
{
  public abstract class ARotomecaArray<typeOfArray, typeOfItem> : RotomecaObject, Interfaces.IRotomecaArray<typeOfItem>
  {
    protected typeOfArray _array;
    private RotomecaNumber _size;
    public ARotomecaArray()
    {
      _array = _InitArray();
      _size = _InitMaxLength();
    }

    public ARotomecaArray(IEnumerable<typeOfItem> items)
    {
      _array = _InitArray(items);
      _size = _InitMaxLength();
    }

    protected abstract typeOfArray _InitArray();
    protected abstract typeOfArray _InitArray(IEnumerable<typeOfItem> items);
    protected abstract RotomecaNumber _InitMaxLength();

    protected abstract typeOfItem _Get(RotomecaNumber index);
    protected abstract void _Set(RotomecaNumber index, typeOfItem item);
    protected abstract RotomecaNumber _Length();

    public typeOfItem this[RotomecaNumber index] { get => _Get(index); set => _Set(index, value); }

    public RotomecaNumber Length => _Length();

    public RotomecaNumber MaxLength => _size;

    public abstract void Add(object item);

    public abstract void Clear();

    public abstract bool Contains(typeOfItem item);

    public abstract RotomecaNumber IndexOf(typeOfItem item);

    public abstract typeOfItem Remove(RotomecaNumber index, typeOfItem defaultItem);

    public abstract void Set(RotomecaNumber index, typeOfItem item);

    public abstract typeOfItem[] ToArray();

    public abstract List<typeOfItem> ToList();

    protected abstract IEnumerator<typeOfItem> _GetEnumerator();

    public IEnumerator<typeOfItem> GetEnumerator()
    {
      return _GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _GetEnumerator();
    }
  }
}
