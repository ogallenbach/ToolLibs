

namespace MVVMTools.PropertyHelpers
{
    /// <summary>
    /// Kapselt den Wert und die Beschriftung eines ComboBox-Elements.
    /// </summary>
    public class ComboBoxElement : BindableBase
    {
        #region Konstanten

        #endregion

        #region private Variablen

        #endregion

        #region Eigenschaften
        private string _text;
        /// <summary>
        /// Text der in der ComboBox angezeigt wird.
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        private object _value;
        /// <summary>
        /// Wert des Elements.
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
        #endregion

        #region Konstruktor
        public ComboBoxElement() :this(null, string.Empty){}
        public ComboBoxElement(object pValue, string pText)
        {
            _text = pText;
            _value = pValue;
        }
        #endregion

        #region Methoden
        public override string ToString()
        {
            return _text;
        }
        #endregion

        #region Events

        #endregion
    }
}
