using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DMGenerator
{
    /// <summary>
    /// Interaction logic for AddNewTemplate.xaml
    /// </summary>
    public partial class AddNewTemplate : Page
    {
        public AddNewTemplate()
        {
            InitializeComponent();
        }

        private void findNugetFileBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Nuget files (*.nupkg)|*.nupkg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                templatePathTextBox.Text = openFileDialog.FileName;
        }

        private void nextBtnAddNewTemplate(object sender, MouseButtonEventArgs e)
        {
;
        }

        private void RunScript(string script)
        {
            string strCmdText = script;
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe";
            process.StartInfo.Arguments = strCmdText;

            process.Start();
            string lines = process.StandardOutput.ReadToEnd();

            powerShellOutputListBox.Items.Add(lines.ToString());

            process.WaitForExit();
        }

        private void installTemplateBtn(object sender, RoutedEventArgs e)
        {
            string templatePath = templatePathTextBox.Text;
            templatePath = templatePath.Replace(" ", "` ");
            string script = @$"dotnet new --install {templatePath}";
            RunScript(script);
        }
    }
}
