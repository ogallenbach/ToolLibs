using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMTools.PropertyHelpers
{
	public class CheckBoxProperty : ControlPropertyBase
	{
		private bool _checked;
		/// <summary>
		/// "Checked"-Eigenschaft des Controls.
		/// </summary>
		public bool Checked
		{
			get { return _checked; }
			set
			{
				if (SetProperty(ref _checked, value))
				{
					_checkedChangedMethod?.Invoke();
				}
			}
		}
		private Action _checkedChangedMethod;
		/// <summary>
		/// Falls im Konstruktor eine Methode angegeben wurde, wird sie aufgerufen, wenn sich die Auswahl der ComboBox ändert.
		/// </summary>
		public Action CheckedChangedMethod { get { return _checkedChangedMethod; } }
		#region Konstruktor
		public CheckBoxProperty() : this(false, null){}
		public CheckBoxProperty(bool pChecked) : this(pChecked, null){}
		public CheckBoxProperty(Action pCheckedChangedMethod) : this(false, pCheckedChangedMethod) { }
		public CheckBoxProperty(bool pChecked, Action pCheckedChangedMethod) : base()
		{
			_checked = pChecked;
			_checkedChangedMethod = pCheckedChangedMethod;
		}
		public CheckBoxProperty(ICommand pKeyPressCommand) : base(null, null, pKeyPressCommand) { }
        #endregion
    }
}
