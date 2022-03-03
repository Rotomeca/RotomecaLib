//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;

//namespace RotomecaLib.Classes.Abstraite
//{
//  public abstract class ATableau2D<T> : Interfaces.ITableau2D<T>
//  {
//    List<T> _array;
//    int _width;
//    int _height;

//    public ATableau2D()
//    {
//      _array = new List<T>();
//      _width = _height = 0;
//    }

//    //public ATableau2D(int width, int height)
//    //{
//    //  _width = width;
//    //  _height = height;
//    //  _array = new List<T>();
//    //}
        

//    public T this[int index] { get => ((IList<T>)_array)[index]; set => ((IList<T>)_array)[index] = value; }
//    public T this[int row, int col] { get => _array[row*_width + col]; set => _array[row * _width + col] = value; }

//    public int Count => _width;

//    public bool IsReadOnly => ((ICollection<T>)_array).IsReadOnly;

//    public void Add(T item)
//    {
//      ((ICollection<T>)_array).Add(item);
//    }

//    public void Add(int row, T item)
//    {
//      throw new NotImplementedException();
//    }

//    public void Clear()
//    {
//      ((ICollection<T>)_array).Clear();
//    }

//    public bool Contains(T item)
//    {
//      return ((ICollection<T>)_array).Contains(item);
//    }

//    public void CopyTo(T[] _array, int arrayIndex)
//    {
//      ((ICollection<T>)this._array).CopyTo(_array, arrayIndex);
//    }

//    public IEnumerator<T> GetEnumerator()
//    {
//      return ((IEnumerable<T>)_array).GetEnumerator();
//    }

//    public int IndexOf(T item)
//    {
//      return ((IList<T>)_array).IndexOf(item);
//    }

//    public void Insert(int index, T item)
//    {
//      ((IList<T>)_array).Insert(index, item);
//    }

//    public bool Remove(T item)
//    {
//      return ((ICollection<T>)_array).Remove(item);
//    }

//    public bool Remove(int row, int col)
//    {
//      throw new NotImplementedException();
//    }

//    public void RemoveAt(int index)
//    {
//      ((IList<T>)_array).RemoveAt(index);
//    }

//    public void Resize(int size)
//    {
//      throw new NotImplementedException();
//    }

//    public void Sort<Y>(Func<T, Y> sort)
//    {
//      throw new NotImplementedException();
//    }

//    public T[,] ToArray()
//    {
//      throw new NotImplementedException();
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//      return ((IEnumerable)_array).GetEnumerator();
//    }
//  }
//}
