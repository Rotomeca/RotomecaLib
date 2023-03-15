using RotomecaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Log
{
  public class RotomecaLog : IRotomecaLoggingEx
  {
    public RotomecaLog() { }

    public void Debug(params string[] messages)
    {
      WriteLine(ELogSeverity.DEBUG, messages);
    }

    public void Debug(params object[] messages)
    {
      WriteLine(ELogSeverity.DEBUG, messages);
    }

    public void Error(params string[] messages)
    {
      WriteLine(ELogSeverity.ERROR, messages);
    }

    public void Error(params object[] messages)
    {
      WriteLine(ELogSeverity.ERROR, messages);
    }

    public void Fatal(params string[] messages)
    {
      WriteLine(ELogSeverity.FATAL, messages);
    }

    public void Fatal(params object[] messages)
    {
      WriteLine(ELogSeverity.FATAL, messages);
    }

    public void Info(params string[] messages)
    {
      WriteLine(ELogSeverity.INFO, messages);
    }

    public void Info(params object[] messages)
    {
      WriteLine(ELogSeverity.INFO, messages);
    }

    public void Warning(params string[] messages)
    {
      WriteLine(ELogSeverity.WARNING, messages);
    }

    public void Warning(params object[] messages)
    {
      WriteLine(ELogSeverity.WARNING, messages);
    }

    private string _WriteLine(ELogSeverity severity)
    {
      switch (severity)
      {

        case ELogSeverity.DEBUG:
          return "--";
        case ELogSeverity.WARNING:
          return "/!\\";
        case ELogSeverity.ERROR:
          return "###";
        case ELogSeverity.FATAL:
          return "!###";
        case ELogSeverity.INFO:
        default:
          return "";
      }
    }

    public void WriteLine(ELogSeverity severity, params string[] messages)
    {
      string sev = _WriteLine(severity);
      List<string> message = new List<string>(messages);
      message.Insert(0, sev);

      Console.WriteLine(string.Join(" ", message).Replace($"{sev} ", sev));
    }

    public void WriteLine(ELogSeverity severity, params object[] messages)
    {
      WriteLine(severity, messages.Select(x => x.ToString()).ToArray());
    }

    public void WriteLine(ELogSeverity severity, string context, params string[] messages)
    {
      var tmp = new List<string>(messages);
      tmp.Insert(0, $"[${context}]");
      WriteLine(severity, tmp.ToArray());
    }

    public void WriteLine(ELogSeverity severity, string context, params object[] messages)
    {
      WriteLine(severity, context, messages.Select(x => x.ToString()).ToArray());
    }

    public void Info(string context, params string[] messages)
    {
      WriteLine(ELogSeverity.INFO, context, messages);
    }

    public void Debug(string context, params string[] messages)
    {
      WriteLine(ELogSeverity.DEBUG, context, messages);
    }

    public void Warning(string context, params string[] messages)
    {
      WriteLine(ELogSeverity.WARNING, context, messages);
    }

    public void Error(string context, params string[] messages)
    {
      WriteLine(ELogSeverity.ERROR, context, messages);
    }

    public void Fatal(string context, params string[] messages)
    {
      WriteLine(ELogSeverity.FATAL, context, messages);
    }

    public void Info(string context, params object[] messages)
    {
      WriteLine(ELogSeverity.INFO, context, messages);
    }

    public void Debug(string context, params object[] messages)
    {
      WriteLine(ELogSeverity.DEBUG, context, messages);
    }

    public void Warning(string context, params object[] messages)
    {
      WriteLine(ELogSeverity.WARNING, context, messages);
    }

    public void Error(string context, params object[] messages)
    {
      WriteLine(ELogSeverity.ERROR, context, messages);
    }

    public void Fatal(string context, params object[] messages)
    {
      WriteLine(ELogSeverity.FATAL, context, messages);
    }
  }
}
