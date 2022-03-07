using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib
{
    public static class Divers
    {
        public static int HexadecimalEnDecimal(string hex)
        {
            hex = hex.ToUpper();

            int hexLength = hex.Length;
            double dec = 0;

            for (int i = 0; i < hexLength; ++i)
            {
                byte b = (byte)hex[i];

                if (b >= 48 && b <= 57)
                    b -= 48;
                else if (b >= 65 && b <= 70)
                    b -= 55;

                dec += b * Math.Pow(16, ((hexLength - i) - 1));
            }

            return (int)dec;
        }

        public static Structures.Couleur HexadecimalEnRVB(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Remove(0, 1);

            byte r = (byte)HexadecimalEnDecimal(hex.Substring(0, 2));
            byte g = (byte)HexadecimalEnDecimal(hex.Substring(2, 2));
            byte b = (byte)HexadecimalEnDecimal(hex.Substring(4, 2));

            return new Structures.Couleur(r, g, b);
        }

        public static Structures.CouleurRVBA HexadecimalEnRVBA(string hex, double alphaMax = 255)
        {
            if (hex.StartsWith("#"))
                hex = hex.Remove(0, 1);

            byte r = (byte)HexadecimalEnDecimal(hex.Substring(0, 2));
            byte g = (byte)HexadecimalEnDecimal(hex.Substring(2, 2));
            byte b = (byte)HexadecimalEnDecimal(hex.Substring(4, 2));
            byte? a = null; 

            try
            {
                a = (byte)HexadecimalEnDecimal(hex.Substring(6, 2));
            }
            catch (Exception)
            {
            }

            return new Structures.CouleurRVBA(r, g, b, a ?? alphaMax);
        }
    }
}
