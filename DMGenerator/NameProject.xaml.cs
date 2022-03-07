using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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
        }

        public void nextBtnNameProject(object sender, MouseButtonEventArgs e)
        {
            string templ = Functionality.templateOfChoice;
            projectName = propertyNameTextBox.Text;
            projectName = projectName.Replace(" ", "_");
            string script = @$"dotnet new {templ} -o c:\temp\Template\{projectName}"; 
            RunScript(script);
            File.Move(@$"c:\temp\Template\{projectName}\Dockerfile.del", @$"c:\temp\Template\{projectName}\Dockerfile");
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
    }
}
