using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public class RWholeNumber
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
      if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
      {
        _number = (sbyte)number;
      }
      else if (number >= short.MinValue && number <= short.MaxValue)
      {
        _number = (short)number;
      }
      else if (number >= int.MinValue && number <= int.MaxValue)
      {
        _number = (int)number;
      }
      else
      {
        _number = (long)number;
      }
    }

    public dynamic Value
    {
      get { return _number; }
      set
      {
        int intValue;
        if (value is sbyte)
        {
          _number = (sbyte)value;
        }
        else if (value is short)
        {
          _number = (short)value;
        }
        else if (value is int)
        {
          _number = (int)value;
        }
        else if (value is long)
        {
          _number = (long)value;
        }
        else if (int.TryParse(value.ToString(), out intValue)) // essaie de convertir en int
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

  public class RNumberFloat
  {
    private dynamic _number;

    public RNumberFloat(float number)
    {
      if (number >= float.MinValue && number <= float.MaxValue)
      {
        _number = number;
      }
      else
      {
        _number = (double)number;
      }
    }

    public dynamic Value
    {
      get { return _number; }
      set
      {
        float floatValue;
        if (value is float)
        {
          _number = (float)value;
        }
        else if (value is double)
        {
          _number = (double)value;
        }
        else if (float.TryParse(value.ToString(), out floatValue))
        {
          Value = floatValue;
        }
        else
        {
          throw new ArgumentException("La valeur n'est pas un nombre flottant valide.");
        }
      }
    }
  }

  public class RotomecaNumber
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

    public dynamic Value
    {
      get { return _number.Value; }
      set { _number.Value = value; }
    }
  }
}
