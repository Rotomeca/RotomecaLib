using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RotomecaLib.Interfaces;

namespace RotomecaLib
{

  public class Retour : RotomecaObject, IRetour
  {
    public delegate bool GestionRetourErreur(Retour retour);

    public static GestionRetourErreur CHECK_ERROR = DefaultErrorGestion;

    public Exception Erreur { get; private set; }
    public int CodeErreur { get; private set; }
    public bool AUneErreur => _foncError(this);

    protected GestionRetourErreur _foncError;

    protected static bool DefaultErrorGestion(Retour retour)
    {
      return retour.Erreur != null;
    }

    protected Retour()
    {
      _foncError = CHECK_ERROR;
    }

    public Retour(int codeError, string msgError)
    {
      Erreur = new Exception(msgError);
      CodeErreur = codeError;
      _foncError = CHECK_ERROR;
    }

    public Retour(int codeError, string msgError, GestionRetourErreur detectectionAUneErreur)
    {
      Erreur = new Exception(msgError);
      CodeErreur = codeError;
      _foncError = detectectionAUneErreur ?? CHECK_ERROR;
    }

    public Retour(int codeError, Exception error)
    {
      Erreur = error;
      CodeErreur = codeError;
      _foncError = CHECK_ERROR;
    }

    public Retour(int codeError, Exception error, GestionRetourErreur detectectionAUneErreur)
    {
      Erreur = error;
      CodeErreur = codeError;
      _foncError = detectectionAUneErreur ?? CHECK_ERROR;
    }

    public static IRetour Vide => RetourVide.Vide;

  }

  public class Retour<TRetour> : Retour, IRetour<TRetour>
  {

    public TRetour Objet { get; private set; }

    protected Retour() : base() { }

    public Retour(TRetour objet) : base()
    {
      Objet = objet;
    }

    public Retour(int codeError, string msgError) : base(codeError, msgError)
    {

    }

    public Retour(int codeError, string msgError, GestionRetourErreur detectectionAUneErreur) : base(codeError, msgError, detectectionAUneErreur)
    {

    }

    public Retour(int codeError, Exception error) : base(codeError, error)
    {

    }

    public Retour(int codeError, Exception error, GestionRetourErreur detectectionAUneErreur) : base(codeError, error, detectectionAUneErreur)
    {

    }

    public Retour(int codeError, string msgError, TRetour objet) : base(codeError, msgError)
    {
      Objet = objet;
    }

    public Retour(int codeError, string msgError, TRetour objet, GestionRetourErreur detectectionAUneErreur) : base(codeError, msgError, detectectionAUneErreur)
    {
      Objet = objet;
    }

    public Retour(int codeError, Exception error, TRetour objet) : base(codeError, error)
    {
      Objet = objet;
    }

    public Retour(int codeError, Exception error, GestionRetourErreur detectectionAUneErreur, TRetour objet) : base(codeError, error, detectectionAUneErreur)
    {
      Objet = objet;
    }
    //public CRetour(string )

  }

  public class RetourVide : RotomecaObject, IRetour
  {
    public Exception Erreur => null;

    public int CodeErreur => 0;

    public bool AUneErreur => false;

    private RetourVide() { }

    public static implicit operator Retour(RetourVide retourVide)
    {
      return new Retour(retourVide.CodeErreur, retourVide.Erreur);
    }

    public static RetourVide Vide => new RetourVide();

  }

  public class RetourAsync : RotomecaObject, IRetour
  {
    IRetour retour;

    public Exception Erreur => retour.Erreur;

    public int CodeErreur => retour.CodeErreur;

    public bool AUneErreur => retour.AUneErreur;

    private RetourAsync(IRetour retour)
    {
      this.retour = retour;
    }

    public Task<IRetour> GetTask()
    {
      return Task.Run(() => retour);
    }

    public RetourAsync Fabrique(IRetour retour)
    {
      return new RetourAsync(retour);
    }

  }
}
