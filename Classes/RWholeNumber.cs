using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  internal sealed class RWholeNumber : ARotomecaNumber, IEquatable<RWholeNumber>
  {
    enum Calculcate
    {
      plus,
      moins,
      fois
    }

    enum CalculcateFloat
    {
      divide
    }

    private dynamic _number; // la variable peut changer de type selon le nombre stocké

    public RWholeNumber(dynamic number)
    {
      _Init(number);
    }

    private void _Init(dynamic number)
    {
      _number = _Set(number);
    }

    private dynamic _Set(dynamic number)
    {
      dynamic r;
      if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
      {
        r = (sbyte)number;
      }
      else if (number >= short.MinValue && number <= short.MaxValue)
      {
        r = (short)number;
      }
      else if (number >= int.MinValue && number <= int.MaxValue)
      {
        r = (int)number;
      }
      else if (number is RWholeNumber)
      {
        return _Set((number as RWholeNumber).Value);
      }
      else
      {
        r = (long)number;
      }

      return r;
    }

    public override void Add(INumber value)
    {
      Value += (long)value.Value;
    }

    public void Add(dynamic value)
    {
      if (value is INumber) Add(value as INumber);
      else Add(new RWholeNumber(value));
    }

    public RWholeNumber AddEx(INumber value)
    {
      Add(value);
      return this;
    }

    public RWholeNumber AddEx(dynamic value)
    {
      return value is INumber ? AddEx(value as INumber) : AddEx(new RWholeNumber(value));
    }

    public override void Multiply(INumber value)
    {
      Value *= (long)value.Value;
    }

    public void Multiply(dynamic value)
    {
      if (value is INumber) Multiply(value as INumber);
      else Multiply(new RWholeNumber(value));
    }

    public RWholeNumber MultiplyEx(INumber value)
    {
      Multiply(value);
      return this;
    }

    public RWholeNumber MultiplyEx(dynamic value)
    {
      return value is INumber ? MultiplyEx(value as INumber) : MultiplyEx(new RWholeNumber(value));
    }

    public override void Divide(INumber value)
    {
      Value /= (long)value.Value;
    }

    public void Divide(dynamic value)
    {
      if (value is INumber) Divide(value as INumber);
      else Divide(new RWholeNumber(value));
    }

    public RNumberFloat DivideEx(INumber value)
    {
      Divide(value);
      return new RNumberFloat(Value).DivideEx(value);
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
      Value -= (long)value.Value;
    }

    public override dynamic Value
    {
      get { return _number; }
      set
      {

        if (value is sbyte)
        {
          _number = _Set(value);
        }
        else if (value is short)
        {
          _number = _Set(value);
        }
        else if (value is int)
        {
          _number = _Set(value);
        }
        else if (value is long)
        {
          _number = _Set(value);
        }
        else if (int.TryParse(value.ToString(), out int intValue)) // essaie de convertir en int
        {
          Value = intValue; // récursion pour choisir la bonne taille de variable
        }
        else
        {
          throw new ArgumentException("La valeur n'est pas un entier valide.");
        }
      }
    }

    public static RWholeNumber Zero => new RWholeNumber(0);

    private static RWholeNumber _Calculate(Calculcate c, dynamic l, dynamic r)
    {
      switch (c)
      {
        case Calculcate.plus:
          return new RWholeNumber(l).AddEx(r);
        case Calculcate.moins:
          return new RWholeNumber(l).AddEx(-r);
        case Calculcate.fois:
          return new RWholeNumber(l).MultiplyEx(r);
        default:
          break;
      }

      throw new Exceptions.RotomecaCalculationNumberException<Calculcate>(l, r, c, "RWholeNumber/_Calculate", "Cette méthode de calculation n'a pas été implémentée !");
    }

    private static RNumberFloat _Calculate(CalculcateFloat f, dynamic l, dynamic r)
    {
      switch (f)
      {
        case CalculcateFloat.divide:
          var a = new RNumberFloat(0.0f);
          a.Add(l is INumber ? l : new RNumberFloat(l));
          return a.DivideEx(r);
        default:
          break;
      }

      throw new Exceptions.RotomecaCalculationNumberException<CalculcateFloat>(l, r, f, "RWholeNumber/_Calculate", "Cette méthode de calculation n'a pas été implémentée !");
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as RWholeNumber);
    }

    public bool Equals(RWholeNumber other)
    {
      return other != null &&
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
      return Value.ToString();
    }

    public static RWholeNumber operator +(RWholeNumber left) => left;
    public static RWholeNumber operator -(RWholeNumber left) => new RWholeNumber(-left.Value);
    //+
    public static RWholeNumber operator +(RWholeNumber left, RWholeNumber right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RWholeNumber operator +(RWholeNumber left, int right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RWholeNumber operator +(RWholeNumber left, sbyte right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }
    public static RWholeNumber operator +(RWholeNumber left, long right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RWholeNumber operator +(RWholeNumber left, short right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RWholeNumber operator +(RWholeNumber left, ushort right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RWholeNumber operator +(RWholeNumber left, uint right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RWholeNumber operator +(RWholeNumber left, ulong right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    public static RWholeNumber operator +(RWholeNumber left, RNumberFloat right)
    {
      return _Calculate(Calculcate.plus, left, right >= 0 ? (dynamic)right.ToUInt64(null) : (dynamic)right.ToInt64(null));
    }

    public static RWholeNumber operator +(RWholeNumber left, RotomecaNumber right)
    {
      return left + right.Value;
    }

    public static RWholeNumber operator +(RWholeNumber left, INumber right)
    {
      return _Calculate(Calculcate.plus, left, right);
    }

    //-
    public static RWholeNumber operator -(RWholeNumber left, RWholeNumber right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RWholeNumber operator -(RWholeNumber left, int right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RWholeNumber operator -(RWholeNumber left, sbyte right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }
    public static RWholeNumber operator -(RWholeNumber left, long right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RWholeNumber operator -(RWholeNumber left, short right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RWholeNumber operator -(RWholeNumber left, ushort right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RWholeNumber operator -(RWholeNumber left, uint right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RWholeNumber operator -(RWholeNumber left, ulong right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    public static RWholeNumber operator -(RWholeNumber left, RNumberFloat right)
    {
      return _Calculate(Calculcate.moins, left, right >= 0 ? (dynamic)right.ToUInt64(null) : (dynamic)right.ToInt64(null));
    }

    public static RWholeNumber operator -(RWholeNumber left, RotomecaNumber right)
    {
      return left - right.Value;
    }

    public static RWholeNumber operator -(RWholeNumber left, INumber right)
    {
      return _Calculate(Calculcate.moins, left, right);
    }

    //*
    public static RWholeNumber operator *(RWholeNumber left, RWholeNumber right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RWholeNumber operator *(RWholeNumber left, int right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RWholeNumber operator *(RWholeNumber left, sbyte right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }
    public static RWholeNumber operator *(RWholeNumber left, long right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RWholeNumber operator *(RWholeNumber left, short right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RWholeNumber operator *(RWholeNumber left, ushort right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RWholeNumber operator *(RWholeNumber left, uint right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RWholeNumber operator *(RWholeNumber left, ulong right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    public static RWholeNumber operator *(RWholeNumber left, RNumberFloat right)
    {
      return _Calculate(Calculcate.fois, left, right >= 0 ? (dynamic)right.ToUInt64(null) : (dynamic)right.ToInt64(null));
    }

    public static RWholeNumber operator *(RWholeNumber left, RotomecaNumber right)
    {
      return left * right.Value;
    }

    public static RWholeNumber operator *(RWholeNumber left, INumber right)
    {
      return _Calculate(Calculcate.fois, left, right);
    }

    // /
    public static RNumberFloat operator /(RWholeNumber left, RWholeNumber right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, int right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, sbyte right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }
    public static RNumberFloat operator /(RWholeNumber left, long right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, short right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, ushort right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, uint right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, ulong right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, RNumberFloat right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static RNumberFloat operator /(RWholeNumber left, RotomecaNumber right)
    {
      return left / right.Value;
    }

    public static RNumberFloat operator /(RWholeNumber left, INumber right)
    {
      return _Calculate(CalculcateFloat.divide, left, right);
    }

    public static bool operator !(RWholeNumber r)
    {
      return r == 0;
    }

    public static RWholeNumber operator ++(RWholeNumber r)
    {
      return r.AddEx(1);
    }

    public static RWholeNumber operator --(RWholeNumber r)
    {
      return r.AddEx(-1);
    }

    public static bool operator true(RWholeNumber r)
    {
      return r != 0;
    }

    public static bool operator false(RWholeNumber r)
    {
      return !r;
    }

    public static implicit operator int(RWholeNumber number)
    {
      return number.ToInt32(null);
    }

    public static implicit operator uint(RWholeNumber number)
    {
      return number.ToUInt32(null);
    }

    public static implicit operator long(RWholeNumber number)
    {
      return number.ToInt64(null);
    }

    public static implicit operator ulong(RWholeNumber number)
    {
      return number.ToUInt64(null);
    }

    public static implicit operator RWholeNumber(sbyte number)
    {
      return new RWholeNumber(number);
    }

    public static implicit operator RWholeNumber(short number)
    {
      return new RWholeNumber(number);
    }

    public static implicit operator RWholeNumber(int number)
    {
      return new RWholeNumber(number);
    }

    public static implicit operator RWholeNumber(long number)
    {
      return new RWholeNumber(number);
    }

    public static implicit operator RWholeNumber(ushort number)
    {
      return new RWholeNumber(number);
    }

    public static implicit operator RWholeNumber(uint number)
    {
      return new RWholeNumber(number);
    }

    public static implicit operator RWholeNumber(ulong number)
    {
      return new RWholeNumber(number);
    }

    public static bool operator >(RWholeNumber f, int r)
    {
      return f.Value > r;
    }

    public static bool operator <(RWholeNumber f, int r)
    {
      return f.Value < r;
    }

    public static bool operator >=(RWholeNumber f, int r)
    {
      return !(f.Value < r);
    }

    public static bool operator <=(RWholeNumber f, int r)
    {
      return !(f.Value > r);
    }

    public static bool operator ==(RWholeNumber left, RWholeNumber right)
    {
      return EqualityComparer<RWholeNumber>.Default.Equals(left, right);
    }

    public static bool operator !=(RWholeNumber left, RWholeNumber right)
    {
      return !(left == right);
    }
  }

}
