
using System.Drawing;
using System.Windows.Input;

namespace MVVMTools.PropertyHelpers
{
	public class ControlPropertyBase : BindableBase
	{
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
        protected string _text;
		/// <summary>
		/// "Text"-Eigenschaft des Controls.
		/// </summary>
		public virtual string Text
		{
			get { return _text; }
			set { SetProperty(ref _text, value);}
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
        private ICommand _enterCommand;
		/// <summary>
		/// "Enter"-Command des Controls.
		/// </summary>
		public ICommand EnterCommand { get { return _enterCommand; } }
        private ICommand _keyPressCommand;
        /// <summary>
        /// "KeyPress"-Command des Controls.
        /// </summary>
        public ICommand KeyPressCommand { get { return _keyPressCommand; } }
        private ICommand _leaveCommand;
        /// <summary>
        /// "Leave"-Command des Controls.
        /// </summary>
        public ICommand LeaveCommand { get { return _leaveCommand; } }
        #endregion

        #region Konstruktor
        public ControlPropertyBase()
		{
			_text = "";
			_enabled = true;
			_visible = true;
		}
		public ControlPropertyBase(ICommand pEnterCommand) : this()
		{
			_enterCommand = pEnterCommand;
		}
        public ControlPropertyBase(ICommand pEnterCommand, ICommand pLeaveCommand) : this(pEnterCommand)
        {
            _leaveCommand = pLeaveCommand;
        }
        public ControlPropertyBase(ICommand pEnterCommand, ICommand pLeaveCommand, ICommand pKeyPressCommand) : this(pEnterCommand, pLeaveCommand)
        {
            _keyPressCommand = pKeyPressCommand;
        }
        #endregion

        #region Methoden

        #endregion

        #region Events

        #endregion
    }
}
