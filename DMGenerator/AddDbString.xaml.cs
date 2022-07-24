using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMGenerator
{
    public partial class AddDbString : Page
    {
        public AddDbString()
        {
            try
            {
                InitializeComponent();
                connectionStringTextBox.Text = "Data Source=Localhost;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
            }
        }

    

        private void finishBtn_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Functionality.connectionStringReplace = connectionStringTextBox.Text;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
            }

            try
            {
                Functionality.ReplaceTags();
            }catch (Exception ex)
            {
                Logger.WriteLog(ex.Message);
            }
}
    }
}
