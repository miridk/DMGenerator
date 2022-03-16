using System.Windows.Controls;
using System.Windows.Input;

namespace DMGenerator
{
    public partial class AddDbString : Page
    {
        public AddDbString()
        {
            InitializeComponent();
            connectionStringTextBox.Text = "Data Source=Localhost;Initial Catalog=TisIsATest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void finishBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Functionality.connectionStringReplace = connectionStringTextBox.Text;
            Functionality.ReplaceTags();
        }
    }
}
