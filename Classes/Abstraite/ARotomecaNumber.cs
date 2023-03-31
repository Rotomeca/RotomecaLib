using System;

namespace RotomecaLib
{
  /// <summary>
  /// Classe de base pour les nombres
  /// </summary>
  public abstract class ARotomecaNumber : INumber
  {
    /// <summary>
    /// Valeur de la classe
    /// </summary>
    public abstract dynamic Value { get; set; }

    #region Changement de valeur
    /// <summary>
    /// Additionne la valeur à la classe
    /// </summary>
    /// <param name="value">Value à ajouter</param>
    public abstract void Add(INumber value);
    /// <summary>
    /// Multiplie la valeur à la classe
    /// </summary>
    /// <param name="value">Valeur à multiplier</param>
    public abstract void Multiply(INumber value);
    /// <summary>
    /// Divise la classe par la valeur
    /// </summary>
    /// <param name="value"></param>
    public abstract void Divide(INumber value);
    /// <summary>
    /// Additionne négativement la valeur à la classe
    /// </summary>
    /// <param name="value">Value à retirer</param>
    public abstract void Remove(INumber value);
    #endregion

    #region Autres Abstractions
    /// <summary>
    /// Récupère le type code de la classe
    /// </summary>
    /// <returns>Type code de la classe</returns>
    public abstract TypeCode GetTypeCode();
    /// <summary>
    /// Vérifie si la classe est égale à une valeur. 
    /// </summary>
    /// <typeparam name="T"><see cref="INumber"/> ou nombre/flottant</typeparam>
    /// <param name="value">Valeur à comparer</param>
    /// <returns></returns>
    public abstract bool IsEqualTo<T>(T value);
    #endregion

    #region Divers
    /// <summary>
    /// Remet la classe à zéro
    /// </summary>
    public void Reset()
    {
      Value = 0;
    }
    /// <summary>
    /// Actions à faire lors d'une conversion de type
    /// </summary>
    /// <typeparam name="T">Type de retour</typeparam>
    /// <param name="provider">Formatter la sortie</param>
    /// <param name="callback">Action à faire si il n'y a pas de formatteur</param>
    /// <returns>Variable convertie</returns>
    protected virtual T _Provider<T>(IFormatProvider provider, Func<dynamic, T> callback)
    {
      if (!(provider is null)) return (T)provider.GetFormat(Value);

      return callback(Value);
    }
    #endregion

    #region Convertisseur
    /// <summary>
    /// Convertit en boolean
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>bool</returns>
    public bool ToBoolean(IFormatProvider provider)
    {
      return _Provider<bool>(provider, x => x > 0);
    }
    /// <summary>
    /// Convertit en byte
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>byte</returns>
    public byte ToByte(IFormatProvider provider)
    {
      return _Provider(provider, x => (byte)x);
    }

    /// <summary>
    /// Convertit en charactère
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>char</returns>
    public char ToChar(IFormatProvider provider)
    {
      return _Provider(provider, x => char.ConvertFromUtf32(ToInt32(null))[0]);
    }

    /// <summary>
    /// Convertit en Datetime
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>Date</returns>
    public DateTime ToDateTime(IFormatProvider provider)
    {
      return _Provider(provider, x => new DateTime(x));
    }

    /// <summary>
    /// Convertit en decimal
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>Decimal</returns>
    public decimal ToDecimal(IFormatProvider provider)
    {
      return _Provider(provider, x => (decimal)x);
    }

    /// <summary>
    /// Convertit en double
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>double</returns>
    public double ToDouble(IFormatProvider provider)
    {
      return _Provider(provider, x => (double)x);
    }

    /// <summary>
    /// Convertit en short
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>short</returns>
    public short ToInt16(IFormatProvider provider)
    {
      return _Provider(provider, x => (short)x);
    }

    /// <summary>
    /// Convertit en int
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>int</returns>
    public int ToInt32(IFormatProvider provider)
    {
      return _Provider(provider, x => (int)x);
    }

    /// <summary>
    /// Convertit en long
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>long</returns>
    public long ToInt64(IFormatProvider provider)
    {
      return _Provider(provider, x => (long)x);
    }

    /// <summary>
    /// Convertit en sByte
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>sByte</returns>
    public sbyte ToSByte(IFormatProvider provider)
    {
      return _Provider(provider, x => (sbyte)x);
    }

    /// <summary>
    /// Convertit en float
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>Float</returns>
    public float ToSingle(IFormatProvider provider)
    {
      return _Provider(provider, x => (float)x);
    }

    /// <summary>
    /// Convertit en chaine de charactères
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>string</returns>
    public string ToString(IFormatProvider provider)
    {
      return _Provider(provider, x => ToString());
    }

    /// <summary>
    /// Vérifie si il est possible de convertir la classe
    /// </summary>
    /// <param name="conversionType">Type dans lequel on veut être convertit</param>
    /// <returns>vari si on peut convertir</returns>
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

    /// <summary>
    /// Convertit dans un type
    /// </summary>
    /// <param name="conversionType">Type souhaité</param>
    /// <param name="provider">Format</param>
    /// <returns>Objet</returns>
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

    /// <summary>
    /// Convertit en ushort
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>ushort</returns>
    public ushort ToUInt16(IFormatProvider provider)
    {
      return _Provider(provider, x => (ushort)x);
    }

    /// <summary>
    /// Convertit en uint
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>uint</returns>
    public uint ToUInt32(IFormatProvider provider)
    {
      return _Provider(provider, x => (uint)x);
    }

    /// <summary>
    /// Convertit en ulong
    /// </summary>
    /// <param name="provider">Format</param>
    /// <returns>ulong</returns>
    public ulong ToUInt64(IFormatProvider provider)
    {
      return _Provider(provider, x => (ulong)x);
    }

    /// <summary>
    /// Convertit la classe en <see cref="string"/>
    /// </summary>
    /// <returns>Nomber sous la forme d'un <see cref="string"/></returns>
    public override string ToString()
    {
      return Value.ToString();
    }

    #endregion

  }
}
