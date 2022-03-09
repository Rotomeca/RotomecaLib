using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public static class Aleatoire
    {
        static Random _random = null;
        public static Random Alea
        {
            get
            {
                if (_random == null) _random = new Random();
                return _random;
            }
        }

        public static int Nombre(int min, int max, int seed)
        {
            Random random = new Random(seed);
            return random.Next(min, max);
        }

        public static int Nombre(int min, int max)
        {
            return Alea.Next(min, max);
        }

        public static double Nombre(int seed)
        {
            Random random = new Random(seed);
            return random.NextDouble();
        }

        public static double Nombre()
        {
            return Alea.NextDouble();
        }
    }
}
