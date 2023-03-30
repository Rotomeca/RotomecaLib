using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  /// <summary>
  /// Interface d'un nombre
  /// </summary>
  public interface INumber : IConvertible
  {
    /// <summary>
    /// Valeur de la classe
    /// </summary>
    dynamic Value { get; set; }
    /// <summary>
    /// Additionne la valeur à la classe
    /// </summary>
    /// <param name="value">Value à ajouter</param>
    void Add(INumber value);
    /// <summary>
    /// Multiplie la valeur à la classe
    /// </summary>
    /// <param name="value">Valeur à multiplier</param>
    void Multiply(INumber value);
    /// <summary>
    /// Divise la classe par la valeur
    /// </summary>
    /// <param name="value"></param>
    void Divide(INumber value);
    /// <summary>
    /// Additionne négativement la valeur à la classe
    /// </summary>
    /// <param name="value">Value à retirer</param>
    void Remove(INumber value);
    /// <summary>
    /// Remet la classe à zéro
    /// </summary>
    void Reset();
    /// <summary>
    /// Vérifie si la classe est égale à une valeur. 
    /// </summary>
    /// <typeparam name="T"><see cref="INumber"/> ou nombre/flottant</typeparam>
    /// <param name="value">Valeur à comparer</param>
    /// <returns></returns>
    bool IsEqualTo<T>(T value);
  }
}
