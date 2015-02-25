using System.Windows;
using Collective.Library;

namespace Collective.AgentClient.View
{
    /// <summary>
    /// Description for PauseView.
    /// </summary>
    public partial class PauseView : Window
    {
        /// <summary>
        /// Initializes a new instance of the PauseView class.
        /// </summary>
        public PauseView()
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