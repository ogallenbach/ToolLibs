using System.Drawing;

namespace MVVMTools.PropertyHelpers
{
    /// <summary>
    /// Kapselt die Eigenschaften für eine Label.
    /// </summary>
    public class LabelProperty : ControlPropertyBase
    {
        #region Konstanten
        const string DefaultText = "Default";
        public static Color DefaultForeColor = Color.Black;
        public static Color DefaultBackColor = Color.Transparent;
        #endregion

        #region Eigenschaften
        private Color _foreColor;
        /// <summary>
        /// Schriftfarbe des Labels.
        /// </summary>
        public Color ForeColor
        {
            get { return _foreColor; }
            set { SetProperty(ref _foreColor, value); }
        }
        private Color _backColor;
        /// <summary>
        /// Hintergrundfarbe des Labels.
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set { SetProperty(ref _backColor, value); }
        }
        #endregion

        #region Konstruktor
        public LabelProperty(string pText):base()
        {
            Text = pText;
            _foreColor = DefaultForeColor;
            _backColor = DefaultBackColor;
        }
		public LabelProperty() : this("")
		{
		}
        #endregion

        #region Methoden

        #endregion
    }
}
