using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Interfaces
{
  public interface IRetour
  {
    Exception Erreur
    {
      get;
    }

    int CodeErreur
    {
      get;
    }
    bool AUneErreur { get; }
  }

  public interface IRetour<TObjet> : IRetour
  {
    TObjet Objet
    {
      get;
    }
  }

}
