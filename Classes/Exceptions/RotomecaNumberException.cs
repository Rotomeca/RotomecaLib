using RotomecaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Exceptions
{
  public abstract class ARotomecaNumberException : ARotomecaException<INumber>
  {
    public ARotomecaNumberException(INumber erroredObject, string from, params string[] messages) : base(erroredObject, from, messages)
    {
    }

    public ARotomecaNumberException(INumber erroredObject, IRotomecaArray infos, string from, params string[] messages) : base(erroredObject, infos, from, messages)
    {
    }

    public ARotomecaNumberException(INumber erroredObject, Exception inner, string from, params string[] messages) : base(erroredObject, inner, from, messages)
    {
    }
  }

  public class RotomecaCalculationNumberException<E> : ARotomecaNumberException where E : Enum
  {
    public dynamic LeftItem { get; private set; }
    public dynamic RightItem { get; private set; }
    public E CalculationType { get; private set; }
    public RotomecaCalculationNumberException(dynamic leftItem, dynamic rightItem, E calculationType, string from, params string[] messages) : base(null, from, messages)
    {
      LeftItem = leftItem;
      RightItem = rightItem;
      CalculationType = calculationType;
    }

    public RotomecaCalculationNumberException(dynamic leftItem, dynamic rightItem, E calculationType, IRotomecaArray infos, string from, params string[] messages) : base(null, infos, from, messages)
    {
      LeftItem = leftItem;
      RightItem = rightItem;
      CalculationType = calculationType;
    }

    public RotomecaCalculationNumberException(dynamic leftItem, dynamic rightItem, E calculationType, Exception inner, string from, params string[] messages) : base(null, inner, from, messages)
    {
      LeftItem = leftItem;
      RightItem = rightItem;
      CalculationType = calculationType;
    }

    public override CodeErreur CodeErreur => CodeErreur.NUMBER_CALCULATION_EXCEPTION;
  }

}
