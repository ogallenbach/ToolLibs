using MVVMTools.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMTools.PropertyHelpers
{
	/// <summary>
	/// Kapselt Werte für die ComboBox.
	/// </summary>
	public class ComboBoxProperty<T> : ControlPropertyBase
	{
		#region Konstanten

		#endregion

		#region private Variablen

		#endregion

		#region Eigenschaften
		/// <summary>
		/// Der ausgewählte Index der Auswahl.
		/// Wenn dieser angepasst wird, wird die SelectedItem-Eigenschaft aktualisiert.
		/// </summary>
		private int _selectedIndex;
		public int SelectedIndex
		{
			get { return _selectedIndex; }
			set
			{
				if (SetProperty(ref _selectedIndex, value))
				{
					if (_selectedIndex >= 0 && _selectedIndex < _itemList.Count)
					{
						SelectedItem = _itemList[_selectedIndex];
					}
				}
			}
		}
		
		/// <summary>
		/// Das ausgewählte Element der ComboBox.
		/// </summary>
		private T _selectedItem;
		public T SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (SetProperty(ref _selectedItem, value))
				{
					//if(typeof(T) == typeof(ComboBoxElement))
					//{
					//	Text = (_selectedItem as ComboBoxElement).Text;
					//}
					//else
					//{
					//	Text = _selectedItem.ToString();
					//}
					_selectionChangedMethod?.Invoke();
				}
			}
		}
		
		public object Value
		{ 
			get
			{
				if (_selectedItem.GetType() == typeof(ComboBoxElement))
				{
					return (_selectedItem as ComboBoxElement).Value;
				}
				else
				{
					return _selectedItem;
				}
			}
		}
		/// <summary>
		/// Override für die Control.Text-Eigenschaft der ComboBox.
		/// gibt den Text des ausgewählten ComboBox-Elements zurück oder setzt das ausgewählte Element anhand des übergebenen Textes,
		/// falls der übergebene Text in der ItemList der ComBox enthalten ist. Falls nicht wird der SelectedIndex auf -1 gesetzt.
		/// </summary>
		public override string Text
		{
			get
			{
				if (_selectedItem == null) return "";
				if (_selectedItem.GetType() == typeof(ComboBoxElement))
				{
					return (_selectedItem as ComboBoxElement).Text;
				}
				else
				{
					return _selectedItem.ToString();
				}
			}
			set
			{
				setCboIndexFromText(value);
			}
		}
		private BindingList<T> _itemList;
		/// <summary>
		/// Liste mit den Elementen.
		/// </summary>
		public BindingList<T> ItemList
		{
			get { return _itemList; }
			set
			{
				if (SetProperty(ref _itemList, value))
				{
					if (_itemList.Count > 0)
					{
						SelectedIndex = 0;
					}
				}
			}
		}
		private IListDataProvider<T> _listDataProvider;
		/// <summary>
		/// Schnittstelle für das Laden der Listenelemente.
		/// </summary>
		public IListDataProvider<T> ListDataProvider
		{
			get { return _listDataProvider; }
			set { SetProperty(ref _listDataProvider, value); }
		}
		private Action _selectionChangedMethod;
		/// <summary>
		/// Falls im Konstruktor eine Methode angegeben wurde, wird sie aufgerufen, wenn sich die Auswahl der ComboBox ändert.
		/// </summary>
		public Action SelectionChangedMethod { get { return _selectionChangedMethod; } }
		#endregion

		#region Konstruktor
		public ComboBoxProperty() : this(null, null, null) { }
		public ComboBoxProperty(Action pSelectionChangedMethod) : this(null, pSelectionChangedMethod, null) { }
		public ComboBoxProperty(IListDataProvider<T> pListDataProvider) : this(pListDataProvider, null, null) { }
		public ComboBoxProperty(ICommand pEnterCommand) : this(null, null, pEnterCommand) { }
		public ComboBoxProperty(IListDataProvider<T> pListDataProvider, Action pSelectionChangedMethod) : this(pListDataProvider, pSelectionChangedMethod, null) { }
		public ComboBoxProperty(IListDataProvider<T> pListDataProvider, ICommand pEnterCommand) : this(pListDataProvider, null, pEnterCommand) { }
		public ComboBoxProperty(Action pSelectionChangedMethod, ICommand pEnterCommand) : this(null, pSelectionChangedMethod, pEnterCommand) { }
		public ComboBoxProperty(IListDataProvider<T> pListDataProvider, Action pSelectionChangedMethod, ICommand pEnterCommand) : base(pEnterCommand)
		{
			_selectedIndex = -1;
			_selectedItem = default(T);
			_itemList = new BindingList<T>();
			_listDataProvider = pListDataProvider;
			_selectionChangedMethod = pSelectionChangedMethod;
		}
		#endregion

		#region Methoden
		/// <summary>
		/// clears all Text from the control.
		/// </summary>
		public void Clear()
		{
			SelectedIndex = -1;
			Text = string.Empty;
		}
		private void setCboIndexFromText(string pText)
		{
			int index = -1;
			for (int i = 0; i < ItemList.Count; i++)
			{
				if (ItemList[i].GetType() == typeof (ComboBoxElement))
				{
					if ((ItemList[i] as ComboBoxElement).Text.Equals(pText))
					{
						index = i;
						break;
					}
				}
			}
			SelectedIndex = index;
		}
		#endregion

		#region Events

		#endregion
	}
}
