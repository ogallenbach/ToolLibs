using MVVMTools.Services;
using System;
using System.ComponentModel;
using System.Drawing;

namespace MVVMTools.PropertyHelpers
{
    public class OptionSetProperty : BindableBase
    {
        #region Konstanten

        #endregion

        #region private Variablen

        #endregion

        #region Eigenschaften
        protected string _name;
        /// <summary>
        /// "Name"-Eigenschaft des Controls.
        /// </summary>
        public virtual string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        protected bool _enabled;
        /// <summary>
        /// "Enabled"-Eigenschaft des Controls.
        /// </summary>
        public virtual bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }
        protected bool _visible;
        /// <summary>
        /// "Visible"-Eigenschaft des Controls.
        /// </summary>
        public virtual bool Visible
        {
            get { return _visible; }
            set { SetProperty(ref _visible, value); }
        }
        protected Point _location;
        /// <summary>
        /// "location"-Eigenschaft des Controls
        /// </summary>
        public virtual Point Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }
        private int _checkedIndex;
        /// <summary>
        /// "CheckedIndex"-Eigenschaft des Controls
        /// </summary>
        public int CheckedIndex
        {
            get { return _checkedIndex; }
            set { SetProperty(ref _checkedIndex, value); }
        }
        private BindingList<ComboBoxElement> _itemList;
        /// <summary>
        /// Elemente des Controls
        /// </summary>
        public BindingList<ComboBoxElement> ItemList
        {
            get { return _itemList; }
            set { SetProperty(ref _itemList, value); }
        }
        private IListDataProvider<ComboBoxElement> _listDataProvider;
        /// <summary>
        /// Schnittstelle für das Laden der Listenelemente.
        /// </summary>
        public IListDataProvider<ComboBoxElement> ListDataProvider
        {
            get { return _listDataProvider; }
            set { SetProperty(ref _listDataProvider, value); }
        }
        private Action _selectionChangedMethod;
        /// <summary>
        /// Falls im Konstruktor eine Methode angegeben wurde, wird sie aufgerufen, wenn sich die Auswahl der RadioButtons ändert.
        /// </summary>
        public Action SelectionChangedMethod { get { return _selectionChangedMethod; } }
        #endregion

        #region Konstruktor
        public OptionSetProperty() :this(null, null){ }
        public OptionSetProperty(Action pSelectionChangedMethod) : this(null, pSelectionChangedMethod) { }
        public OptionSetProperty(IListDataProvider<ComboBoxElement> pListDataProvider) : this(pListDataProvider, null){ }
        public OptionSetProperty(IListDataProvider<ComboBoxElement> pListDataProvider, Action pSelectionChangedMethod) : base()
        {
            _itemList = new BindingList<ComboBoxElement>();
            _listDataProvider = pListDataProvider;
            _selectionChangedMethod = pSelectionChangedMethod;
        }
        #endregion

        #region Methoden

        #endregion

        #region Events

        #endregion
    }
}
