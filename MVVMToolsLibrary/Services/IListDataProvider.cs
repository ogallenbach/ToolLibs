using System.Collections.Generic;

namespace MVVMTools.Services
{
    /// <summary>
    /// Laden von Daten einer beliebigen Quelle in eine Liste.
    /// </summary>
    /// <typeparam name="T">Datentyp der Listenelemente</typeparam>
    public interface IListDataProvider<T>
    {
        /// <summary>
        /// Laden von Daten in eine Liste.
        /// </summary>
        /// <param name="pEmptyField">Falls "true" soll zunächst eine Leerzeile vorhanden sein.</param>
        /// <returns></returns>
        IList<T> LoadList(bool pEmptyField);
    }
}
