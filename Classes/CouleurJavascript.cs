using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class CouleurJavascript : CouleurRVBA<CouleurModeRVB255Alpha1>, IEquatable<CouleurJavascript>
    {
        public CouleurJavascript(double r, double v, double b, double a) : base(r, v, b, a, new CouleurModeRVB255Alpha1())
        {
        }

        public CouleurJavascript(uint r, uint v, uint b) : base(r, v, b, CouleurModeRVB255Alpha1.ALPHA_MAX, new CouleurModeRVB255Alpha1())
        {
        }

        public CouleurJavascript(int r, int v, int b, int a) : base(r, v, b, a, new CouleurModeRVB255Alpha1())
        {
        }

        public CouleurJavascript(double r, double v, double b) : base(r, v, b, CouleurModeRVB255Alpha1.ALPHA_MAX, new CouleurModeRVB255Alpha1())
        {
        }

        /// <summary>
        /// Créer une couleur RGBA à partir d'un string HéxaDecimal.
        /// </summary>
        /// <param name="hexa">Couleur en hexadecimal</param>
        /// <param name="alpha">Composant Alpha (de 0 à 255)</param>
        public CouleurJavascript(string hexa) : base(0, 0, 0, 0, new CouleurModeRVB255Alpha1())
        {
            var c = Divers.HexadecimalEnRVBA(hexa, CouleurModeRVB255Alpha1.ALPHA_MAX);
            Rouge = c.Rouge;
            Bleu = c.Bleu;
            Vert = c.Vert;
            Alpha = CouleurModeRVB255Alpha1.ALPHA_MAX * c.Alpha / 255;
        }

        private static CouleurJavascript Aleatoire(double alpha_aleatoire = CouleurModeRVB255Alpha1.ALPHA_MAX)
        {
            return new CouleurJavascript(
                RotomecaLib.Aleatoire.Nombre((int)CouleurModeRVB255Alpha1.MIN, (int)CouleurModeRVB255Alpha1.MAX),
                RotomecaLib.Aleatoire.Nombre((int)CouleurModeRVB255Alpha1.MIN, (int)CouleurModeRVB255Alpha1.MAX),
                RotomecaLib.Aleatoire.Nombre((int)CouleurModeRVB255Alpha1.MIN, (int)CouleurModeRVB255Alpha1.MAX),
                alpha_aleatoire);
        }

        public static CouleurJavascript ToutAleatoire()
        {
            return Aleatoire(RotomecaLib.Aleatoire.Nombre());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CouleurJavascript);
        }

        public bool Equals(CouleurJavascript other)
        {
            return other != null &&
                   base.Equals(other) &&
                   Rouge == other.Rouge &&
                   Bleu == other.Bleu &&
                   Vert == other.Vert &&
                   Alpha == other.Alpha;
        }

        public override int GetHashCode()
        {
            int hashCode = -2034473043;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Rouge.GetHashCode();
            hashCode = hashCode * -1521134295 + Bleu.GetHashCode();
            hashCode = hashCode * -1521134295 + Vert.GetHashCode();
            hashCode = hashCode * -1521134295 + Alpha.GetHashCode();
            return hashCode;
        }

        public static CouleurJavascript ROUGE => new CouleurJavascript(CouleurModeRVB255Alpha1.MAX, CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MIN);
        public static CouleurJavascript BLEU => new CouleurJavascript(CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MAX);
        public static CouleurJavascript VERT => new CouleurJavascript(CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MAX, CouleurModeRVB255Alpha1.MIN);
        public static CouleurJavascript NOIR => new CouleurJavascript(CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MIN);
        public static CouleurJavascript BLANC => new CouleurJavascript(CouleurModeRVB255Alpha1.MAX, CouleurModeRVB255Alpha1.MAX, CouleurModeRVB255Alpha1.MAX);
        public static CouleurJavascript INVISIBLE => new CouleurJavascript(CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.MIN, CouleurModeRVB255Alpha1.ALPHA_MIN);


        public static implicit operator Couleur(CouleurJavascript couleur)
        {
            return new Couleur(couleur.Rouge, couleur.Vert, couleur.Bleu, CouleurMode255.MAX * couleur.Alpha / CouleurModeRVB255Alpha1.ALPHA_MAX);
        }

        public static bool operator ==(CouleurJavascript left, CouleurJavascript right)
        {
            return EqualityComparer<CouleurJavascript>.Default.Equals(left, right);
        }

        public static bool operator !=(CouleurJavascript left, CouleurJavascript right)
        {
            return !(left == right);
        }
    }
}
