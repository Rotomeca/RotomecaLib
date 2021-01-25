using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Structures
{
  public struct Couleur : Interfaces.ICouleur
  {
    uint _r;
    uint _g;
    uint _b;
    uint _alpha;

    public int Rouge { get => (int)_r; set => _r = _Set(value); }
    public int Bleu { get => (int)_b; set => _b = _Set(value); }
    public int Vert { get => (int)_g; set => _g = _Set(value); }
    public int Alpha { get => (int)_alpha; set => _alpha = _Set(value); }

    public string Hexadecimal
    {
      get
      {
        System.Drawing.Color myColor = System.Drawing.Color.FromArgb(Alpha, Rouge, Vert, Bleu);
        return "#" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
      }
    }

    uint _Set(int nouvelleCouleur)
    {
      if (nouvelleCouleur < 0)
        return 0;
      else if (nouvelleCouleur > 255)
        return 255;
      return (uint)nouvelleCouleur;
    }

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
      return $"[{_r}, {_g}, {_b}, {_alpha}]";
    }
    //public Couleur(uint rouge, uint vert, uint bleu)
    //{
    //}
  }
}
