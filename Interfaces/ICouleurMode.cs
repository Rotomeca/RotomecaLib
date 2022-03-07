using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Interfaces
{
    /// <summary>
    /// Interface qui permet de gérer les modes de couleurs de la classe <see cref="Structures.Couleur"/>
    /// </summary>
    public interface ICouleurMode
    {
        /// <summary>
        /// Valeur du rouge
        /// </summary>
        DoubleMinMax RecupRouge();
        /// <summary>
        /// Récupère la bonne valeur.
        /// </summary>
        /// <param name="val">Valeur à limitée</param>
        /// <returns></returns>
        DoubleMinMax RecupRouge(double val);
        /// <summary>
        /// Valeur du vert
        /// </summary>
        DoubleMinMax RecupVert();
        DoubleMinMax RecupVert(double val);
        /// <summary>
        /// Valeur du bleu
        /// </summary>
        DoubleMinMax RecupBleu();
        DoubleMinMax RecupBleu(double val);
        /// <summary>
        /// Valeur de l'alpha
        /// </summary>
        DoubleMinMax RecupAlpha();
        DoubleMinMax RecupAlpha(double val);

        /// <summary>
        /// Minimum de l'instance
        /// </summary>
        double Min { get; }
        /// <summary>
        /// Maximum de l'instance
        /// </summary>
        double Max { get; }
    }
}
