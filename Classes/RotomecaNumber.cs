using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public sealed class RotomecaNumber : ARotomecaNumber, IEquatable<RotomecaNumber>
  {
    enum Calculcate
    {
      plus,
      moins,
      fois, 
      diviser
    }

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

    public override TypeCode GetTypeCode()
    {
      return Value.GetTypeCode();
    }

    public override bool IsEqualTo<T>(T value)
    {
      return value.Equals(Value);
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

    public static RotomecaNumber operator +(RotomecaNumber left) => left;
    public static RotomecaNumber operator -(RotomecaNumber left) => new RotomecaNumber(-left.Value);
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

    //+
    //public static RotomecaNumber operator +(RotomecaNumber left, RotomecaNumber right)
    //{
    //  return _Calculate(Calculcate.plus, left, right);
    //}

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

    //public static RotomecaNumber operator +(RotomecaNumber left, RNumberFloat right)
    //{
    //  return _Calculate(Calculcate.plus, left, right.Value);
    //}

    public static RotomecaNumber operator +(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RotomecaNumber operator +(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    //-
    //public static RotomecaNumber operator -(RWholeNumber left, RWholeNumber right)
    //{
    //  return _Calculate(Calculcate.moins, left, right);
    //}

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

    //public static RotomecaNumber operator -(RotomecaNumber left, RNumberFloat right)
    //{
    //  return _Calculate(Calculcate.moins, left, right >= 0 ? (dynamic)right.ToUInt64(null) : (dynamic)right.ToInt64(null));
    //}

    public static RotomecaNumber operator -(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RotomecaNumber operator -(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    //*
    //public static RotomecaNumber operator *(RotomecaNumber left, RotomecaNumber right)
    //{
    //  return _Calculate(Calculcate.fois, left, right);
    //}

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

    //public static RotomecaNumber operator *(RWholeNumber left, RNumberFloat right)
    //{
    //  return _Calculate(Calculcate.fois, left, right >= 0 ? (dynamic)right.ToUInt64(null) : (dynamic)right.ToInt64(null));
    //}

    public static RotomecaNumber operator *(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RotomecaNumber operator *(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    // /
    //public static RNumberFloat operator /(RWholeNumber left, RWholeNumber right)
    //{
    //  return _Calculate(CalculcateFloat.divide, left, right);
    //}

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

    //public static RotomecaNumber operator /(RotomecaNumber left, RNumberFloat right)
    //{
    //  return _Calculate(CalculcateFloat.divide, left, right);
    //}

    public static RotomecaNumber operator /(RotomecaNumber left, RotomecaNumber right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RotomecaNumber operator /(RotomecaNumber left, INumber right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static bool operator ==(RotomecaNumber left, RotomecaNumber right)
    {
      return EqualityComparer<RotomecaNumber>.Default.Equals(left, right);
    }

    public static bool operator !=(RotomecaNumber left, RotomecaNumber right)
    {
      return !(left == right);
    }
  }
}
