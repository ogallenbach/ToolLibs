using System.Drawing;
using System.Windows.Input;

namespace MVVMTools.PropertyHelpers
{
    /// <summary>
    /// Kapselt die Eigenschaften für einen Button.
    /// </summary>
    public class ButtonProperty : ControlPropertyBase
    {
        #region Konstanten
        public static Color DefaultForeColor = Color.Black;
        public static Color DefaultBackColor = Color.Gray;
        #endregion

        #region Eigenschaften
        private Color _foreColor;
        /// <summary>
        /// Schriftfarbe des Buttons.
        /// </summary>
        public Color ForeColor
        {
            get { return _foreColor; }
            set { SetProperty(ref _foreColor, value); }
        }
        private Color _backColor;
        /// <summary>
        /// Hintergrundfarbe des Buttons.
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set { SetProperty(ref _backColor, value); }
        }
        private ICommand _clickCommand;
        /// <summary>
        /// "Click"-Command des Buttons.
        /// </summary>
        public ICommand ClickCommand { get { return _clickCommand; } }
        #endregion

        #region Konstruktor
        public ButtonProperty(ICommand pCommand) : base()
        {
            _foreColor = DefaultForeColor;
            _backColor = DefaultBackColor;
            _clickCommand = pCommand;
        }
        #endregion

        #region Methoden

        #endregion
    }
}
