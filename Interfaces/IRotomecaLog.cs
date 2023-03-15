using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Interfaces
{
  public interface IRotomecaLog
  {
    void WriteLine(ELogSeverity severity, params string[] messages);
    void WriteLine(ELogSeverity severity, params object[] messages);

    void WriteLine(ELogSeverity severity, string context, params string[] messages);
    void WriteLine(ELogSeverity severity, string context, params object[] messages);
  }

  public interface IRotomecaLogging : IRotomecaLog
  {
    void Info(params string[] messages);
    void Debug(params string[] messages);
    void Warning(params string[] messages);
    void Error(params string[] messages);
    void Fatal(params string[] messages);

    void Info(params object[] messages);
    void Debug(params object[] messages);
    void Warning(params object[] messages);
    void Error(params object[] messages);
    void Fatal(params object[] messages);
  }

  public interface IRotomecaLoggingEx : IRotomecaLogging
  {
    void Info(string context, params string[] messages);
    void Debug(string context, params string[] messages);
    void Warning(string context, params string[] messages);
    void Error(string context, params string[] messages);
    void Fatal(string context, params string[] messages);

    void Info(string context, params object[] messages);
    void Debug(string context, params object[] messages);
    void Warning(string context, params object[] messages);
    void Error(string context, params object[] messages);
    void Fatal(string context, params object[] messages);
  }

}
