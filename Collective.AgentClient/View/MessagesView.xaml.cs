using System.Windows;

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

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}