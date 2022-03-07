using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class CouleurRVBA<CouleurMode> : Classes.Abstraite.ACouleurRVBA<CouleurMode> where CouleurMode : Interfaces.ICouleurMode
    {
        public CouleurRVBA(double r, double v, double b, double a, CouleurMode config) : base(r, v, b, a, config)
        {
        }

        public CouleurRVBA(Structures.Couleur rvb, double a, CouleurMode config) : base(rvb, a, config)
        {
        }

        public CouleurRVBA(Structures.CouleurRVBA rvba, CouleurMode config) : base(rvba, config)
        {
        }
    }
}
