using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class CouleurRVB : CouleurRVB<CouleurMode255>
    {
        public CouleurRVB(double r, double v, double b) : base(r, v, b, new CouleurMode255())
        {
        }
    }
}
