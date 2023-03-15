using System;

namespace RotomecaLib
{
  [AttributeUsage(AttributeTargets.Class)]
  public class RotomecaLoggingAttribute : Attribute
  {
    public Type LogType { get; }

    public RotomecaLoggingAttribute(Type logType)
    {
      if (!typeof(Interfaces.IRotomecaLog).IsAssignableFrom(logType))
      {
        throw new ArgumentException($"{logType.Name} does not inherit from IRotomecaLog interface");
      }

      LogType = logType;
    }
  }
}
