using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Interfaces
{
  public interface IDoubleDictionnaire<A, B, C> : IDictionary<(A, B), C>
  {
    C this[A key1, B key2] { get; set; }
    void Add(A key1, B key2, C value);
    void AddOrUpdate(A key1, B key2, C value);
    bool Remove(A key1, B key2);
    bool ContainsKey(A key1, B key2);

  }
}
