using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes.Abstraite
{
    /// <summary>
    /// Mode de couleur pour les classes de couleurs
    /// </summary>
    public abstract class ACouleurMode : Interfaces.ICouleurMode
    {
        protected DoubleMinMax _rouge;
        protected DoubleMinMax _vert;
        protected DoubleMinMax _bleu;
        protected DoubleMinMax _alpha;
        private double _min;
        private double _max;

        /// <summary>
        /// Minimum de l'instance
        /// </summary>
        public double Min => _min;
        /// <summary>
        /// Maximum de l'instance
        /// </summary>
        public double Max => _max;

        /// <summary>
        /// Mode de couleur de l'instance.
        /// </summary>
        /// <param name="min">Minimum de l'instance</param>
        /// <param name="max">Maximum de l'instance</param>
        public ACouleurMode(double min, double max)
        {
            _Setup(min, max);
        }

        private void _Setup(double min, double max)
        {
            _min = min;
            _max = max;
            _rouge = new DoubleMinMax(min, max);
            _vert = new DoubleMinMax(min, max);
            _bleu = new DoubleMinMax(min, max);
            _alpha = new DoubleMinMax(min, max);
        }

        /// <summary>
        /// Récupère le min et le max de l'alpha
        /// </summary>
        /// <returns><see cref="DoubleMinMax"/> de l'alpha</returns>
        public DoubleMinMax RecupAlpha()
        {
            return _alpha;
        }

        /// <summary>
        /// Récupère le min et le max du bleu
        /// </summary>
        /// <returns><see cref="DoubleMinMax"/> du bleu</returns>
        public DoubleMinMax RecupBleu()
        {
            return _bleu;
        }

        /// <summary>
        /// Récupère le min et le max du bleu
        /// </summary>
        /// <returns><see cref="DoubleMinMax"/> du rouge</returns>
        public DoubleMinMax RecupRouge()
        {
            return _rouge;
        }

        /// <summary>
        /// Récupère le min et le max du vert
        /// </summary>
        /// <returns><see cref="DoubleMinMax"/> du vert</returns>
        public DoubleMinMax RecupVert()
        {
            return _vert;
        }

        public DoubleMinMax RecupRouge(double val)
        {
            _rouge.Valeur = val;
            return RecupRouge();
        }

        public DoubleMinMax RecupVert(double val)
        {
            _vert.Valeur = val;
            return RecupVert();
        }

        public DoubleMinMax RecupBleu(double val)
        {
            _bleu.Valeur = val;
            return RecupBleu();
        }

        public DoubleMinMax RecupAlpha(double val)
        {
            _alpha.Valeur = val;
            return RecupAlpha();
        }
    }
}
