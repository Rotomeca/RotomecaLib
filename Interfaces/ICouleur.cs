using System;

namespace RotomecaLib.Interfaces
{
    /// <summary>
    /// Interface générique pour la représentation des couleurs
    /// </summary>
    public interface ICouleur
    {
        /// <summary>
        /// Représentation hexadécimal de la couleur
        /// </summary>
        string Hexadecimal { get; }
    }

    /// <summary>
    /// Interface qui représente une couleur Rouge Vert Bleu
    /// </summary>
    public interface IRVBCouleur : ICouleur
    {
        /// <summary>
        /// Représentation du rouge
        /// </summary>
        double Rouge { get; set; }
        /// <summary>
        /// Représentation du bleu
        /// </summary>
        double Bleu { get; set; }
        /// <summary>
        /// Représentation du vert
        /// </summary>
        double Vert { get; set; }
    }

    /// <summary>
    ///  Interface qui représente une couleur Rouge Vert Bleu avec de la transparance
    /// </summary>
    public interface IRVBACouleur : IRVBCouleur
    {
        /// <summary>
        /// Valeur de transparance
        /// </summary>
        double Alpha { get; set; }
    }
}

