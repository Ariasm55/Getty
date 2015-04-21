using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Xml.Linq;
using Collective.AgentClient.Properties;
using Collective.AgentClient.Updater;
using Collective.AgentClient.ViewModel;
using Collective.Library;
using Microsoft.Win32;
using MessageBox = System.Windows.MessageBox;


namespace Collective.AgentClient
{
    /// <summary>
    /// Description for Main2View.
    /// </summary>
    public partial class Main2View
    {

        /// <summary>
        /// Initializes a new instance of the Main2View class.
        /// </summary>

        public Main2View()
        {
            var processName = Process.GetCurrentProcess().ProcessName;
            var processes = Process.GetProcessesByName(processName).Count();
            if (processes == 1)
            {
                
                if (Settings.Default.AutoCheckForUpdates)
                {
                    ThreadPool.QueueUserWorkItem(w => Updater.Updater.CheckForUpdate(ShowUpdateDialog));
                    
                }
                
                    InitializeComponent();
                    SystemEvents.SessionSwitch += OnSessionSwitch;
                
            }
            else
            {
                MessageBox.Show("Application already running");
                Application.Current.Shutdown(0);
            }

        }

        
        private void ShowUpdateDialog(Version appVersion, Version newVersion, XDocument doc)
        {
            try
            {
                if (!Dispatcher.CheckAccess())
                {
                    Dispatcher.Invoke(new Action<Version, Version, XDocument>(ShowUpdateDialog), appVersion, newVersion,
                        doc);
                    return;
                }
                using (var f = new UpdateForm())
                {
                    //f.Text = string.Format(f.Text, appVersion);
                    if (doc.Root != null)
                        f.Info = string.Format(f.Info, newVersion, (DateTime) doc.Root.Element("date"));
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Updater.Updater.LaunchUpdater(doc);
                        f.Close();
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
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
                    const string message = "You left your Computer and did not Set a Pause";
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
