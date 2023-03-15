using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Interfaces
{
  /// <summary>
  /// Interface de base pour un tableau de la classe RotomecaLib
  /// </summary>
  public interface IRotomecaArray
  {
    /// <summary>
    /// Taille effective du tableau (pas de valeurs par défaut)
    /// </summary>
    uint Length { get; }
    /// <summary>
    /// Taille du tableau
    /// </summary>
    uint MaxLength { get; }
    /// <summary>
    /// Vide le tableau
    /// </summary>
    void Clear();
  
    //void Move(uint index1, uint index2);
    //void Move(int index1, int index2);
  }

  public interface IRotomecaArray<T> : IEnumerable<T>, IRotomecaArray
  {
    T this[int index] {get; set;}
    void Set(int index, T item);
    T Remove(int index, T defaultItem);
    bool Contains(T item);
    int IndexOf(T item);
    T[] ToArray();
    List<T> ToList(); 
  }
}
