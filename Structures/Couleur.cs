using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Structures
{
    /// <summary>
    /// Représentation d'une couleur à 3 composantes
    /// </summary>
    public struct Couleur : IEquatable<Couleur>
    {
        double _r;
        double _g;
        double _b;

        /// <summary>
        /// Composante rouge
        /// </summary>
        public double Rouge { get => (int)_r; set => _r = value; }
        /// <summary>
        /// Composante bleue
        /// </summary>
        public double Bleu { get => (int)_b; set => _b = value; }
        /// <summary>
        /// Composante verte
        /// </summary>
        public double Vert { get => (int)_g; set => _g = value; }

        /// <summary>
        /// Création d'une représentation de couleur RVB
        /// </summary>
        /// <param name="r">Rouge</param>
        /// <param name="v">Vert</param>
        /// <param name="b">Bleu</param>
        public Couleur(double r, double v, double b)
        {
            _r = r;
            _g = v;
            _b = b;
        }

        //public string Hexadecimal
        //{
        //  get
        //  {
        //    System.Drawing.Color myColor = System.Drawing.Color.FromArgb(Alpha, Rouge, Vert, Bleu);
        //    return "#" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
        //  }
        //}

        public override string ToString()
        {
            if (_r == 255 && _g == 255 && _b == 255)
            return "white";
            else if (_r == 255 && _g == 0 && _b == 0)
            return "red";
            else if (_r == 0 && _g == 255 && _b == 0)
            return "green";
            else if (_r == 0 && _g == 0 && _b == 255)
            return "blue";
            else if (_r == 0 && _g == 0 && _b == 0)
            return "black";
            return $"[{_r}, {_g}, {_b}]";
        }

        public override bool Equals(object obj)
        {
            return obj is Couleur couleur && Equals(couleur);
        }

        public bool Equals(Couleur other)
        {
            return Rouge == other.Rouge &&
                   Bleu == other.Bleu &&
                   Vert == other.Vert;
        }

        public override int GetHashCode()
        {
            int hashCode = -1667957348;
            hashCode = hashCode * -1521134295 + Rouge.GetHashCode();
            hashCode = hashCode * -1521134295 + Bleu.GetHashCode();
            hashCode = hashCode * -1521134295 + Vert.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Couleur left, Couleur right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Couleur left, Couleur right)
        {
            return !(left == right);
        }
    }

    /// <summary>
    /// Représentation d'une couleur à 4 composantes
    /// </summary>
    public struct CouleurRVBA : IEquatable<CouleurRVBA>
    {
        Couleur _rvb;
        double _alpha;

        /// <summary>
        /// Composante rouge
        /// </summary>
        public double Rouge { get => (int)_rvb.Rouge; set => _rvb.Rouge = value; }
        /// <summary>
        /// Composante bleue
        /// </summary>
        public double Bleu { get => (int)_rvb.Bleu; set => _rvb.Bleu = value; }
        /// <summary>
        /// Composante verte
        /// </summary>
        public double Vert { get => (int)_rvb.Vert; set => _rvb.Vert = value; }
        /// <summary>
        /// Composante d'opacitée
        /// </summary>
        public double Alpha { get => (int)_alpha; set => _alpha = value; }

        /// <summary>
        /// Création d'une représentation de couleur RVBA
        /// </summary>
        /// <param name="r">Rouge</param>
        /// <param name="v">Vert</param>
        /// <param name="b">Bleu</param>
        /// <param name="alpha">Alpha</param>
        public CouleurRVBA(double r, double v, double b, double alpha)
        {
            _rvb = new Couleur(r, v, b);
            _alpha = alpha;
        }

        /// <summary>
        /// Création d'une représentation de couleur RVBA
        /// </summary>
        /// <param name="rvb">Rouge/Bleu/Vert</param>
        /// <param name="alpha">Alpha</param>
        public CouleurRVBA(Couleur rvb, double alpha)
        {
            _rvb = rvb;
            _alpha = alpha;
        }

        public override string ToString()
        {
            string _retour = _rvb.ToString();

            if (_retour.Contains("[")) return $"[{_rvb.Rouge}, {_rvb.Bleu}, {_rvb.Vert}, {_alpha}]";

            return _retour;
        }

        public override bool Equals(object obj)
        {
            return obj is CouleurRVBA rVBA && Equals(rVBA);
        }

        public bool Equals(CouleurRVBA other)
        {
            return Rouge == other.Rouge &&
                   Bleu == other.Bleu &&
                   Vert == other.Vert &&
                   Alpha == other.Alpha;
        }

        public override int GetHashCode()
        {
            int hashCode = 1344658503;
            hashCode = hashCode * -1521134295 + Rouge.GetHashCode();
            hashCode = hashCode * -1521134295 + Bleu.GetHashCode();
            hashCode = hashCode * -1521134295 + Vert.GetHashCode();
            hashCode = hashCode * -1521134295 + Alpha.GetHashCode();
            return hashCode;
        }

        public static implicit operator Couleur(CouleurRVBA rvba)
        {
            return rvba._rvb;
        }

        public static bool operator ==(CouleurRVBA left, CouleurRVBA right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CouleurRVBA left, CouleurRVBA right)
        {
            return !(left == right);
        }
    }
}
