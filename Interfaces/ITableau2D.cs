using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Interfaces
{
  public interface ITableau2D<T> : IList<T>
  {
    T this[int row, int col] { get;set; }
    void Add(int row, T item);
    bool Remove(int row, int col);
    void Resize(int size);
    void Resize(int width, int height);
    void Sort<Y>(Func<T, Y> sort);
    T[,] ToArray();
  }
}
