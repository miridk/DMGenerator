using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Design_4
{
    /// <summary>
    /// Interaction logic for AddNewServiceView.xaml
    /// </summary>
    public partial class AddNewServiceView : Page
    {
        public static List<string> listOfTemplates = new List<string>();
        private static List<string> res = new List<string>();
        string script = "dotnet new -l";

        public AddNewServiceView()
        {
            InitializeComponent();

            res.Clear();
            FeedbackFromPowerShellRun(script);
            res.RemoveAt(0);
            res.RemoveAt(0);
            listBoxOfTemplates.Items.Clear();
            for (int b = 0 ; b < res.Count; b++)
            {
                listBoxOfTemplates.Items.Add(res[b].ToString());
            }
            listBoxOfTemplates.SelectedIndex = 0;
        }

        private void nextBtnAddNewService(object sender, MouseButtonEventArgs e)
        {
            if (listBoxOfTemplates.SelectedItem != null)
            {
                Functionality.templateOfChoice = listBoxOfTemplates.SelectedItem.ToString();
            }
            else
            {
                Functionality.templateOfChoice = Functionality.templates[0].ToString();
            }
        }

        private void FeedbackFromPowerShellRun(string script)
        {
            string r;
            string[] listOfr;

            string strCmdText = script;
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe";
            process.StartInfo.Arguments = strCmdText;

            process.Start();
            string s = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            using (StreamWriter outfile = new StreamWriter(@"c:\temp\StandardOutput.txt", true))
            {
                outfile.Write(s);
            }

            List<string> lines = File.ReadLines(@"c:\temp\StandardOutput.txt").ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                r = Regex.Replace(lines[i].ToString(), @"\s\s+", ",");

                listOfr = r.Split(',');

                if (listOfr.Length > 1)
                {
                        res.Add(listOfr[1]);
                }
            }
        }

        private void addNewTemplate_Clicked(object sender, MouseButtonEventArgs e)
        {
         
        }
    }
}
