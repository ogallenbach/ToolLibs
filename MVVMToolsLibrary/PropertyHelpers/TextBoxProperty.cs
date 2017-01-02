using System;
using System.Drawing;
using System.Windows.Input;

namespace MVVMTools.PropertyHelpers
{
	/// <summary>
	/// Kapselt die Werte für die TextBox.
	/// </summary>
	public class TextBoxProperty : ControlPropertyBase
	{
		#region Konstanten
		public static Color DefaultForeColor = Color.Black;
		public static Color DefaultBackColor = Color.White;
		#endregion

		#region private Variablen

		#endregion

		#region Eigenschaften
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (SetProperty(ref _text, value))
                {
                    _valueChangedMethod?.Invoke();
                }
            }
        }
		private bool _readOnly;
		/// <summary>
		/// "ReadOnly"-Eigenschaft der TextBox.
		/// </summary>
		public bool ReadOnly
		{
			get { return _readOnly; }
			set { SetProperty(ref _readOnly, value); }
		}
		private int _maxLength;
		/// <summary>
		/// "MaxLength"-Eigenschaft der TextBox.
		/// </summary>
		public int MaxLength
		{
			get { return _maxLength; }
			set { SetProperty(ref _maxLength, value); }
		}
		private int _maxValue;
		/// <summary>
		/// "MaxValue"-Eigenschaft der TextBox. Maximum value user can enter in the control. Default is no maximum value. Values
		//     bigger than MaxValue will be considered invalid values.
		/// </summary>
		public int MaxValue
		{
			get { return _maxValue; }
			set { SetProperty(ref _maxValue, value); }
		}
		private Color _foreColor;
		/// <summary>
		/// Schriftfarbe der TextBox.
		/// </summary>
		public Color ForeColor
		{
			get { return _foreColor; }
			set { SetProperty(ref _foreColor, value); }
		}
		private Color _backColor;
		/// <summary>
		/// Hintergrundfarbe der TextBox.
		/// </summary>
		public Color BackColor
		{
			get { return _backColor; }
			set { SetProperty(ref _backColor, value); }
		}
		private Action _valueChangedMethod;
		/// <summary>
		/// Falls im Konstruktor eine Methode angegeben wurde, wird sie aufgerufen, wenn sich der Text ändert.
		/// </summary>
		public Action ValueChangedMethod { get { return _valueChangedMethod; } }
		#endregion

		#region Konstruktor
		public TextBoxProperty() : this(null) { }
		public TextBoxProperty(Action pValueChangedMethod) : this(pValueChangedMethod, null) { }
        public TextBoxProperty(Action pValueChangedMethod, ICommand pEnterCommand) : this(pValueChangedMethod, pEnterCommand, null) { }
		public TextBoxProperty(Action pValueChangedMethod, ICommand pEnterCommand, ICommand pLeaveCommand) : base(pEnterCommand, pLeaveCommand)
		{
			_readOnly = false;
			_maxLength = 32767;
			_foreColor = DefaultForeColor;
			_backColor = DefaultBackColor;
			_valueChangedMethod = pValueChangedMethod;
		}
		#endregion

		#region Methoden
		/// <summary>
		/// Clears all text from the control.
		/// </summary>
		public void Clear()
		{
			Text = "";
		}
		#endregion

		#region Events

		#endregion
	}
}
