using System;
using System.Windows;
using System.Windows.Media;
using Collective.AgentClient.Messages;
using Collective.AgentClient.Model;
using Collective.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;


namespace Collective.AgentClient.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties

        private readonly IDataService _dataService;

        #region Connected

        /// <summary>
        /// The <see cref="Connected" /> property's name.
        /// </summary>
        public const string ConnectedPropertyName = "Connected";

        private string _connected = "";

        /// <summary>
        /// Sets and gets the Connected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Connected
        {
            get
            {
                return _connected;
            }

            set
            {
                if (_connected == value)
                {
                    return;
                }

                _connected = value;
                RaisePropertyChanged(ConnectedPropertyName);
            }
        }

        #endregion

        #region ConnectedColor

        /// <summary>
        /// The <see cref="ConnectedColor" /> property's name.
        /// </summary>
        public const string ConnectedColorPropertyName = "ConnectedColor";

        private SolidColorBrush _connectedColor;

        /// <summary>
        /// Sets and gets the ConnectedColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SolidColorBrush ConnectedColor
        {
            get
            {
                return _connectedColor;
            }

            set
            {
                if (_connectedColor == value)
                {
                    return;
                }

                _connectedColor = value;
                RaisePropertyChanged(ConnectedColorPropertyName);
            }
        }

        #endregion

        #region Username

        /// <summary>
        /// The <see cref="Username" /> property's name.
        /// </summary>
        public const string UsernamePropertyName = "Username";

        private string _username = "";

        /// <summary>
        /// Sets and gets the Username property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                if (_username == value)
                {
                    return;
                }

                _username = value;
                LoginCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(UsernamePropertyName);
            }
        }

        #endregion

        #region Password

        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _password = "";

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (_password == value)
                {
                    return;
                }

                _password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        #endregion

        #region CloseAction

        public Action CloseAction { get; set; }

        #endregion

        public event EventHandler OnRequesteClose;

        public RelayCommand<Window> LoginCommand { get; set; }

        public RelayCommand ForgetPasswordCommand { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel(IDataService dataService)
        {
            _dataService = dataService;
            CommandRegister();
            IsConnected();
        }

        #endregion

        #region Private Methods

        private void CommandRegister()
        {
            LoginCommand = new RelayCommand<Window> (Login);//,CanLogin);
            ForgetPasswordCommand = new RelayCommand(ForgetPassword);
        }

        private void Login(Window window)
        {
            try
            {
                bool ok = false;

                _dataService.Login(Username, Password,
                    (agent, error) =>
                    {
                        if (error != null)
                        {
                            MessageBox.Show(error.Message);
                            return;
                        }
                        ok = true;
                        Messenger.Default.Send(new LoginMessage { Agent = agent });
                        Cleanup();
                        //window.Close();
                        GlobalVariables.GlobalsLib.CanClose = true;
                        CloseAction();
                        GlobalVariables.GlobalsLib.CanClose = false;

                    });
                if (ok == true)
                {
                    Library.StartExplorer.StartWindows();
                    OnRequesteClose(this, new EventArgs());

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\n" + exception.InnerException.Message);
            }
            
        }

        private bool CanLogin(Window window)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                return true;
            }
            return false;
        }

        private void ForgetPassword()
        {
            MessageBox.Show("Call reset password");
        }

        private void Logout()
        {
            // Llamar al _dataservice para registrar fin de sesión
            // Al regresar si no hay error invocar las siguientes líneas
            // similarmente al Login
            Cleanup();
            CloseAction();
        }

        private void IsConnected()
        {
            _dataService.Connected(
                (conn, error) =>
                {
                    if (error != null)
                    {
                        //MessageBox.Show(error.Message);
                        Connected = "Not Connected";
                        ConnectedColor = new SolidColorBrush(Colors.Red);
                        return;
                    }
                    if (conn)
                    {
                        Connected = "Connected";
                        ConnectedColor = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        Connected = "Not Connected";
                        ConnectedColor = new SolidColorBrush(Colors.Red);
                    }
                });
        }

        #endregion
    }
}