using RotomecaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Exceptions
{
  public abstract class ARotomecaException<T> : Exception
  {
    public string From { get; private set; }
    public T ErroredObject { get; private set; }
    public IRotomecaArray Infos { get; private set; }

    public ARotomecaException(T erroredObject, string from, params string[] messages) : base(string.Join(string.Empty, messages))
    {
      From = from;
      ErroredObject = erroredObject;
      Infos = new RotomecaList<T>();
    }

    public ARotomecaException(T erroredObject, IRotomecaArray infos, string from, params string[] messages) : base(string.Join(string.Empty, messages))
    {
      From = from;
      ErroredObject = erroredObject;
      Infos = infos;
    }

    public ARotomecaException(T erroredObject, Exception inner, string from, params string[] messages) : base(string.Join(string.Empty, messages), inner)
    {
      From = from;
      ErroredObject = erroredObject;
      Infos = new RotomecaList<T>();
    }

    public ARotomecaException<T> AddInfo(object info)
    {
      Infos.Add(info);
      return this;
    }

    public abstract CodeErreur CodeErreur { get; }
  }
}
