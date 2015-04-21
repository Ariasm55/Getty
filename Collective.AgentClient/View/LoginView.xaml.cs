using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Forms;
using Collective.AgentClient.ViewModel;
using Collective.Library;

namespace Collective.AgentClient.View
{
    /// <summary>
    /// Description for LoginView.
    /// </summary>
    public partial class LoginView : Window
    {
        /// <summary>
        /// Initializes a new instance of the LoginView class.
        /// </summary>
        public LoginView()
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

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PasswordBoxpass_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}