using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes.Abstraite
{
  public abstract class ARotomecaList<typeOfArray, typeOfItem> : ARotomecaArray<typeOfArray, typeOfItem>, Interfaces.IRotomecaList<typeOfItem>
  {
    public ARotomecaList() : base() { }

    public ARotomecaList(IEnumerable<typeOfItem> values) : base(values) { }
    protected override RotomecaNumber _InitMaxLength()
    {
      return null;
    }

    public RotomecaNumber Count => Length;

    public bool IsReadOnly => false;

    int ICollection<typeOfItem>.Count => Length.ToInt32(null);

    public abstract void Add(typeOfItem item);

    protected abstract void _CopyTo(typeOfItem[] array, RotomecaNumber arrayIndex);

    public void CopyTo(typeOfItem[] array, RotomecaNumber arrayIndex)
    {
      _CopyTo(array, arrayIndex);
    }

    public void CopyTo(typeOfItem[] array, int arrayIndex)
    {
      _CopyTo(array, arrayIndex);
    }

    public abstract void Insert(RotomecaNumber index, typeOfItem item);

    public abstract bool Remove(typeOfItem item);

    public abstract void RemoveAt(RotomecaNumber index);
  }
}