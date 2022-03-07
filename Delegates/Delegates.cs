using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Delegates
{
  public delegate TCle EnCleEncyclopedie<TOriginal, TCle>(TOriginal original);
  public delegate Valeur EnValueEncyclopedie<TOriginal, Valeur>(TOriginal original);
  public delegate bool VerificationMinMax<T>(T valeur, T minMax);
}
