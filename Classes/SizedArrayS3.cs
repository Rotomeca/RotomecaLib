using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib
{
  public class SizedArrayS3<T> : SizedArray<T>
  {
    public SizedArrayS3() : base(3) { }
    public SizedArrayS3(T item) : base(3, item) { }
    public SizedArrayS3(T item1, T item2) : base(3, item1, item2) { }
    public SizedArrayS3(T item1, T item2, T item3) : base(3, item1, item2, item3) { }

    public static SizedArrayS3<T> FromEnumerable(IEnumerable<T> items)
    {
      var tmp = new SizedArrayS3<T>();

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
