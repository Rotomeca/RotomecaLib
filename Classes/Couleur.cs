using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class Couleur : CouleurRVBA<CouleurMode255>, IEquatable<Couleur>
    {
        public Couleur(uint r, uint v, uint b, uint a) : base(r, v, b, a, new CouleurMode255())
        {
        }

        public Couleur(uint r, uint v, uint b) : base(r, v, b, CouleurMode255.MAX, new CouleurMode255())
        {
        }

        public Couleur(int r, int v, int b, int a) : base(r, v, b, a, new CouleurMode255())
        {
        }

        public Couleur(double r, double v, double b, double a) : base(r, v, b, a, new CouleurMode255())
        {
        }

        public Couleur(double r, double v, double b) : base(r, v, b, CouleurMode255.MAX, new CouleurMode255())
        {
        }

        /// <summary>
        /// Créer une couleur RGBA à partir d'un string HéxaDecimal.
        /// </summary>
        /// <param name="hexa">Couleur en hexadecimal</param>
        /// <param name="alpha">Composant Alpha (de 0 à 255)</param>
        public Couleur(string hexa) : base(0, 0, 0, 0, new CouleurMode255())
        {
            var c = Divers.HexadecimalEnRVBA(hexa, CouleurMode255.MAX);
            Rouge = c.Rouge;
            Bleu = c.Bleu;
            Vert = c.Vert;
            Alpha = c.Alpha;
        }

        private static Couleur Aleatoire(uint aleatoire = (int)CouleurMode255.MAX)
        {
            return new Couleur(
                RotomecaLib.Aleatoire.Nombre((int)CouleurMode255.MIN, (int)CouleurMode255.MAX),
                RotomecaLib.Aleatoire.Nombre((int)CouleurMode255.MIN, (int)CouleurMode255.MAX),
                RotomecaLib.Aleatoire.Nombre((int)CouleurMode255.MIN, (int)CouleurMode255.MAX),
                aleatoire);
        }

        public static Couleur ToutAleatoire()
        {
            return Aleatoire((uint)RotomecaLib.Aleatoire.Nombre((int)CouleurMode255.MIN, (int)CouleurMode255.MAX));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Couleur);
        }

        public bool Equals(Couleur other)
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
      int hashCode = -1170380362;
      hashCode = hashCode * -1521134295 + base.GetHashCode();
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Hexadecimal);
      return hashCode;
    }

    public static Couleur ROUGE => new Couleur(CouleurMode255.MAX, CouleurMode255.MIN, CouleurMode255.MIN);
        public static Couleur BLEU => new Couleur(CouleurMode255.MIN, CouleurMode255.MIN, CouleurMode255.MAX);
        public static Couleur VERT => new Couleur(CouleurMode255.MIN, CouleurMode255.MAX, CouleurMode255.MIN);
        public static Couleur NOIR => new Couleur(CouleurMode255.MIN, CouleurMode255.MIN, CouleurMode255.MIN);
        public static Couleur BLANC => new Couleur(CouleurMode255.MAX, CouleurMode255.MAX, CouleurMode255.MAX);
        public static Couleur INVISIBLE => new Couleur(CouleurMode255.MIN, CouleurMode255.MIN, CouleurMode255.MIN, CouleurMode255.MIN);

        public static bool operator ==(Couleur left, Couleur right)
        {
            return EqualityComparer<Couleur>.Default.Equals(left, right);
        }

        public static bool operator !=(Couleur left, Couleur right)
        {
            return !(left == right);
        }
    }
}
