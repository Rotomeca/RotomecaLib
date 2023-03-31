using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  /// <summary>
  /// Représente un nombre. Essaye de prendre le moins de place en mémoire.
  /// <para>La classe peut être instantié de cette façon : </para>
  /// <code>
  /// RotomecaNumber monnombre = 5;
  /// RotomecaNumber monnombrefloat = 5.0f;
  /// </code>
  /// En revanche, pour récupérer la valeur, il vaut mieux passer par un convertisseur, ex : 
  ///  <code>
  /// RotomecaNumber monnombre = 5;
  /// RotomecaNumber monnombrefloat = 5.0f;
  /// int extraction = (int)monnombre;
  /// float extraction_float = (float)monnombrefloat;
  /// </code>
  /// Les différents types de calculs sont disponible : 
  /// <code>
  /// RotomecaNumber monnombre = 5;
  /// RotomecaNumber monnombrefloat = 5.0f;
  /// RotomecaNumber result = monnombre + monnombrefloat - 5 + 1.25f;
  /// </code>
  /// Voir les fonctions : 
  /// <br/>
  /// <see cref="Add(INumber)"/>
  /// <br/>
  /// <seealso cref="Multiply(INumber)"/>
  /// <br/>
  /// <seealso cref="Divide(INumber)"/>
  /// <br/>
  /// <seealso cref="Remove(INumber)"/>
  /// <para>
  /// il est aussi possible d'utiliser les opérateurs conditionnels entre nombre ou INumber.
  /// </para>
  /// 
  /// <para>Attention ! <see cref="decimal"/> n'est pas compatible avec cette classe !</para>
  /// </summary>
  public sealed class RotomecaNumber : ARotomecaNumber, IEquatable<RotomecaNumber>
  {
    #region Interne à la classe
    /// <summary>
    /// Liste les différents types de calcules disponibles
    /// </summary>
    enum Calculcate
    {
      /// <summary>
      /// Représente une addition
      /// </summary>
      plus,
      /// <summary>
      /// Représente une soustraction
      /// </summary>
      moins,
      /// <summary>
      /// Représente une multiplication
      /// </summary>
      fois, 
      /// <summary>
      /// Représente une division
      /// </summary>
      diviser
    }
    #endregion

    /// <summary>
    /// Valeur de la classe
    /// </summary>
    private dynamic _number;

    /// <summary>
    /// Instantie un nombre.
    /// </summary>
    /// <param name="number">Nombre ou INumber</param>
    public RotomecaNumber(dynamic number)
    {
      _number = _Set(number);
    }

    /// <summary>
    /// Prend la bonne classe si le nombre est un flotant, un entier ou un <see cref="INumber"/>
    /// </summary>
    /// <param name="number">Flotant, un entier ou un <see cref="INumber"/></param>
    /// <returns><see cref="RNumberFloat"/> ou <see cref="RWholeNumber"/></returns>
    private dynamic _Set(dynamic number)
    {
      dynamic _number;
      if (number is float || number is double)
      {
        _number = new RNumberFloat(number);
      }
      else if (number is INumber)
      {
        _number = _Set(number.Value);
      }
      else
      {
        _number = new RWholeNumber(number);
      }

      return _number;
    }

    /// <summary>
    /// Valeur de la classe 
    /// </summary>
    public override dynamic Value
    {
      get { return _number.Value; }
      set { _number = new RotomecaNumber(value)._number; }
    }

    #region Modificateurs
    /// <summary>
    /// Additionne à <paramref name="value"/>
    /// </summary>
    /// <param name="value">Valeur qui sera ajouté</param>
    public override void Add(INumber value)
    {
      Value += value.Value;
    }

    /// <summary>
    /// Privé, permet de retourner la classe après l'addition.
    /// <br/>
    /// Voir <see cref="Add(INumber)"/>
    /// </summary>
    /// <param name="item">Valeur à ajouter, peut être un nombre ou un <see cref="INumber"/></param>
    /// <returns><see cref="this"/></returns>
    private RotomecaNumber AddEx(dynamic item)
    {
      Add(item is INumber ? item as INumber : new RotomecaNumber(item));
      return this;
    }

    /// <summary>
    /// Divise par <paramref name="value"/>
    /// </summary>
    /// <param name="value"></param>
    public override void Divide(INumber value)
    {
      if (!(value.Value is float || value.Value is double)) Value /= (double)value.Value;
      else Value /= value.Value;
    }

    /// <summary>
    /// Privé, permet de retourner la classe après la division.
    /// <br/>
    /// Voir <see cref="Divide(INumber)"/>
    /// </summary>
    /// <param name="item">Peut être un nombre ou un <see cref="INumber"/></param>
    /// <returns><see cref="this"/></returns>
    private RotomecaNumber DivideEx(dynamic item)
    {
      Divide(item is INumber ? item as INumber : new RWholeNumber(item));
      return this;
    }

    /// <summary>
    /// Multiplie à <paramref name="value"/>
    /// </summary>
    /// <param name="value">Valeur qui sera ajouté</param>
    public override void Multiply(INumber value)
    {
      Value *= value.Value;
    }
    /// <summary>
    /// Privé, permet de retourner la classe après la multiplication.
    /// <br/>
    /// Voir <see cref="Multiply(INumber)"/>
    /// </summary>
    /// <param name="item">Valeur à multiplier, peut être un nombre ou un <see cref="INumber"/></param>
    /// <returns><see cref="this"/></returns>
    private RotomecaNumber MultiplyEx(dynamic item)
    {
      Multiply(item is INumber ? item as INumber : new RotomecaNumber(item));
      return this;
    }

    /// <summary>
    /// Soustrait de <paramref name="value"/>
    /// </summary>
    /// <param name="value">Valeur qui sera soustraite</param>
    public override void Remove(INumber value)
    {
      Value -= value.Value;
    }

    #endregion

    #region Subsitutions
    /// <summary>
    /// Récupère le <see cref="TypeCode"/> de la classe.
    /// </summary>
    /// <returns><see cref="TypeCode"/></returns>
    public override TypeCode GetTypeCode()
    {
      return Value.GetTypeCode();
    }

    /// <summary>
    /// Vérifie si est égal à <paramref name="value"/>
    /// </summary>
    /// <typeparam name="T">Type de l'objet que l'on veut tester</typeparam>
    /// <param name="value">Objet à comparer</param>
    /// <returns>Vrai ou faux</returns>
    public override bool IsEqualTo<T>(T value)
    {
      return value.Equals(Value);
    }

    /// <summary>
    /// Vérifie si est égal à <paramref name="obj"/>
    /// </summary>
    /// <param name="obj">Objet à comparer</param>
    /// <returns>Vrai ou faux</returns>
    public override bool Equals(object obj)
    {
      return Equals(obj as RotomecaNumber);
    }

    /// <summary>
    /// Vérifie si est égal à <paramref name="other"/>
    /// </summary>
    /// <param name="other"><see cref="RotomecaNumber"/> à comparer</param>
    /// <returns>Vrai ou faux</returns>
    public bool Equals(RotomecaNumber other)
    {
      return !(other is null) &&
             EqualityComparer<dynamic>.Default.Equals(_number, other._number);
    }

    public override int GetHashCode()
    {
      return 87157683 + EqualityComparer<dynamic>.Default.GetHashCode(_number);
    }

    protected override T _Provider<T>(IFormatProvider provider, Func<dynamic, T> callback)
    {
      return base._Provider(provider, callback);
    }

    /// <summary>
    /// Transforme en <see cref="string"/>
    /// </summary>
    /// <returns><see cref="string"/></returns>
    public override string ToString()
    {
      return _number.ToString();
    }

    #endregion

    #region Statiques
    #region Privée
    /// <summary>
    /// Permet de faire les calcules pour les surcharges d'opérateurs
    /// <br></br>
    /// <exemple>Voir <see cref="operator *(RotomecaNumber, double)"/> ou <seealso cref="operator -(RotomecaNumber, int)"/> par exemple</exemple> 
    /// </summary>
    /// <param name="c">Type d'opération</param>
    /// <param name="l">Opérateur de gauche, voir <see href="https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/operators/operator-overloading"/> pour plus d'info</param> 
    /// <param name="r">Opérateur de droite, voir <see href="https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/operators/operator-overloading"/> pour plus d'info</param>
    /// <exception cref="Exceptions.ARotomecaException{Calculcate}"></exception>
    /// <returns>Résultat du calcul</returns>
    private static RotomecaNumber _Calculate(Calculcate c, dynamic l, dynamic r)
    {
      switch (c)
      {
        case Calculcate.plus:
          return new RotomecaNumber(l).AddEx(r);
        case Calculcate.moins:
          return new RotomecaNumber(l).AddEx(-r);
        case Calculcate.fois:
          return new RotomecaNumber(l).MultiplyEx(r);
        case Calculcate.diviser:
          return new RotomecaNumber(l).DivideEx(r);
        default:
          break;
      }

      throw new Exceptions.RotomecaCalculationNumberException<Calculcate>(l, r, c, "RotomecaNumber/_Calculate", "Cette méthode de calculation n'a pas été implémentée !");
    }
    #endregion

    #region Public
    /// <summary>
    /// Instancie une valeur de 0.
    /// </summary>
    public static RotomecaNumber Zero => new RotomecaNumber(RWholeNumber.Zero);
    /// <summary>
    /// Récupère la valeur max de la classe, voir <see cref="double.MaxValue"/>
    /// </summary>
    public static RotomecaNumber MaxValue => new RotomecaNumber(double.MaxValue);
    /// <summary>
    /// Récupère la valeur min de la classe, voir <see cref="double.MinValue"/>
    /// </summary>
    public static RotomecaNumber MinValue => new RotomecaNumber(double.MinValue);
    /// <summary>
    /// Récupère un nombre au hasard entre <see cref="MaxValue"/> et <see cref="MinValue"/>
    /// <para>
    /// Pour la génération du hasard, voir <seealso cref="Aleatoire.Nombre(int, int)"/></para>
    /// </summary>
    public static RotomecaNumber Random => Aleatoire.Nombre(int.MaxValue, int.MinValue);

    /// <summary>
    /// Récupère un nombre au hasard entre deux nombre (convertit en <see cref="int"/>).
    /// <para>
    /// Pour la génération du hasard, voir <seealso cref="Aleatoire.Nombre(int, int)"/></para>
    /// </summary>
    /// <param name="min">Valeur minimum (inclut)</param>
    /// <param name="max">Valeur maximum (exclut)</param>
    /// <returns>Nombre au hsard entre <paramref name="min"/> et <paramref name="max"/></returns>
    public static RotomecaNumber RandomRange(ARotomecaNumber min, ARotomecaNumber max) => Aleatoire.Nombre(min.ToInt32(null), max.ToInt32(null));
    #endregion
    #endregion

    #region Surcharges d'opérateurs

    #region Opérateurs +/-
    public static RotomecaNumber operator +(RotomecaNumber left) => left;
    public static RotomecaNumber operator -(RotomecaNumber left) => new RotomecaNumber(-left.Value);
    #endregion

    #region Operateurs +
    public static RotomecaNumber operator +(RotomecaNumber left, int right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, sbyte right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }
    public static RotomecaNumber operator +(RotomecaNumber left, long right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, short right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, ushort right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, uint right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, ulong right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, float right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, double right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    #endregion

    #region Opérateurs -
    public static RotomecaNumber operator -(RotomecaNumber left, int right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, sbyte right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }
    public static RotomecaNumber operator -(RotomecaNumber left, long right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, short right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, ushort right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, uint right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, ulong right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, float right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, double right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    #endregion

    #region Operateurs *
    public static RotomecaNumber operator *(RotomecaNumber left, int right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, sbyte right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }
    public static RotomecaNumber operator *(RotomecaNumber left, long right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, short right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, ushort right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, uint right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, ulong right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, float right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, double right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    #endregion

    #region Operateurs /

    public static RotomecaNumber operator /(RotomecaNumber left, float right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, double right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, int right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, sbyte right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }
    public static RotomecaNumber operator /(RotomecaNumber left, long right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, short right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, ushort right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, uint right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, ulong right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    #endregion

    #region Opérateurs ==/!=

    public static bool operator ==(RotomecaNumber left, RotomecaNumber right)
    {
      return EqualityComparer<RotomecaNumber>.Default.Equals(left, right);
    }

    public static bool operator !=(RotomecaNumber left, RotomecaNumber right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, int right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, int right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, bool right)
    {
      return left == 0 && !right || left == 1 && right;
    }

    public static bool operator !=(RotomecaNumber left, bool right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, sbyte right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, sbyte right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, short right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, short right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, long right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, long right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, ushort right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, ushort right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, uint right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, uint right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, ulong right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, ulong right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, float right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, float right)
    {
      return !(left == right);
    }

    public static bool operator ==(RotomecaNumber left, double right)
    {
      return left.Value == right;
    }

    public static bool operator !=(RotomecaNumber left, double right)
    {
      return !(left == right);
    }
    #endregion

    #region Opérateurs >/<

    public static bool operator >(RotomecaNumber l, RotomecaNumber r)
    {
      return l.Value > r.Value;
    }

    public static bool operator <(RotomecaNumber l, RotomecaNumber r)
    {
      return l.Value < r.Value;
    }

    public static bool operator >(RotomecaNumber l, INumber r)
    {
      return l.Value > r.Value;
    }

    public static bool operator <(RotomecaNumber l, INumber r)
    {
      return l.Value < r.Value;
    }

    public static bool operator >(RotomecaNumber l, sbyte r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, sbyte r)
    {
      return l.Value < r;
    }
    public static bool operator >(RotomecaNumber l, short r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, short r)
    {
      return l.Value < r;
    }

    public static bool operator >(RotomecaNumber l, int r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, int r)
    {
      return l.Value < r;
    }

    public static bool operator >(RotomecaNumber l, long r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, long r)
    {
      return l.Value < r;
    }

    public static bool operator >(RotomecaNumber l, ushort r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, ushort r)
    {
      return l.Value < r;
    }

    public static bool operator >(RotomecaNumber l, uint r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, uint r)
    {
      return l.Value < r;
    }

    public static bool operator >(RotomecaNumber l, ulong r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, ulong r)
    {
      return l.Value < r;
    }

    public static bool operator >(RotomecaNumber l, float r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, float r)
    {
      return l.Value < r;
    }

    public static bool operator >(RotomecaNumber l, double r)
    {
      return l.Value > r;
    }

    public static bool operator <(RotomecaNumber l, double r)
    {
      return l.Value < r;
    }
    #endregion

    #region Opérateurs >=/<=

    public static bool operator >=(RotomecaNumber l, RotomecaNumber r)
    {
      return !(l.Value < r.Value);
    }

    public static bool operator <=(RotomecaNumber l, RotomecaNumber r)
    {
      return !(l.Value > r.Value);
    }

    public static bool operator >=(RotomecaNumber l, INumber r)
    {
      return !(l.Value < r.Value);
    }

    public static bool operator <=(RotomecaNumber l, INumber r)
    {
      return !(l.Value > r.Value);
    }

    public static bool operator >=(RotomecaNumber l, sbyte r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, sbyte r)
    {
      return !(l.Value > r);
    }
    public static bool operator >=(RotomecaNumber l, short r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, short r)
    {
      return !(l.Value > r);
    }

    public static bool operator >=(RotomecaNumber l, int r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, int r)
    {
      return !(l.Value > r);
    }

    public static bool operator >=(RotomecaNumber l, long r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, long r)
    {
      return !(l.Value > r);
    }

    public static bool operator >=(RotomecaNumber l, ushort r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, ushort r)
    {
      return !(l.Value > r);
    }

    public static bool operator >=(RotomecaNumber l, uint r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, uint r)
    {
      return !(l.Value > r);
    }

    public static bool operator >=(RotomecaNumber l, ulong r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, ulong r)
    {
      return !(l.Value > r);
    }

    public static bool operator >=(RotomecaNumber l, float r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, float r)
    {
      return !(l.Value > r);
    }

    public static bool operator >=(RotomecaNumber l, double r)
    {
      return !(l.Value < r);
    }

    public static bool operator <=(RotomecaNumber l, double r)
    {
      return !(l.Value > r);
    }
    #endregion

    #region Autres opérateurs
    public static bool operator !(RotomecaNumber r)
    {
      return r == 0;
    }

    public static RotomecaNumber operator ++(RotomecaNumber r)
    {
      return r.AddEx(1);
    }

    public static RotomecaNumber operator --(RotomecaNumber r)
    {
      return r.AddEx(-1);
    }

    public static bool operator true(RotomecaNumber r)
    {
      return r != 0;
    }

    public static bool operator false(RotomecaNumber r)
    {
      return !r;
    }

    #endregion

    #endregion

    #region Cast
    public static implicit operator RotomecaNumber(sbyte r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(short r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(int r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(long r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(ushort r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(uint r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(ulong r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(float r)
    {
      return new RotomecaNumber(r);
    }
    public static implicit operator RotomecaNumber(double r)
    {
      return new RotomecaNumber(r);
    }

    public static explicit operator sbyte(RotomecaNumber r)
    {
      return r.ToSByte(null);
    }
    public static explicit operator short(RotomecaNumber r)
    {
      return r.ToInt16(null);
    }
    public static explicit operator int(RotomecaNumber r)
    {
      return r.ToInt32(null);
    }
    public static explicit operator long(RotomecaNumber r)
    {
      return r.ToInt64(null);
    }
    public static explicit operator ushort(RotomecaNumber r)
    {
      return r.ToUInt16(null);
    }
    public static explicit operator uint(RotomecaNumber r)
    {
      return r.ToUInt32(null);
    }
    public static explicit operator ulong(RotomecaNumber r)
    {
      return r.ToUInt64(null);
    }
    public static explicit operator float(RotomecaNumber r)
    {
      return r.ToSingle(null);
    }
    public static explicit operator double(RotomecaNumber r)
    {
      return r.ToDouble(null);
    }
    #endregion
  }
}
