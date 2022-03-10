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
            templatePath = templatePath.Replace(@"\", "/");
            templatePath = $@"{templatePath}/{Functionality.projectName}";
            string command = @$"docker-compose -f {templatePath}/docker-compose.yml up -d";
            RunDockerComposeScript(command);
            ////command = @$"Start-Process -FilePath http://localhost:14800/swagger/index.html";
            ////RunDockerComposeScript(command);

            //StreamWriter strm = File.CreateText(@"C:\Temp\LogPath.txt");

            //using (StreamWriter outfile = new StreamWriter(@"C:\Temp\LogPath.txt", true))
            //{
            //    outfile.Write($@"{templatePath}/{Functionality.projectName}");
            //}

        }


        private void RunDockerComposeScript(string command)
        {

            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe";
            process.StartInfo.Arguments = command;

            process.Start();
            //string lines = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
        }
    }
}
