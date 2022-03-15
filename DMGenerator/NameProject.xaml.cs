using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace DMGenerator
{
    /// <summary>
    /// Interaction logic for NameProject.xaml
    /// </summary>
    public partial class NameProject : Page
    {
        public static string projectName = "";
        public NameProject()
        {
            InitializeComponent();
            portNumberTextBox.Text = "4800";
        }

        private void selectPathFileBtn_Clicked(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderPathTextBox.Text = diag.SelectedPath;
                Functionality.rootfolder = diag.SelectedPath;
            }
            
        }

        public void nextBtnNameProject(object sender, MouseButtonEventArgs e)
        {
            string templ = Functionality.templateOfChoice;
            projectName = propertyNameTextBox.Text;
            Functionality.projectName = projectName.Replace(" ", "_");
            Functionality.portNo = portNumberTextBox.Text;
            string dir = @$"{Functionality.rootfolder}\{Functionality.projectName}\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string script = @$"dotnet new {templ} -o {dir}{Functionality.projectName}"; 
            RunScript(script);
            File.Move(@$"{dir}{Functionality.projectName}\Dockerfile.del", @$"{dir}{Functionality.projectName}\Dockerfile");
        }

        private static void RunScript(string script)
        {
            string strCmdText = script;
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe";
            process.StartInfo.Arguments = strCmdText;
            process.Start();
            process.WaitForExit();
        }

        //private void RunProgressBar()
        //{
        //    progressBar.Visibility = Visibility.Visible;
        //    Duration duration = new Duration(TimeSpan.FromSeconds(1));
        //    DoubleAnimation doubleanimation = new DoubleAnimation(progressBar.Value + 20, duration);
        //    progressBar.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, doubleanimation);
        //}
    }
}
