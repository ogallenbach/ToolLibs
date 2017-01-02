namespace MVVMTools.Services
{
    /// <summary>
    /// Schnittstelle für die Verwendung der Zwischenablage.
    /// </summary>
    public interface IClipBoardService
    {
        void Clear();
        void SetText(string pText);
        string GetText();
    }
}
