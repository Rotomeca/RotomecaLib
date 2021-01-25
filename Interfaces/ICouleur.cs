using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotomecaLib.Interfaces
{
  public interface ICouleur
  {
    int Rouge { get; set; }
    int Bleu { get; set; }
    int Vert { get; set; }
    int Alpha { get; set; }
    string Hexadecimal { get; }
  }
}
