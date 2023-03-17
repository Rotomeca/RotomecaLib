using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public interface INumber : IConvertible
  {
    dynamic Value { get; set; }
    void Add(INumber value);
    void Remove(INumber value);
    void Reset();
    bool IsEqualTo<T>(T value);
  }
}
