using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib
{
  public class RotomecaArrayS3<T> : RotomecaArray<T>
  {
    public RotomecaArrayS3() : base(3) { }
    public RotomecaArrayS3(T item) : base(3, item) { }
    public RotomecaArrayS3(T item1, T item2) : base(3, item1, item2) { }
    public RotomecaArrayS3(T item1, T item2, T item3) : base(3, item1, item2, item3) { }

    public static RotomecaArrayS3<T> FromEnumerable(IEnumerable<T> items)
    {
      var tmp = new RotomecaArrayS3<T>();

      int i = 0;
      foreach (var item in items)
      {
        if (i++ < 3)
        {
          tmp[i] = item;
        }
        else break;
      }

      return tmp;
    }
  }
}
