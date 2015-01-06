using System;
using System.Collections.ObjectModel;
using System.Windows;
using Collective.AgentClient.Model;
using Collective.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Collective.AgentClient.ViewModel
{
    public class PayrollAdvisorModel : ViewModelBase
    {
        #region Properties

        private readonly IDataService _dataService;

        #region InitialDate

        /// <summary>
        /// The <see cref="InitialDate" /> property's name.
        /// </summary>
        public const string InitialDatePropertyName = "InitialDate";

        private DateTime _initialDate;

        /// <summary>
        /// Sets and gets the InitialDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime InitialDate
        {
            get
            {
                return _initialDate;
            }

            set
            {
                if (_initialDate == value)
                {
                    return;
                }

                _initialDate = value;
                RaisePropertyChanged(InitialDatePropertyName);
            }
        }

        #endregion

        #region FinalDate

        /// <summary>
        /// The <see cref="FinalDate" /> property's name.
        /// </summary>
        public const string FinalDatePropertyName = "FinalDate";

        private DateTime _finalDate;

        /// <summary>
        /// Sets and gets the FinalDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FinalDate
        {
            get
            {
                return _finalDate;
            }

            set
            {
                if (_finalDate == value)
                {
                    return;
                }

                _finalDate = value;
                RaisePropertyChanged(FinalDatePropertyName);
            }
        }

        #endregion

        #region LogList

        /// <summary>
        /// The <see cref="LogList" /> property's name.
        /// </summary>
        public const string LogListPropertyName = "LogList";

        private ObservableCollection<RecordLogModel> _logList;

        /// <summary>
        /// Sets and gets the LogList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<RecordLogModel> LogList
        {
            get
            {
                return _logList;
            }

            set
            {
                if (_logList == value)
                {
                    return;
                }

                _logList = value;
                RaisePropertyChanged(LogListPropertyName);
            }
        }

        #endregion

        #region Agent

        /// <summary>
        /// The <see cref="Agent" /> property's name.
        /// </summary>
        public const string AgentPropertyName = "Agent";

        private string _agent;

        /// <summary>
        /// Sets and gets the Agent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Agent
        {
            get
            {
                return _agent;
            }

            set
            {
                if (_agent == value)
                {
                    return;
                }

                _agent = value;
                RaisePropertyChanged(AgentPropertyName);
            }
        }
        #endregion

        #endregion

        #region Constructor
        public PayrollAdvisorModel(IDataService dataService)
        {
            _dataService = dataService;
            RegisterCommands();
            InitialDate = DateTime.Today;
            FinalDate = DateTime.Today;
        }

        #endregion

        #region Commands

        public RelayCommand RefreshCommand { get; set; }

        #endregion

        #region Private Methods
        private void RegisterCommands()
        {
            RefreshCommand = new RelayCommand(Refresh);
        }

        private void Refresh()
        {
            //var finalDate = new DateTime(FinalDate.Year, FinalDate.Month, FinalDate.Day, 23, 59, 59);
            _dataService.GetAgentLogPayroll(Agent, InitialDate,FinalDate,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    LogList = new ObservableCollection<RecordLogModel>(lista);
                });
        }

        #endregion
    }
}