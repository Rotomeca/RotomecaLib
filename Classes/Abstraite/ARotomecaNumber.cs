using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public abstract class ARotomecaNumber : INumber
  {
    public abstract dynamic Value { get; set; }

    public abstract void Add(INumber value);
    public abstract TypeCode GetTypeCode();
    public abstract bool IsEqualTo<T>(T value);
    public abstract void Remove(INumber value);
    public void Reset()
    {
      Value = 0;
    }
    protected virtual T _Provider<T>(IFormatProvider provider, Func<dynamic, T> callback)
    {
      if (!(provider is null)) return (T)provider.GetFormat(Value);

      return callback(Value);
    }

    public bool ToBoolean(IFormatProvider provider)
    {
      return _Provider<bool>(provider, x => x > 0);
    }

    public byte ToByte(IFormatProvider provider)
    {
      return _Provider(provider, x => (byte)x);
    }

    public char ToChar(IFormatProvider provider)
    {
      return _Provider(provider, x => char.ConvertFromUtf32(ToInt32(null))[0]);
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
      return _Provider(provider, x => new DateTime(x));
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
      return _Provider(provider, x => (decimal)x);
    }

    public double ToDouble(IFormatProvider provider)
    {
      return _Provider(provider, x => (double)x);
    }

    public short ToInt16(IFormatProvider provider)
    {
      return _Provider(provider, x => (short)x);
    }

    public int ToInt32(IFormatProvider provider)
    {
      return _Provider(provider, x => (int)x);
    }

    public long ToInt64(IFormatProvider provider)
    {
      return _Provider(provider, x => (long)x);
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
      return _Provider(provider, x => (sbyte)x);
    }

    public float ToSingle(IFormatProvider provider)
    {
      return _Provider(provider, x => (float)x);
    }

    public string ToString(IFormatProvider provider)
    {
      return _Provider(provider, x => ToString());
    }

    public bool CanConvert(Type conversionType)
    {
      if (conversionType == typeof(string) ||
          conversionType == typeof(int) ||
          conversionType == typeof(double) ||
          conversionType == typeof(DateTime) ||
          conversionType == typeof(bool))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public object ToType(Type conversionType, IFormatProvider provider)
    {
      // Vérifie si la conversion est possible
      if (!CanConvert(conversionType))
      {
        throw new InvalidCastException($"Impossible de convertir l'objet de type {GetType().FullName} en {conversionType.FullName}.");
      }

      // Si la conversion est possible, effectue la conversion
      if (conversionType == typeof(string))
      {
        return ToString(provider);
      }
      else if (conversionType == typeof(int))
      {
        return Convert.ToInt32(ToDouble(provider));
      }
      else if (conversionType == typeof(double))
      {
        return ToDouble(provider);
      }
      else if (conversionType == typeof(DateTime))
      {
        return ToDateTime(provider);
      }
      else if (conversionType == typeof(bool))
      {
        return ToBoolean(provider);
      }
      else
      {
        throw new InvalidCastException($"Impossible de convertir l'objet de type {GetType().FullName} en {conversionType.FullName}.");
      }
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
      return _Provider(provider, x => (ushort)x);
    }

    public uint ToUInt32(IFormatProvider provider)
    {
      return _Provider(provider, x => (uint)x);
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
      return _Provider(provider, x => (ulong)x);
    }

    public override string ToString()
    {
      return Value.ToString();
    }
  }
}
