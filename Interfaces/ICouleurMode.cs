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
        Classes.DoubleMinMax RecupRouge();
        /// <summary>
        /// Valeur du vert
        /// </summary>
        Classes.DoubleMinMax RecupVert();
        /// <summary>
        /// Valeur du bleu
        /// </summary>
        Classes.DoubleMinMax RecupBleu();
        /// <summary>
        /// Valeur de l'alpha
        /// </summary>
        Classes.DoubleMinMax RecupAlpha();
    }
}
