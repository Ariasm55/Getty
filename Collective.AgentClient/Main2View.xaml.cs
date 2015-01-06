using System.Windows;
using System.Diagnostics;
using System.Windows.Navigation;
using Microsoft.Win32;

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
            MessageBox.Show("SessionSwitch");
        }
        }
		
		
    }
