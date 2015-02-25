using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using Collective.Library;

namespace Collective.AgentClient.View
{
    /// <summary>
    /// Description for LoginView.
    /// </summary>
    public partial class ForgotPasswordView : Window
    {
        /// <summary>
        /// Initializes a new instance of the LoginView class.
        /// </summary>
        public ForgotPasswordView()
        {
            InitializeComponent();
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