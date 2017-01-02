using System;

namespace MVVMTools.PropertyHelpers
{
    /// <summary>
    /// Kapselt die Werte für die DateTime-Auswahl ("Von", "Bis", "Zeitraum beachten").
    /// </summary>
    public class DateTimeSelectionProperty : BindableBase
    {
        #region Konstanten

        #endregion

        #region private Variablen

        #endregion

        #region Eigenschaften
        private bool _considerTimePeriodChecked;
        /// <summary>
        /// "Zeitraum beachten" Checked-Eigenschaft.
        /// Beim Aktivieren/Deaktivieren werden die Enabled-Eigenschaften der DateTime-Auswahl entsprechend aktualisert.
        /// </summary>
        public bool ConsiderTimePeriodChecked
        {
            get { return _considerTimePeriodChecked; }
            set
            {
                if (SetProperty(ref _considerTimePeriodChecked, value))
                {
                    FromDateTimeSelectionEnabled = _considerTimePeriodChecked;
                    ToDateTimeSelectionEnabled = _considerTimePeriodChecked;
                }
            }
        }
        private bool _considerTimePeriodEnabled;
        /// <summary>
        /// "Zeitraum beachten" Enabled-Eigenschaft.
        /// </summary>
        public bool ConsiderTimePeriodEnabled
        {
            get { return _considerTimePeriodEnabled; }
            set { SetProperty(ref _considerTimePeriodEnabled, value); }
        }
        private DateTime _fromDateTimeSelectionValue;
        /// <summary>
        /// "Von"-DateTime Wert.
        /// Falls "Von"-DateTime nach der Änderung größer ist, wird der Wert angepasst.
        /// </summary>
        public DateTime FromDateTimeSelectionValue
        {
            get { return _fromDateTimeSelectionValue; }
            set
            {
                if (SetProperty(ref _fromDateTimeSelectionValue, value))
                {
                    if (_fromDateTimeSelectionValue > _toDateTimeSelectionValue)
                    {
                        ToDateTimeSelectionValue = _fromDateTimeSelectionValue.AddDays(+1);
                    }
                }
            }
        }
        private bool _fromDateTimeSelectionEnabled;
        /// <summary>
        /// "Von"-DateTime-Auswahl Enabled-Eigenschaft.
        /// </summary>
        public bool FromDateTimeSelectionEnabled
        {
            get { return _fromDateTimeSelectionEnabled; }
            set { SetProperty(ref _fromDateTimeSelectionEnabled, value); }
        }
        private DateTime _toDateTimeSelectionValue;
        /// <summary>
        /// "Bis"-DateTime Wert. 
        /// Falls "Von"-DateTime nach der Änderung größer ist, wird der Wert angepasst.
        /// </summary>
        public DateTime ToDateTimeSelectionValue
        {
            get { return _toDateTimeSelectionValue; }
            set
            {
                if (SetProperty(ref _toDateTimeSelectionValue, value))
                {
                    if (_fromDateTimeSelectionValue > _toDateTimeSelectionValue)
                    {
                        FromDateTimeSelectionValue = _toDateTimeSelectionValue.AddDays(-1);
                    }
                }
            }
        }
        private bool _toDateTimeSelectionEnabled;
        /// <summary>
        /// "Bis"-DateTime-Auswahl Enabled-Eigenschaft.
        /// </summary>
        public bool ToDateTimeSelectionEnabled
        {
            get { return _toDateTimeSelectionEnabled; }
            set { SetProperty(ref _toDateTimeSelectionEnabled, value); }
        }
        #endregion

        #region Konstruktor
        public DateTimeSelectionProperty()
        {
            _considerTimePeriodChecked = false;
            _considerTimePeriodEnabled = true;
            _fromDateTimeSelectionEnabled = true;
            _toDateTimeSelectionEnabled = true;
            _fromDateTimeSelectionValue = DateTime.Now.AddDays(-1);
            _toDateTimeSelectionValue = DateTime.Now;
        }
        #endregion

        #region Methoden

        #endregion

        #region Events

        #endregion
    }
}
