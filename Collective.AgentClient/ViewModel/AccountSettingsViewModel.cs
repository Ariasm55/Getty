using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Collective.AgentClient.Messages;
using Collective.AgentClient.View;
using Collective.Model;
using GalaSoft.MvvmLight;
using Collective.AgentClient.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Collective.AgentClient.View;
using Collective.Library;

namespace Collective.AgentClient.ViewModel
{
    public class AccountSettingsViewModel : ViewModelBase
    {
        #region Propertys

        private static IDataService _dataService;

        #region OldPassword
        /// <summary>
        /// The <see cref="OldPassword" /> property's name.
        /// </summary>
        public const string OldPasswordPropertyName = "OldPassword";

        private string _oldpassword = "";

        /// <summary>
        /// Sets and gets the OldPassword property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OldPassword
        {
            get
            {
                return _oldpassword;
            }

            set
            {
                if (_oldpassword == value)
                {
                    return;
                }

                _oldpassword = value;
                RaisePropertyChanged(OldPasswordPropertyName);

            }
        }
    
        #endregion

        #region NewPassword
    /// <summary>
        /// The <see cref="NewPassword" /> property's name.
        /// </summary>
        public const string NewPasswordPropertyName = "NewPassword";

        private string _newPassword = "";

        /// <summary>
        /// Sets and gets the NewPassword property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }

            set
            {
                if (_newPassword == value)
                {
                    return;
                }

                _newPassword = value;
                RaisePropertyChanged(NewPasswordPropertyName);
            }
        }
    #endregion

        #region Confirm Password
        /// <summary>
        /// The <see cref="ConfirmPassword" /> property's name.
        /// </summary>
        public const string ConfirmPasswordPropertyName = "ConfirmPassword";

        private string _confirmPassword = "";

        /// <summary>
        /// Sets and gets the ConfirmPassword property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }

            set
            {
                if (_confirmPassword == value)
                {
                    return;
                }

                _confirmPassword = value;
                RaisePropertyChanged(ConfirmPasswordPropertyName);
            }
        }
        #endregion

        #region ConfirmPasswordButtom
        /// <summary>
        /// The <see cref="ConfirmPasswordButton" /> property's name.
        /// </summary>
        public const string ConfirmPasswordButtonPropertyName = "ConfirmPasswordButton";

        private bool _confirmPasswordButton = false;

        /// <summary>
        /// Sets and gets the ConfirmPasswordButton property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ConfirmPasswordButton
        {
            get
            {
                return _confirmPasswordButton;
            }

            set
            {
                if (_confirmPasswordButton == value)
                {
                    return;
                }

                _confirmPasswordButton = value;
                RaisePropertyChanged(ConfirmPasswordButtonPropertyName);
            }
        }
        #endregion

        #region Agent
        /// <summary>
        /// The <see cref="Agent" /> property's name.
        /// </summary>
        public const string AgentPropertyName = "Agent";

        private string _agent = "";

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

        #region CloseAction

        public Action CloseAction { get; set; }

        #endregion

        #endregion

        #region Private Methods

        public AccountSettingsViewModel(IDataService dataService)
        {
            _dataService = dataService;
            RegisterCommand();
        }

        private void RegisterCommand()
        {
            ChangePassordCommand = new RelayCommand(ChangePassword);
        }

        #region Commands
        public RelayCommand ChangePassordCommand { get; set; }
        public event EventHandler OnRequesteClose;
        
        #endregion

        private void ChangePassword()
        {
            if (NewPassword == ConfirmPassword)
            {
                _dataService.ChangePassword(Agent, ConfirmPassword, OldPassword,
               (responce, error) =>
               {
                   if (error != null)
                   {
                       MessageBox.Show(error.Message);

                   }
                   
               });
                MessageBox.Show("Your Password has been Changed");
                GlobalVariables.GlobalsLib.CanClose = true;
                CloseAction();
                GlobalVariables.GlobalsLib.CanClose = false;
            }

            else
            {
                MessageBox.Show("The Passwords Do not Match");
            }
           
        }

        #endregion
    }
}
