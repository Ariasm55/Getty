using System.Windows;
using Collective.AgentClient.ViewModel;
using Collective.Library;
using Microsoft.Win32;
using MessageBox = System.Windows.MessageBox;

namespace Collective.AgentClient
{
    /// <summary>
    /// Description for Main2View.
    /// </summary>
    public partial class Main2View : Window
    {
        /// <summary>
        /// Initializes a new instance of the Main2View class.
        /// </summary>
        public Main2View()
        {
            InitializeComponent();
            SystemEvents.SessionSwitch += OnSessionSwitch;
        }

        protected  void Dispose(bool disposing)
        {
            if (disposing)
            {
                SystemEvents.SessionSwitch -= OnSessionSwitch;
            }


            
        }


        private void OnSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                if (MainViewModel.Globals.IsPaused == false)
                {
                    MainViewModel.Globals.GlobalInt = 0;
                    
                    MainViewModel.UserlockPause();
                }
                
                MainViewModel.Globals.GlobalInt = 0;
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                if (MainViewModel.Globals.IsPaused == false)
                {
                    MainViewModel.UserlockUnPause();
                    MainViewModel.Globals.GlobalInt = 1;
                    const string message = "You lelt your Computer and did not Set a Pause";
                    const string caption = "No Pause Alert";
                    MessageBox.Show(message, caption, MessageBoxButton.OK);
                    
                }
            }

            else if (e.Reason == SessionSwitchReason.SessionLogoff)
            {
                MessageBox.Show("LOGOFF");
            }
            else if (e.Reason == SessionSwitchReason.RemoteConnect)
            {
                MessageBox.Show("REMOTECONTROL");
            }

          }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            switch (GlobalVariables.GlobalsLib.CanClose)
            {
                case false:
                    e.Cancel = true;
                    break;
                case true:
                    e.Cancel = false;
                    GlobalVariables.GlobalsLib.CanClose = false;
                    break;
            }
        }
    }
		
		
    }
