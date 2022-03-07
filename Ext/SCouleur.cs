using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public static class CouleursExt
    {
        public static Classes.Abstraite.ACouleurRVBA<CouleurMode> ToRVBA<CouleurMode>(this Classes.Abstraite.ACouleurRVB<CouleurMode> @this, double? alpha = null)
            where CouleurMode : Interfaces.ICouleurMode
        {
            return new CouleurRVBA<CouleurMode>(@this.Rouge, @this.Vert, @this.Bleu, alpha ?? @this.RecupConfig().Max, @this.RecupConfig());
        }

        public static CouleurJavascript EnCouleurJavascript(this Couleur couleur)
        {
            return new CouleurJavascript(couleur.Rouge, couleur.Vert, couleur.Bleu, CouleurModeRVB255Alpha1.ALPHA_MAX * couleur.Alpha / couleur.RecupConfig().Max); 
        }

        public static System.Drawing.Color EnCouleurSysteme(this Classes.Abstraite.ACouleurRVBA<CouleurMode255> @this)
        {
            return System.Drawing.Color.FromArgb((int)@this.Rouge, (int)@this.Vert, (int)@this.Bleu, (int)@this.Alpha);
        }

        public static Couleur EnCouleur(this System.Drawing.Color @this)
        {
            return new Couleur(@this.R, @this.G, @this.B, @this.A);
        }
    }
}
