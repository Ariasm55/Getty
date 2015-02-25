using System.Data.Metadata.Edm;
using System.Windows;
using Collective.AgentClient.ViewModel;

namespace Collective.AgentClient.View
{
    /// <summary>
    /// Description for MessagesView.
    /// </summary>
    public partial class MessagesView : Window
    {
        /// <summary>
        /// Initializes a new instance of the MessagesView class.
        /// </summary>
        public MessagesView()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var agent = MainViewModel.Globals.AgentGlobal;
            Collective.Model.RecipientModel.ReadMsg((long)MsgID.Content, agent);
            e.Cancel = false;
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}