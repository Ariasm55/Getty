using System.Windows.Forms;

namespace Collective.AgentClient.Updater
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        public string Info { get { return lblInfo.Text; } set { lblInfo.Text = value; } }

        
        

        }
}
