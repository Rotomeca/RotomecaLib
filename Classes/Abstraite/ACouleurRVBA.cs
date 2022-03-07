using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes.Abstraite
{
    public abstract class ACouleurRVBA<CouleurMode> : ACouleurRVB<CouleurMode>, Interfaces.IRVBACouleur, IEquatable<ACouleurRVBA<CouleurMode>> where CouleurMode : Interfaces.ICouleurMode
    {
        double _alpha;

        public double Alpha { get => _alpha; set => _alpha = RecupConfig().RecupAlpha(value).Valeur; }

        public ACouleurRVBA(double r, double v, double b, double a, CouleurMode config) : base(r, v, b, config)
        {
            Alpha = a;    
        }

        public ACouleurRVBA(Structures.Couleur rvb, double a, CouleurMode config) : base(rvb.Rouge, rvb.Vert, rvb.Bleu, config)
        {
            Alpha = a;
        }

        public ACouleurRVBA(Structures.CouleurRVBA rvba, CouleurMode config) : base(rvba.Rouge, rvba.Vert, rvba.Bleu, config)
        {
            Alpha = rvba.Alpha;
        }

        public override string Hexadecimal
        {
            get
            {
                System.Drawing.Color myColor = System.Drawing.Color.FromArgb((int)Alpha, (int)DoubleToJavascript(Rouge), (int)DoubleToJavascript(Vert), (int)DoubleToJavascript(Bleu));
                return "#" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2") + myColor.A.ToString("X2");
            }
        }

        public override string ToJavascript()
        {
            return $"rgba({DoubleToJavascript(Rouge)}, {DoubleToJavascript(Vert)}, {DoubleToJavascript(Bleu)}, {Alpha/RecupConfig().Max})";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ACouleurRVBA<CouleurMode>);
        }

        public bool Equals(ACouleurRVBA<CouleurMode> other)
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

        public static bool operator ==(ACouleurRVBA<CouleurMode> left, ACouleurRVBA<CouleurMode> right)
        {
            return EqualityComparer<ACouleurRVBA<CouleurMode>>.Default.Equals(left, right);
        }

        public static bool operator ==(ACouleurRVBA<CouleurMode> left, ACouleurRVB<CouleurMode> right)
        {
            return false;
        }

        public static bool operator !=(ACouleurRVBA<CouleurMode> left, ACouleurRVB<CouleurMode> right)
        {
            return !(left == right);
        }

        public static bool operator !=(ACouleurRVBA<CouleurMode> left, ACouleurRVBA<CouleurMode> right)
        {
            return !(left == right);
        }

        public static implicit operator Structures.CouleurRVBA(ACouleurRVBA<CouleurMode> a)
        {
            return new Structures.CouleurRVBA(a.Rouge, a.Vert, a.Bleu, a.Alpha);
        }
    }
}
