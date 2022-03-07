using System;
using System.Collections.Generic;
using System.Text;

namespace RotomecaLib.Interfaces
{
    /// <summary>
    /// Représente une valeur comprise entre un minimum et un maximum.
    /// </summary>
    public interface IMinMax
    {
        object GetMin();
        object GetMax();
        object GetValeur();
    }

    /// <summary>
    /// Représente une valeur comprise entre un minimum et un maximum.
    /// </summary>
    public interface IMinMax<T> : IMinMax
    {
        T Min { get;}
        T Max { get;}
        T Valeur { get; set; }
    }
}
