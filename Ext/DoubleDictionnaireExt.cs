using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
  public static class RotomecaLib___04122020DoubleDictionnaireExt
  {
    public static RotomecaLib.Interfaces.IDoubleDictionnaire<Cle1, Cle2, Valeur> EnIDoubleDictionnaire<Objet, Cle1, Cle2, Valeur>(this IEnumerable<Objet> t, Func<Objet, (Cle1, Cle2)> key, Func<Objet, Valeur> value)
    {
      return t.EnDoubleDictionnaire(key, value);
    }
    public static RotomecaLib.Classes.Abstraite.ADoubleDictionnaire<Cle1, Cle2, Valeur> EnADoubleDictionnaire<Objet, Cle1, Cle2, Valeur>(this IEnumerable<Objet> t, Func<Objet, (Cle1, Cle2)> key, Func<Objet, Valeur> value)
    {
      return t.EnDoubleDictionnaire(key, value);
    }
    public static RotomecaLib.DoubleDictionnaire<Cle1, Cle2, Valeur> EnDoubleDictionnaire<Objet, Cle1, Cle2, Valeur>(this IEnumerable<Objet> t, Func<Objet, (Cle1, Cle2)> key, Func<Objet, Valeur> value)
    {
      return new RotomecaLib.DoubleDictionnaire<Cle1, Cle2, Valeur>(t.ToDictionary(key, value));
    }

    public static IEnumerable<KeyValuePair<(Key1, Key2), Value>> Where<Key1, Key2, Value>(this RotomecaLib.Interfaces.IDoubleDictionnaire<Key1, Key2, Value> t, Func<Key1, Key2, Value, bool> where)
    {
      return t.Where(x => where(x.Key.Item1, x.Key.Item2, x.Value));
    }

    public static RotomecaLib.Interfaces.IDoubleDictionnaire<Cle1, Cle2, Valeur> FindAll<Cle1, Cle2, Valeur>(this RotomecaLib.Interfaces.IDoubleDictionnaire<Cle1, Cle2, Valeur> t, Func<Cle1, Cle2, Valeur, bool> where)
    {
      return t.Where(where).EnDoubleDictionnaire(x => x.Key, x => x.Value);
    }
  }
}
