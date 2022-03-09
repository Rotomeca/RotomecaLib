using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public class MinMax<T> : RotomecaObject, Interfaces.IMinMax<T>
    {
        private T _valeur;
        protected Delegates.VerificationMinMax<T> _verificationMin;
        protected Delegates.VerificationMinMax<T> _verificationMax;

        public T Min { get; protected set; }
        public T Max { get; protected set; }
        public T Valeur
        {
            get => _valeur;
            set
            {
                if (_verificationMin(value, Min)) _valeur = Min;
                else if (_verificationMax(value, Max)) _valeur = Max;
                else _valeur = value;
            }
        }

        protected MinMax()
        {}

        public MinMax (T min, T max, T valeur, Delegates.VerificationMinMax<T> verificationMin, Delegates.VerificationMinMax<T> verificationMax)
        {
            Min = min;
            Max = max;
            _valeur = valeur;
            _verificationMin = verificationMin;
            _verificationMax = verificationMax;
            Valeur = _valeur;
        }

        public static implicit operator T(MinMax<T> minMax)
        {
            return minMax.Valeur;
        }

        public object GetMin()
        {
            return Min;
        }

        public object GetMax()
        {
            return Max;
        }

        public object GetValeur()
        {
            return Valeur;
        }
    }

    public abstract class MinMaxVerif<T> : MinMax<T> where T : IComparable<T>
    {
        public MinMaxVerif() : base()
        { }

        public MinMaxVerif(T min, T max, T valeur)
        {
            _Setup(min, max, valeur);
        }

        protected virtual MinMaxVerif<T> _SetupFunctions()
        {
            _verificationMin = (_val, _min) => _val.CompareTo(_min) < 0;
            _verificationMax = (_val, _max) => _val.CompareTo(_max) > 0;
            return this;
        }

        protected virtual MinMaxVerif<T> _Setup(T min, T max, T valeur)
        {
            _SetupFunctions();
            Min = min;
            Max = max;
            Valeur = valeur;
            return this;
        }

        public static implicit operator T(MinMaxVerif<T> minMax)
        {
            return minMax.Valeur;
        }
    }

    public class IntMinMax : MinMaxVerif<int>
    {
        public IntMinMax() : base(0, 100, 0)
        {}

        public IntMinMax(int min, int max, int valeur) : base(min, max, valeur)
        { }

        public static implicit operator int(IntMinMax minMax)
        {
            return minMax.Valeur;
        }
    }

    /// <summary>
    /// Représente un double entre deux valeurs.
    /// </summary>
    public class DoubleMinMax : MinMaxVerif<double>
    {
        /// <summary>
        /// Création d'une valeur de 0 entre 0 et 100.
        /// </summary>
        public DoubleMinMax() : base(0, 100, 0)
        { }

        /// <summary>
        /// Création d'un double entre un valeur minimum et une valeur maximum.
        /// </summary>
        /// <param name="min">Valeur minimum que pourra prendre la valeur.</param>
        /// <param name="max">Valeur maximum que pourra prendre la valeur.</param>
        public DoubleMinMax(double min, double max) : base(min, max, 0)
        { }

        /// <summary>
        /// Création d'un double entre un valeur minimum et une valeur maximum.
        /// </summary>
        /// <param name="min">Valeur minimum que pourra prendre la valeur.</param>
        /// <param name="max">Valeur maximum que pourra prendre la valeur.</param>
        /// <param name="valeur">Valeur qui sera limitée.</param>
        public DoubleMinMax(double min, double max, double valeur) : base(min, max, valeur)
        { }

        protected override MinMaxVerif<double> _SetupFunctions()
        {
            _verificationMin = (_val, _min) => _val < _min;
            _verificationMax = (_val, _max) => _val > _max;
            return this;
        }

        /// <summary>
        /// Convertit en double.
        /// </summary>
        /// <param name="minMax">Valeur à convertir en double</param>
        public static implicit operator double(DoubleMinMax minMax)
        {
            return minMax.Valeur;
        }
    }
}
