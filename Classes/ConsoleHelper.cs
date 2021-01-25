using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public static class ConsoleHelper
  {
    public static ConsoleColor DEFAULT_TEXT_COLOR = ConsoleColor.White;

    public static void WriteLine(params string[] vs)
    {
      Console.WriteLine(string.Join(" ", vs));
    }

    public static void WriteLine(ConsoleColor textColor, params string[] vs)
    {
      Console.ForegroundColor = textColor;
      Console.WriteLine(string.Join(" ", vs));
      Console.ForegroundColor = DEFAULT_TEXT_COLOR;
    }

    public static void Error(params string[] vs)
    {
      WriteLine(ConsoleColor.Red, vs);
    }

    public static void Warning(params string[] vs)
    {
      WriteLine(ConsoleColor.Yellow, vs);
    }

    public static void Ok(params string[] vs)
    {
      WriteLine(ConsoleColor.Green, vs);
    }

  }

}
