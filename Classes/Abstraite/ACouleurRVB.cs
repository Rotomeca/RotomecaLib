using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes.Abstraite
{
    public abstract class ACouleurRVB<CouleurMode> : Interfaces.IRVBCouleur, IEquatable<ACouleurRVB<CouleurMode>> where CouleurMode : Interfaces.ICouleurMode
    {
        Structures.Couleur _rvb;
        CouleurMode _config;
        public double Rouge { get => _rvb.Rouge; set => _rvb.Rouge = _config.RecupRouge(value).Valeur; }
        public double Bleu { get => _rvb.Bleu; set => _rvb.Bleu = _config.RecupBleu(value).Valeur; }
        public double Vert { get => _rvb.Vert; set => _rvb.Vert = _config.RecupVert(value).Valeur; }
        public abstract string Hexadecimal { get; }

        public ACouleurRVB(double r, double v, double b, CouleurMode config)
        {
            _config = config;
            Rouge = r;
            Vert = v;
            Bleu = b;
        }

        public ACouleurRVB(Structures.Couleur rvb, CouleurMode config)
        {
            _config = config;
            Rouge = rvb.Rouge;
            Vert = rvb.Vert;
            Bleu = rvb.Bleu;
        }

        public CouleurMode RecupConfig()
        {
            return _config;
        }

        public abstract string ToJavascript();

        protected double DoubleToJavascript(double val)
        {
            return 255 * val / RecupConfig().Max;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ACouleurRVB<CouleurMode>);
        }

        public bool Equals(ACouleurRVB<CouleurMode> other)
        {
            return other != null &&
                   Rouge == other.Rouge &&
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

        public static implicit operator Structures.Couleur(ACouleurRVB<CouleurMode> couleurRVB)
        {
            return couleurRVB._rvb;
        }

        public static bool operator ==(ACouleurRVB<CouleurMode> left, ACouleurRVB<CouleurMode> right)
        {
            return EqualityComparer<ACouleurRVB<CouleurMode>>.Default.Equals(left, right);
        }

        public static bool operator !=(ACouleurRVB<CouleurMode> left, ACouleurRVB<CouleurMode> right)
        {
            return !(left == right);
        }
    }
}
