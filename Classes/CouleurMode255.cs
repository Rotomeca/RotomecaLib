using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    /// <summary>
    /// Toutes la valeurs sont entre 255 et 0.
    /// </summary>
    public class CouleurMode255 : Classes.Abstraite.ACouleurMode
    {
        public const double MIN = 0;
        public const double MAX = 255;
        public CouleurMode255() : base(0, 255)
        {
        }
    }
}
