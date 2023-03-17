using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public sealed class RWholeNumber : ARotomecaNumber
  {
    private dynamic _number; // la variable peut changer de type selon le nombre stocké

    public RWholeNumber(dynamic number)
    {
      _Init(number);
    }

    public RWholeNumber(RWholeNumber number)
    {
      _Init(number.Value);
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
  }

  public sealed class RNumberFloat : ARotomecaNumber
  {
    private dynamic _number;

    public RNumberFloat(float number)
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
  }

  public sealed class RotomecaNumber : ARotomecaNumber
  {
    private dynamic _number;

    public RotomecaNumber(dynamic number)
    {
      if (number is float || number is double)
      {
        _number = new RNumberFloat(number);
      }
      else
      {
        _number = new RWholeNumber(number);
      }
    }

    public override dynamic Value
    {
      get { return _number.Value; }
      set { _number.Value = new RotomecaNumber(value); }
    }

    public override void Add(INumber value)
    {
      Value += value.Value;
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
      Value -= value.Value;
    }
  }
}
