using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMTools
{
    /// <summary>
    /// Basisklasse für zu bindenden Klassen. Implementiert die INotifyPropertyChanged-Schnittstelle
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Setzt den neuen Wert der Eigenschaft und löst das PropertyChanged-Event aus, falls der Wert sich ändert.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pProperty">Referenz der Eigenschaft</param>
        /// <param name="pValue">Neuer Wert</param>
        /// <param name="pPropertyName">Eigenschaftsname</param>
        /// <returns></returns>
        public bool SetProperty<T>(ref T pProperty, T pValue, [CallerMemberName] string pPropertyName = null)
        {
            if (object.Equals(pProperty, pValue))
            {
                return false;
            }
            pProperty = pValue;
            OnPropertyChanged(pPropertyName);
            return true;
        }

        public void OnPropertyChanged(string pPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
        }
    }
}
