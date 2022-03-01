using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Design_4
{
    /// <summary>
    /// Interaction logic for AddDbString.xaml
    /// </summary>
    public partial class AddDbString : Page
    {
        public AddDbString()
        {
            InitializeComponent();
            connectionStringTextBox.Text = "Data Source=USD1928;Initial Catalog=TisIsATest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }



        private void finishBtn_Click(object sender, MouseButtonEventArgs e)
        {
            Functionality.connectionStringReplace = connectionStringTextBox.Text;
            Functionality.ReplaceTags();
        }
    }
}
