using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
  public enum CodeErreur
  {
    NUMBER_CALCULATION_EXCEPTION = 1,
    EXCEL_SAVE_ERROR = 500,
  }

  public static class StCodeErreur
  {
    public static int Code(this CodeErreur codeErreur)
    {
      return (int)codeErreur;
    }
  }

}
