using System.Collections.Generic;
using RotomecaLib;

namespace System.Linq
{
  public static class Linq
  {
    public static IndexedList<T> EnListeIndexe<T>(this IEnumerable<T> ts)
    {
      return new IndexedList<T>(ts.Select((x, i) => new ObjetIndexe<T>(i, x)));
    }

    public static IndexedList<Y> EnListeIndexe<T, Y>(this IEnumerable<T> ts, Func<T, Y> selector)
    {
      return new IndexedList<Y>(ts.Select(selector).Select((x, i) => new ObjetIndexe<Y>(i, x)));
    }

    public static List<T> ToList<T>(this IndexedList<T> ts)
    {
      return ts.Select(x => x.Objet).ToList();
    }
  }
}
