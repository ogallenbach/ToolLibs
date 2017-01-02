using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace MVVMTools.PropertyHelpers
{
	public class MenuItemProperty : ControlPropertyBase
	{
		#region Konstanten
		public static Color DefaultForeColor = Color.Black;
		public static Color DefaultBackColor = Color.Gray;
		#endregion

		#region Eigenschaften
		private Color _foreColor;
		/// <summary>
		/// Schriftfarbe des MenuItems.
		/// </summary>
		public Color ForeColor
		{
			get { return _foreColor; }
			set { SetProperty(ref _foreColor, value); }
		}
		private Color _backColor;
		/// <summary>
		/// Hintergrundfarbe des MenuItems.
		/// </summary>
		public Color BackColor
		{
			get { return _backColor; }
			set { SetProperty(ref _backColor, value); }
		}
		private List<MenuItemProperty> _dropDownItems;
		public List<MenuItemProperty> DropDownItems
		{
			get { return _dropDownItems; }
			set { _dropDownItems = value; }
		}
		private ICommand _clickCommand;
		/// <summary>
		/// "Click"-Command des MenuItems.
		/// </summary>
		public ICommand ClickCommand { get { return _clickCommand; } }
		#endregion

		#region Konstruktor
		public MenuItemProperty() : this(null) { }
		public MenuItemProperty(ICommand pCommand) : base()
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
