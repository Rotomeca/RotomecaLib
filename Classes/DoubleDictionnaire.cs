using System;
using System.Collections.Generic;
using System.Linq;

namespace RotomecaLib.Classes
{
  public class DoubleDictionnaire<TCle1, TCle2, TValue> : Abstraite.ADoubleDictionnaire<TCle1, TCle2, TValue>
  {
    public DoubleDictionnaire() : base(new Dictionary<(TCle1, TCle2), TValue>())
    {

    }

    public DoubleDictionnaire(IDictionary<(TCle1, TCle2), TValue> datas) : base(new Dictionary<(TCle1, TCle2), TValue>(datas))
    {

    }

    public DoubleDictionnaire(Interfaces.IDoubleDictionnaire<TCle1, TCle2, TValue> datas) : base(new Dictionary<(TCle1, TCle2), TValue>(datas))
    {

    }

    public DoubleDictionnaire(Abstraite.ADoubleDictionnaire<TCle1, TCle2, TValue> datas) : base(new Dictionary<(TCle1, TCle2), TValue>(datas))
    {

    }

    public DoubleDictionnaire(DoubleDictionnaire<TCle1, TCle2, TValue> datas) : base(new Dictionary<(TCle1, TCle2), TValue>(datas))
    {

    }

    public DoubleDictionnaire(IEnumerable<KeyValuePair<(TCle1, TCle2), TValue>> datas) : base (new Dictionary<(TCle1, TCle2), TValue>(datas.EnDoubleDictionnaire(x => x.Key, x => x.Value)))
    {

    }


  }
}
