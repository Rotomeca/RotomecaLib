using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib
{
  [RotomecaLogging(typeof(Log.RotomecaLog))]
  public class RotomecaArray<T> : Interfaces.IRotomecaArray<T>, IEquatable<RotomecaArray<T>>
  {
    private static Type _loggerTypeModifier;
    private Interfaces.IRotomecaLog _logger;
    private T[] _array;
    private uint _size;

    public uint Length => _Length();

    public uint MaxLength => _size;

    public RotomecaArray() {
      _array = new T[0];
      _size = 0;
    }

    public RotomecaArray(uint size)
    {
      _array = new T[size];
      _size = size;
    }

    public RotomecaArray(uint size, params T[] datas)
    {
      _array = new T[size];
      _size = size;

      _Init(datas);
    }

    public RotomecaArray(uint size, IEnumerable<T> datas)
    {
      _array = new T[size];
      _size = size;

      _Init(datas);
    }

    private void _Init(IEnumerable<T> datas)
    {
      int i = 0;
      foreach (var item in datas)
      {
        if (i >= _size) return;

        this[i++] = item;
      }
    }

    public T this[int index] { get => _array[_GetIndex(index)]; set => Set(index, value); }
    public T this[uint index] { get => this[(int)index]; set => this[(int)index] = value; }

    public void Clear()
    {
      for (int i = 0; i < _size; ++i)
      {
        Remove(i, default);
      }
    }

    public bool Contains(T item)
    {
      return _array.Contains(item);
    }

    public int IndexOf(T item)
    {
      return Array.IndexOf(_array, item);
    }

    public T Remove(int index, T defaultItem)
    {
      var item = this[index];
      this[index] = default;
      return item;
    }

    private int _GetIndex(int index, [CallerMemberName] string caller = null)
    {
      if (index >= 0)
      {
        if (index > _size)
        {
          _Log(ELogSeverity.WARNING, caller, $"Impossible d'avoir un objet à l'index ${index} car l'index maximum est {_size - 1}");
          index = (int)_size - 1;
        }
      }
      else
      {
        index = (int)_size - index;

        if (index < 0)
        {
          _Log(ELogSeverity.WARNING, caller, $"Impossible d'avoir un objet à l'index ${index + (int)_size} car l'index minimum est 0");
          index = 0;
        }
      }

      return index;
    }

    public void Set(int index, T item)
    {
      _array[_GetIndex(index)] = item;
    }

    public T[] ToArray()
    {
      return _array;
    }

    public List<T> ToList()
    {
      return new List<T>(_array);
    }

    public void Order<TKey>(Func<T, TKey> callback)
    {
      _array = _array.OrderBy(callback).ToArray();
    }

    public void OrderDescending<TKey>(Func<T, TKey> callback)
    {
      _array = _array.OrderByDescending(callback).ToArray();
    }

    protected void _Log(ELogSeverity severity , string context, params string[] messages)
    {
      if (null == _logger)
      {
        Type logType = _loggerTypeModifier;
        if (null == logType)
        {
          RotomecaLoggingAttribute tmp = GetLoggingAttribute();

          if (tmp != null) logType = tmp.LogType;
        }

        if (null != logType) _logger = Activator.CreateInstance(logType) as Interfaces.IRotomecaLog;
        else _logger = new Log.RotomecaLog();
      }

      _logger.WriteLine(severity, context, messages);
    } 

    private RotomecaLoggingAttribute GetLoggingAttribute()
    {
      Type type = GetType();

      // Récupère tous les attributs appliqués à la classe
      object[] attributes = type.GetCustomAttributes(true);

      return attributes.Where(a => a.GetType() == typeof(RotomecaLoggingAttribute)).Cast<RotomecaLoggingAttribute>().FirstOrDefault();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return _array.Select(x => x).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _array.GetEnumerator();
    }

    private uint _Length(T TDefault = default)
    {
      uint size = 0;
      for (uint i = 0, len = MaxLength; i < len; ++i)
      {
        if (!TDefault.Equals(this[i])) ++size;
      }

      return size;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as RotomecaArray<T>);
    }

    public bool Equals(RotomecaArray<T> other)
    {
      return other != null &&
             _size == other._size &&
             EqualityComparer<T[]>.Default.Equals(_array, other._array);
    }

    public override int GetHashCode()
    {
      int hashCode = -1528616770;
      hashCode = hashCode * -1521134295 + EqualityComparer<T[]>.Default.GetHashCode(_array);
      hashCode = hashCode * -1521134295 + _size.GetHashCode();
      return hashCode;
    }

    public static bool operator ==(RotomecaArray<T> left, RotomecaArray<T> right)
    {
      return EqualityComparer<RotomecaArray<T>>.Default.Equals(left, right);
    }

    public static bool operator !=(RotomecaArray<T> left, RotomecaArray<T> right)
    {
      return !(left == right);
    }

    public static void SetLogger<LoggerType>() where LoggerType : Interfaces.IRotomecaLog
    {
      _loggerTypeModifier = typeof(LoggerType);
    }
  }
}
