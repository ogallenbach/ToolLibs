using System.Drawing;
using System.Windows.Input;

namespace MVVMTools.PropertyHelpers
{
	/// <summary>
	/// Kapselt die Eigenschaften für einen ProgressBar.
	/// </summary>
	public class ProgressBarProperty : ControlPropertyBase
	{
		#region Konstanten
		public static Color DefaultForeColor = Color.Black;
		public static Color DefaultBackColor = Color.Gray;
		#endregion

		#region Eigenschaften
		private int _value;
		/// <summary>
		/// Current Value
		/// </summary>
		public int Value
		{
			get { return _value; }
			set { SetProperty(ref _value, value); }
		}
		private int _maximum;
		/// <summary>
		/// Maximum Value of the Progressbar
		/// </summary>
		public int Maximum
		{
			get { return _maximum; }
			set { SetProperty(ref _maximum, value); }
		}
		private int _minimum;
		/// <summary>
		/// Minimum Value of the Progressbar
		/// </summary>
		public int Minimum
		{
			get { return _minimum; }
			set { SetProperty(ref _minimum, value); }
		}
		private Color _foreColor;
		/// <summary>
		/// Schriftfarbe des ProgressBars.
		/// </summary>
		public Color ForeColor
		{
			get { return _foreColor; }
			set { SetProperty(ref _foreColor, value); }
		}
		private Color _backColor;
		/// <summary>
		/// Hintergrundfarbe des ProgressBars.
		/// </summary>
		public Color BackColor
		{
			get { return _backColor; }
			set { SetProperty(ref _backColor, value); }
		}	
		#endregion

		#region Konstruktor
		public ProgressBarProperty() : base()
        {
			_foreColor = DefaultForeColor;
			_backColor = DefaultBackColor;
		}
		#endregion

		#region Methoden

		#endregion
	}
}
