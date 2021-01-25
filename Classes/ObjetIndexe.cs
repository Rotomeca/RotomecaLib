using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes
{
  public abstract class ObjetIndexe
  {
    public uint Index { get; set; }
    
    public ObjetIndexe(uint index)
    {
      Index = index;
    }

    public ObjetIndexe(int index)
    {
      Index = (uint)index;
    }

    public abstract object GetObject();

    public Tuple<uint, object> EnTuple()
    {
      return new Tuple<uint, object>(Index, GetObject());
    }

    public (uint index, object objet) EnValueTuple()
    {
      return (Index, GetObject());
    }

    public static ObjetIndexe DepuisTuple(Tuple<uint, object> tuple)
    {
      return new ObjetIndexeIndefini(tuple.Item1, tuple.Item2);
    }

    public static ObjetIndexe DepuisTuple(Tuple<int, object> tuple)
    {
      return new ObjetIndexeIndefini(tuple.Item1, tuple.Item2);
    }

    public static ObjetIndexe<T> DepuisTuple<T>(Tuple<uint, T> tuple)
    {
      return new ObjetIndexe<T>(tuple.Item1, tuple.Item2);
    }

    public static ObjetIndexe<T> DepuisTuple<T>(Tuple<int, T> tuple)
    {
      return new ObjetIndexe<T>(tuple.Item1, tuple.Item2);
    }

    public static ObjetIndexe DepuisValueTuple((uint, object) tuple)
    {
      return new ObjetIndexeIndefini(tuple.Item1, tuple.Item2);
    }

    public static ObjetIndexe DepuisValueTuple((int, object) tuple)
    {
      return new ObjetIndexeIndefini(tuple.Item1, tuple.Item2);
    }

    public static ObjetIndexe<T> DepuisValueTuple<T>((uint, T) tuple)
    {
      return new ObjetIndexe<T>(tuple.Item1, tuple.Item2);
    }

    public static ObjetIndexe<T> DepuisValueTuple<T>((int, T) tuple)
    {
      return new ObjetIndexe<T>(tuple.Item1, tuple.Item2);
    }
  }

  public class ObjetIndexe<TObjet> : ObjetIndexe
  {
    public TObjet Objet { get; set; }
    public ObjetIndexe(uint index, TObjet objet) : base(index)
    {
      Objet = objet;
    }

    public ObjetIndexe(int index, TObjet objet) : base(index)
    {
      Objet = objet;
    }

    public override object GetObject()
    {
      return Objet;
    }
  }

  public sealed class ObjetIndexeIndefini : ObjetIndexe<object>
  {
    public ObjetIndexeIndefini(uint index, object item) : base(index, item) { }

    public ObjetIndexeIndefini(int index, object item) : base(index, item) { }

  }
}
