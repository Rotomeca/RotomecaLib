using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  internal sealed class RNumberFloat : ARotomecaNumber, IEquatable<RNumberFloat>
  {
    private dynamic _number;

    public RNumberFloat(float number)
    {
      _number = _Set(number);
    }

    public RNumberFloat(dynamic number)
    {
      _number = _Set(number);
    }

    public RNumberFloat(INumber number)
    {
      _number = _Set(number);
    }


    private dynamic _Set(dynamic number)
    {
      dynamic _number;
      if (number >= float.MinValue && number <= float.MaxValue)
      {
        _number = number;
      }
      else if (number is INumber)
      {
        return _Set((number as INumber).Value);
      }
      else
      {
        _number = (double)number;
      }

      return _number;
    }

    public override dynamic Value
    {
      get { return _number; }
      set
      {
        if (value is float)
        {
          _number = _Set(value);
        }
        else if (value is double)
        {
          _number = _Set(value);
        }
        else if (float.TryParse(value.ToString(), out float floatValue))
        {
          Value = floatValue;
        }
        else
        {
          throw new ArgumentException("La valeur n'est pas un nombre flottant valide.");
        }
      }
    }

    public override void Add(INumber value)
    {
      Value += (double)value.Value;
    }

    public void Add(dynamic value)
    {
      Add(value is INumber ? value as INumber : new RNumberFloat(value));
    }

    public RNumberFloat AddEx(INumber value)
    {
      Add(value);
      return this;
    }

    public RNumberFloat AddEx(dynamic value)
    {
      Add(value);
      return this;
    }

    public override void Multiply(INumber value)
    {
      Value *= (double)value.Value;
    }

    public void Multiply(dynamic value)
    {
      Multiply(value is INumber ? value as INumber : new RNumberFloat(value));
    }

    public RNumberFloat MultiplyEx(INumber value)
    {
      Multiply(value);
      return this;
    }

    public RNumberFloat MultiplyEx(dynamic value)
    {
      Multiply(value);
      return this;
    }

    public override void Divide(INumber value)
    {
      Value /= (double)value.Value;
    }

    public void Divide(dynamic value)
    {
      if (value is INumber) Divide(value as INumber);
      else Divide(new RNumberFloat(value));
    }

    public RNumberFloat DivideEx(INumber value)
    {
      Divide(value);
      return this;
    }

    public RNumberFloat DivideEx(dynamic value)
    {
      return value is INumber ? DivideEx(value as INumber) : DivideEx(new RNumberFloat(value));
    }

    public override TypeCode GetTypeCode()
    {
      return Value.GetTypeCode();
    }

    public override bool IsEqualTo<T>(T value)
    {
      return value.Equals(Value);
    }

    public override void Remove(INumber value)
    {
      Value -= (double)value.Value;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as RNumberFloat);
    }

    public bool Equals(RNumberFloat other)
    {
      return !(other is null) &&
             EqualityComparer<dynamic>.Default.Equals(_number, other._number);
    }

    public bool Equals(RWholeNumber other)
    {
      return other != null &&
             EqualityComparer<dynamic>.Default.Equals(_number, other.Value);
    }

    public override int GetHashCode()
    {
      return 87157683 + EqualityComparer<dynamic>.Default.GetHashCode(_number);
    }

    public static RNumberFloat operator +(RNumberFloat left) => left;
    public static RNumberFloat operator -(RNumberFloat left) => new RNumberFloat(-left.Value);

    public static bool operator >(RNumberFloat f, int r)
    {
      return f.Value > r;
    }

    public static bool operator <(RNumberFloat f, int r)
    {
      return f.Value < r;
    }

    public static bool operator >=(RNumberFloat f, int r)
    {
      return !(f.Value < r);
    }

    public static bool operator <=(RNumberFloat f, int r)
    {
      return !(f.Value > r);
    }

    public static bool operator ==(RNumberFloat left, RNumberFloat right)
    {
      return EqualityComparer<RNumberFloat>.Default.Equals(left, right);
    }

    public static bool operator !=(RNumberFloat left, RNumberFloat right)
    {
      return !(left == right);
    }

    public static bool operator ==(RNumberFloat left, RWholeNumber right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(RNumberFloat left, RWholeNumber right)
    {
      return !(left == right);
    }

    enum Calculcate
    {
      plus,
      moins,
      fois,
      diviser
    }

    private static RNumberFloat _Calculate(Calculcate c, dynamic l, dynamic r)
    {
      switch (c)
      {
        case Calculcate.plus:
          return new RNumberFloat(l).AddEx(r);
        case Calculcate.moins:
          return new RNumberFloat(l).AddEx(-r);
        case Calculcate.fois:
          return new RNumberFloat(l).MultiplyEx(-r);
        case Calculcate.diviser:
          return new RNumberFloat(l).DivideEx(r);
        default:
          break;
      }

      throw new Exception();
    }


    //+
    public static RNumberFloat operator +(RNumberFloat left, INumber right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RNumberFloat operator +(RNumberFloat left, float right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RNumberFloat operator +(RNumberFloat left, double right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    //-
    public static RNumberFloat operator -(RNumberFloat left, INumber right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RNumberFloat operator -(RNumberFloat left, float right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RNumberFloat operator -(RNumberFloat left, double right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    //*
    public static RNumberFloat operator *(RNumberFloat left, INumber right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RNumberFloat operator *(RNumberFloat left, float right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RNumberFloat operator *(RNumberFloat left, double right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    // /
    public static RNumberFloat operator /(RNumberFloat left, INumber right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RNumberFloat operator /(RNumberFloat left, float right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    public static RNumberFloat operator /(RNumberFloat left, double right)
    {
      return _Calculate(Calculcate.diviser, left, right);
    }

    ///////////////////
    ///
    public static bool operator !(RNumberFloat r)
    {
      return r == 0;
    }

    public static RNumberFloat operator ++(RNumberFloat r)
    {
      return r.AddEx(1);
    }

    public static RNumberFloat operator --(RNumberFloat r)
    {
      return r.AddEx(-1);
    }

    public static bool operator true(RNumberFloat r)
    {
      return r != 0;
    }

    public static bool operator false(RNumberFloat r)
    {
      return !r;
    }
  }

}
