using System;
using System.Collections.Generic;
using System.Text;
using RotomecaLib;
using RotomecaLib.Interfaces;

namespace RotomecaLib.Interfaces
{
  public interface IRotomecaArray : System.Collections.IEnumerable
  {
    /// <summary>
    /// Taille effective du tableau (pas de valeurs par défaut)
    /// </summary>
    RotomecaNumber Length { get; }
    /// <summary>
    /// Taille du tableau
    /// </summary>
    RotomecaNumber MaxLength { get; }
    void Add(object item);
    /// <summary>
    /// Vide le tableau
    /// </summary>
    void Clear();
  }

  public interface IRotomecaArray<T> : IEnumerable<T>, IRotomecaArray
  {
    T this[RotomecaNumber index] { get; set; }
    void Set(RotomecaNumber index, T item);
    T Remove(RotomecaNumber index, T defaultItem);
    bool Contains(T item);
    RotomecaNumber IndexOf(T item);
    T[] ToArray();
    List<T> ToList();
  }

  public interface IRotomecaList<T> : IRotomecaArray<T>, ICollection<T>
  {
    new RotomecaNumber Count { get; }
    void Insert(RotomecaNumber index, T item);
    void RemoveAt(RotomecaNumber index);
    void CopyTo(T[] array, RotomecaNumber arrayIndex);
  }
}

namespace Linq
{
  public static class StRotomecaArray
  {

    public static IEnumerable<object> ToEnumerable(this IRotomecaArray values)
    {
      foreach (var item in values)
      {
        yield return item;
      }
    }

    public static IRotomecaList<object> ToRotomecaList<T>(this IRotomecaArray values)
    {
      return new RotomecaList<object>(values.ToEnumerable());
    }

    public static IRotomecaList<T> ToRotomecaList<T>(this IEnumerable<T> values)
    {
      return new RotomecaList<T>(values);
    }
  }
}