
namespace MVVMTools.Services
{
    /// <summary>
    /// Gibt den Box-Typ der Messagebox an.
    /// </summary>
    public enum BoxType
    {
        /// <summary>
        /// MessageBox mit Informations-Logo.
        /// </summary>
        Information,
        /// <summary>
        /// MessageBox mit Frage-Logo und einem DialogResult true oder false.
        /// </summary>
        Question,
        /// <summary>
        /// MessageBox mit einem Achtung-Logo.
        /// </summary>
        Important,
        /// <summary>
        /// MessageBox mit einem Fehler-Logo.
        /// </summary>
        Error
    }
    /// <summary>
    /// Stellt die Funktionalität für das Aufrufen von MessageBoxen bereit.
    /// </summary>
    public interface IMessageBoxService
    {
        bool Show(BoxType pBoxType, string pText, params object[] pInsertText);
        bool Show(BoxType pBoxType, string pText, string pCaption, params object[] pInsertText);
    }
}
