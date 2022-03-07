using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Classes.Abstraite
{
    public abstract class ACouleurMode : Interfaces.ICouleurMode
    {
        private DoubleMinMax _rouge;
        private DoubleMinMax _vert;
        private DoubleMinMax _bleu;
        private DoubleMinMax _alpha;
        protected double _min;
        protected double _max;

        public double Min => _min;
        public double Max => _max;

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

        public DoubleMinMax RecupAlpha()
        {
            return _alpha;
        }

        public DoubleMinMax RecupBleu()
        {
            return _bleu;
        }

        public DoubleMinMax RecupRouge()
        {
            return _rouge;
        }

        public DoubleMinMax RecupVert()
        {
            return _vert;
        }
    }
}
