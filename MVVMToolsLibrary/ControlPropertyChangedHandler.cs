using System;
using System.Reflection;

namespace MVVMTools
{
	public static class ControlPropertyChangedHandler
	{
		/// <summary>
		/// Setzt eine Eigenschaft im ViewModel auf den Wert der Control-Eigenschaft, wenn diese aneinander gebunden sind und sich vom Wert her unterscheiden.
		/// Wird benutzt, wenn das DataBinding z.B. nur in eine Richtung funktioniert (ViewModel-Eigenschaft -> Control-Eigenschaft) und muss in dem Fall
		/// im EigenschaftChangedEvent des Controls aufgerufen werden.
		/// </summary>
		/// <param name="pCtrl"></param>
		/// <param name="pPropertyName"></param>
		public static void SetViewModelProperty(System.Windows.Forms.Control pCtrl, string pPropertyName )
		{
			for (int i = 0; i < pCtrl.DataBindings.Count; i++)
			{
				if (pCtrl.DataBindings[i].PropertyName != pPropertyName) continue;
				object ctrlValue = pCtrl.GetType().GetProperty(pPropertyName).GetValue(pCtrl, null);

				Type dataSourceType = pCtrl.DataBindings[i].DataSource.GetType();
				PropertyInfo dataSourceProperty = dataSourceType.GetProperty(pCtrl.DataBindings[i].BindingMemberInfo.BindingMember);
				object dataSourceValue = dataSourceProperty.GetValue(pCtrl.DataBindings[i].DataSource, null);

				if (ctrlValue != null && dataSourceValue != null)
				{
					if (!ctrlValue.Equals(dataSourceValue))
					{
						dataSourceProperty.SetValue(pCtrl.DataBindings[i].DataSource, ctrlValue);
					}
				}
				break;
			}
		}
	}
}
