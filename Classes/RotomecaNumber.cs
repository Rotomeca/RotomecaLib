using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public sealed class RotomecaNumber : ARotomecaNumber, IEquatable<RotomecaNumber>
  {
    #region Interne à la classe
    enum Calculcate
    {
      plus,
      moins,
      fois, 
      diviser
    }
    #endregion

    private dynamic _number;

    public RotomecaNumber(dynamic number)
    {
      _number = _Set(number);
    }

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

    public override dynamic Value
    {
      get { return _number.Value; }
      set { _number = new RotomecaNumber(value)._number; }
    }

    #region Modificateurs

    public override void Add(INumber value)
    {
      Value += value.Value;
    }

    private RotomecaNumber AddEx(dynamic item)
    {
      Add(item is INumber ? item as INumber : new RotomecaNumber(item));
      return this;
    }

    public override void Divide(INumber value)
    {
      if (!(value.Value is float || value.Value is double)) Value /= (double)value.Value;
      else Value /= value.Value;
    }

    private RotomecaNumber DivideEx(dynamic item)
    {
      Divide(item is INumber ? item as INumber : new RWholeNumber(item));
      return this;
    }

    public override void Multiply(INumber value)
    {
      Value *= value.Value;
    }

    private RotomecaNumber MultiplyEx(dynamic item)
    {
      Multiply(item is INumber ? item as INumber : new RotomecaNumber(item));
      return this;
    }

    public override void Remove(INumber value)
    {
      Value -= value.Value;
    }

    #endregion

    #region Subsitutions
    public override TypeCode GetTypeCode()
    {
      return Value.GetTypeCode();
    }

    public override bool IsEqualTo<T>(T value)
    {
      return value.Equals(Value);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as RotomecaNumber);
    }

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

    public override string ToString()
    {
      return _number.ToString();
    }

    #endregion

    #region Statiques
    #region Privée
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
          throw new Exception();
      }

      throw new Exception();
    }
    #endregion

    #region Public
    public static RotomecaNumber Zero => new RotomecaNumber(RWholeNumber.Zero);
    public static RotomecaNumber MaxValue => new RotomecaNumber(double.MaxValue);
    public static RotomecaNumber MinValue => new RotomecaNumber(double.MinValue);
    public static RotomecaNumber Random => Aleatoire.Nombre(int.MaxValue, int.MinValue);
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
    public static implicit operator RotomecaNumber(int r)
    {
      return new RotomecaNumber(r);
    }
    #endregion
  }
}
