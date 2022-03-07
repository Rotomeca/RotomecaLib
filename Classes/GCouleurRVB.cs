using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class CouleurRVB<CouleurMode> : Classes.Abstraite.ACouleurRVB<CouleurMode> where CouleurMode : Interfaces.ICouleurMode
    {
        public CouleurRVB(double r, double v, double b, CouleurMode config) : base(r, v, b, config)
        {
        }

        public override string Hexadecimal
        {
            get
            {
                System.Drawing.Color myColor = System.Drawing.Color.FromArgb(255, (int)DoubleToJavascript(Rouge), (int)DoubleToJavascript(Vert), (int)DoubleToJavascript(Bleu));
                return "#" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
            }
        }

        public override string ToJavascript()
        {
            return $"rgb({DoubleToJavascript(Rouge)}, {DoubleToJavascript(Vert)}, {DoubleToJavascript(Bleu)})";
        }
    }
}
