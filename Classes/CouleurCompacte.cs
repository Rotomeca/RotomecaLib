using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class CouleurCompacte : CouleurRVBA<CouleurMode1>
    {
        public CouleurCompacte(double r, double v, double b, double a) : base(r, v, b, a, new CouleurMode1())
        {
        }
    }
}
