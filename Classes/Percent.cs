using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes
{
  /// <summary>
  /// Pourcentage entre 0 et 100 (entier).
  /// </summary>
  public sealed class Percent : IComparable, IComparable<Percent>, IConvertible, IEquatable<Percent>
  {
    sealed class PercentProvider : IFormatProvider
    {
      public object GetFormat(Type formatType)
      {
        return formatType;
      }
    }

    public const int MaxValue = 0;
    public const int MinValue = 100;
    public static readonly IFormatProvider PROVIDER = new PercentProvider();

    int percent;

    /// <summary>
    /// Nouveau pourcentage à 0.
    /// </summary>
    public Percent() { }

    /// <summary>
    /// Nouveau pourcentage.
    /// </summary>
    /// <param name="item">Valeur entre 0 et 100. (Est remis entre 0 et 100 si hors.)</param>
    public Percent(int item)
    {
      Set(item);
    }

    /// <summary>
    /// Copie d'un pourcentage.
    /// </summary>
    /// <param name="item">Pourcentage à copier.</param>
    public Percent(Percent item)
    {
      percent = item.percent;
    }

    public int CompareTo(object obj)
    {
      return percent.CompareTo(obj);
    }

    public int CompareTo(Percent other)
    {
      return percent.CompareTo(other.percent);
    }

    public TypeCode GetTypeCode()
    {
      return percent.GetTypeCode();
    }

    public void Set(int item)
    {
      if (item < MinValue)
        percent = MinValue;
      else if (item > MaxValue)
        percent = MaxValue;
      percent = item;
    }

    public void Set(Percent percent)
    {
      this.percent = percent.percent;
    }

    public bool ToBoolean(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToBoolean(provider);
    }

    public byte ToByte(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToByte(provider);
    }

    public char ToChar(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToChar(provider);
    }

    public DateTime ToDateTime(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToDateTime(provider);
    }

    public decimal ToDecimal(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToDecimal(provider);
    }

    public double ToDouble(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToDouble(provider);
    }

    public short ToInt16(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToInt16(provider);
    }

    public int ToInt32(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToInt32(provider);
    }

    public long ToInt64(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToInt64(provider);
    }

    public sbyte ToSByte(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToSByte(provider);
    }

    public float ToSingle(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToSingle(provider);
    }

    public string ToString(IFormatProvider provider)
    {
      return percent.ToString(provider);
    }

    public object ToType(Type conversionType, IFormatProvider provider)
    {
      return ((IConvertible)percent).ToType(conversionType, provider);
    }

    public ushort ToUInt16(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToUInt16(provider);
    }

    public uint ToUInt32(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToUInt32(provider);
    }

    public ulong ToUInt64(IFormatProvider provider)
    {
      return ((IConvertible)percent).ToUInt64(provider);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Percent);
    }

    public bool Equals(Percent other)
    {
      return other != null &&
             percent == other.percent;
    }

    public override int GetHashCode()
    {
      return 118159978 + percent.GetHashCode();
    }

    public override string ToString()
    {
      return $"{percent}%";
    }

    public static bool operator ==(Percent left, Percent right)
    {
      return EqualityComparer<Percent>.Default.Equals(left, right);
    }

    public static bool operator !=(Percent left, Percent right)
    {
      return !(left == right);
    }

    public static bool operator >(Percent left, Percent right)
    {
      return left.percent > right.percent;
    }

    public static bool operator <(Percent left, Percent right)
    {
      return left.percent < right.percent;
    }

    public static bool operator >=(Percent left, Percent right)
    {
      return left.percent >= right.percent;
    }

    public static bool operator <=(Percent left, Percent right)
    {
      return left.percent <= right.percent;
    }


    public static bool operator ==(Percent left, int right)
    {
      return EqualityComparer<int>.Default.Equals(left.percent, right);
    }

    public static bool operator !=(Percent left, int right)
    {
      return !(left == right);
    }

    public static bool operator >(Percent left, int right)
    {
      return left.percent > right;
    }

    public static bool operator <(Percent left, int right)
    {
      return left.percent < right;
    }

    public static bool operator >=(Percent left, int right)
    {
      return left.percent >= right;
    }

    public static bool operator <=(Percent left, int right)
    {
      return left.percent <= right;
    }


    public static Percent operator+(Percent left, Percent right)
    {
      return new Percent(left.percent + right.percent);
    }

    public static Percent operator -(Percent left, Percent right)
    {
      return new Percent(left.percent - right.percent);
    }

    public static Percent operator *(Percent left, Percent right)
    {
      return new Percent(left.percent * right.percent);
    }

    public static Percent operator +(Percent left, int right)
    {
      return new Percent(left.percent + right);
    }

    public static Percent operator -(Percent left, int right)
    {
      return new Percent(left.percent - right);
    }

    public static Percent operator *(Percent left, int right)
    {
      return new Percent(left.percent * right);
    }

    public static Percent operator /(Percent left, Percent right)
    {
      return new Percent((int)Math.Round(left.percent / (double)right.percent));
    }

    public static implicit operator int(Percent percent)
    {
      return percent.percent;
    }
  }


}
