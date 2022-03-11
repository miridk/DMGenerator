using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace DMGenerator
{
    /// <summary>
    /// Interaction logic for FinnishedInstalling.xaml
    /// </summary>
    public partial class FinnishedInstalling : Page
    {
        public FinnishedInstalling()
        {
            InitializeComponent();
        }



        private void startSeviceBtn(object sender, MouseButtonEventArgs e)
        {
            string templatePath = Functionality.rootfolder;
            //templatePath = templatePath.Replace(@"\", "/");
            //templatePath = $@"{templatePath}/{Functionality.projectName}";

            //string command = @$"Start-Process -FilePath ""{templatePath}\{Functionality.projectName}\Run_Solution.ps1""";
            string command = @"invoke -expression 'cmd /c start powershell -Command { Run_Solution.ps1; set-location """ +templatePath + "\"\\\"" + Functionality.projectName+"\"\\\" ; sleep 3 }";
            //invoke -expression 'cmd /c start powershell -Command { docker compose up --build; set-location ".\"; get-childitem ; sleep 3}'
            //string command = @$"docker-compose -f {templatePath}/docker-compose.yml up -d";

            ////command = @$"Start-Process -FilePath http://localhost:14800/swagger/index.html";

            //StringBuilder sb = new StringBuilder();
            //sb.Append(command);
            //// flush every 20 seconds as you do it
            //File.AppendAllText(@"C:\Temp\LogPath.txt", sb.ToString());
            //sb.Clear();

            RunDockerComposeScript(command);
        }


        private void RunDockerComposeScript(string command)
        {

            string strCmdText = command;
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe";
            process.StartInfo.Arguments = strCmdText;

            process.Start();
            string s = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            StreamWriter strm = File.CreateText(@"c:\temp\StandardOutput2.txt");
            strm.Flush();
            strm.Close();

            using (StreamWriter outfile = new StreamWriter(@"c:\temp\StandardOutput2.txt", true))
            {
                outfile.Write(s);
            }


            //Process.Start(@"C:\windows\system32\windowspowershell\v1.0\powershell.exe", @"-File ""C:\Temp\Template\Test_API\Run_Solution.ps1""");

            //var process = new Process();
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.CreateNoWindow = false;
            ////process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe";
            //process.StartInfo.Arguments = @"""C:\Temp\Template\Test_API\Run_Solution.ps1""";

            //process.Start();
            ////string lines = process.StandardOutput.ReadToEnd();

            //process.WaitForExit();
        }
    }
}
