using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Collective.Model;
using GalaSoft.MvvmLight;
using Collective.AgentClient.Model;
using GalaSoft.MvvmLight.Command;

namespace Collective.AgentClient.ViewModel
{
  
    public class PauseViewModel : ViewModelBase
    {
        #region Properties

        private readonly IDataService _dataService;
        
        #region "Pauses"

        /// <summary>
        /// The <see cref="Pauses" /> property's name.
        /// </summary>
        public const string PausesPropertyName = "Pauses";

        private ObservableCollection<PausesModel> _pauses;

        /// <summary>
        /// Sets and gets the PauseMenu property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<PausesModel> Pauses
        {
            get
            {
                return _pauses;
            }

            set
            {
                if (_pauses == value)
                {
                    return;
                }

                _pauses = value;
                RaisePropertyChanged(PausesPropertyName);
            }
        }

        #endregion
        
        #region "SelectedPause"

        /// <summary>
        /// The <see cref="SelectedPause" /> property's name.
        /// </summary>
        public const string SelectedPausePropertyName = "SelectedPause";

        private PausesModel _selectedpause  ;

        /// <summary>
        /// Sets and gets the SelectedPause property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PausesModel SelectedPause
        {
            get
            {
                return _selectedpause;
            }

            set
            {
                if (_selectedpause == value)
                {
                    return;
                }

                _selectedpause = value;
                PauseCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(SelectedPausePropertyName);
            }
        }
        #endregion

        #region PauseVisibility

        /// <summary>
        /// The <see cref="PauseVisibility" /> property's name.
        /// </summary>
        public const string PauseVisibilityPropertyName = "PauseVisibility";

        private Visibility _pauseVisibility;

        /// <summary>
        /// Sets and gets the PauseVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility PauseVisibility
        {
            get
            {
                return _pauseVisibility;
            }

            set
            {
                if (_pauseVisibility == value)
                {
                    return;
                }

                _pauseVisibility = value;
                RaisePropertyChanged(PauseVisibilityPropertyName);
            }
        }

        #endregion

        #region LogoutVisibility

        /// <summary>
        /// The <see cref="LogoutVisibility" /> property's name.
        /// </summary>
        public const string LogoutVisibilityPropertyName = "LogoutVisibility";

        private Visibility _logoutVisibility;

        /// <summary>
        /// Sets and gets the LogoutVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility LogoutVisibility
        {
            get
            {
                return _logoutVisibility;
            }

            set
            {
                if (_logoutVisibility == value)
                {
                    return;
                }

                _logoutVisibility = value;
                RaisePropertyChanged(LogoutVisibilityPropertyName);
            }
        }

        #endregion

        #region ResumeVisibility

        /// <summary>
        /// The <see cref="ResumeVisibility" /> property's name.
        /// </summary>
        public const string ResumeVisibilityPropertyName = "ResumeVisibility";

        private Visibility _resumeVisibility;

        /// <summary>
        /// Sets and gets the ResumeVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility ResumeVisibility
        {
            get
            {
                return _resumeVisibility;
            }

            set
            {
                if (_resumeVisibility == value)
                {
                    return;
                }

                _resumeVisibility = value;
                RaisePropertyChanged(ResumeVisibilityPropertyName);
            }
        }

        #endregion
        
        #region "ComboEnable"
        /// The <see cref="ComboEnable" /> property's name.
        /// </summary>
        public const string ComboEnablePropertyName = "ComboEnable";

        private bool _comboEnable = false;

        /// <summary>
        /// Sets and gets the ComboEnable property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ComboEnable
        {
            get
            {
                return _comboEnable;
            }

            set
            {
                if (_comboEnable == value)
                {
                    return;
                }

                _comboEnable = value;
                RaisePropertyChanged(ComboEnablePropertyName);
            }
        }
        #endregion

        #region "PauseId"
        /// The <see cref="PauseId" /> property's name.
        /// </summary>
        public const string PauseIdPropertyName = "PauseId";

        private long _pauseId;

        /// <summary>
        /// Sets and gets the PauseId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long PauseId
        {
            get
            {
                return _pauseId;
            }

            set
            {
                if (_pauseId == value)
                {
                    return;
                }

                _pauseId = value;
                RaisePropertyChanged(PauseIdPropertyName);
            }
        }
        #endregion

        #region "UserName"
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _userName = "";

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                if (_userName == value)
                {
                    return;
                }

                _userName = value;
                RaisePropertyChanged(UserNamePropertyName);
            }
        }
        #endregion

        #region "CampaignId"
        /// The <see cref="CampaignId" /> property's name.
        /// </summary>
        public const string CampaignIdPropertyName = "CampaignId";

        private long _campainId;

        /// <summary>
        /// Sets and gets the CampaignId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long CampaignId
        {
            get
            {
                return _campainId;
            }

            set
            {
                if (_campainId == value)
                {
                    return;
                }

                _campainId = value;
                RaisePropertyChanged(CampaignIdPropertyName);
            }
        }
        #endregion

        #region CloseAction

        public Action CloseAction { get; set; }

        #endregion

        public RelayCommand PauseCommand { get; set; }

        public RelayCommand LogoutCommand { get; set; }

        public RelayCommand<Window> ResumeCommand { get; set; }

        public event EventHandler OnRequesteClose;
        #endregion

        #region Construtor

        public PauseViewModel(IDataService dataService)
        {
            _dataService = dataService;

            RegisterCommand();
            LoadReasons();
            ResumeVisibility = Visibility.Collapsed;
            LogoutVisibility = Visibility.Visible;
            PauseVisibility = Visibility.Visible;
            ComboEnable = true;
        }

        #endregion  

        #region Private Methods

        private void RegisterCommand()
        {
            PauseCommand = new RelayCommand(Pause,CanPause);
            ResumeCommand = new RelayCommand<Window>(Resume);
            LogoutCommand = new RelayCommand(Logout);
        }

        private void Pause()
        {
            PauseVisibility = Visibility.Collapsed;
            LogoutVisibility = Visibility.Collapsed;
            ResumeVisibility = Visibility.Visible;
            ComboEnable = false;
            _dataService.Dopause(UserName, SelectedPause.Reason, CampaignId,
                (pauseId, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    PauseId = pauseId;
                });
        }

        private bool CanPause()
        {
            return SelectedPause != null;
        }

        private void Resume(Window window)
        {
            _dataService.Resume(PauseId,
                (resumeBreak, error) =>
            {
                if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                PauseId = resumeBreak;
                
            });
            //window.Close();
            //CloseAction();
            //OnRequesteClose(this, new EventArgs());
                        
        }

        private void Logout()
        {
            
        }

        private void LoadReasons()
        {
            _dataService.GetReasons(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        MessageBox.Show(error.Message);
                        return;
                    }
                    Pauses = new ObservableCollection<PausesModel>(lista);
                    
                });
        }

        

        #endregion

    }
}