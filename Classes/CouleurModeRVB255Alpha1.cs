using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class CouleurModeRVB255Alpha1 : Classes.Abstraite.ACouleurMode
    {
        public const double MIN = 0;
        public const double MAX = 255;
        public const double ALPHA_MIN = MIN;
        public const double ALPHA_MAX = 1;
        public CouleurModeRVB255Alpha1() : base(MIN, MAX)
        {
            _alpha = new DoubleMinMax(ALPHA_MIN, ALPHA_MAX);
        }
    }
}
