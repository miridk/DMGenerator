using System.Diagnostics;
using System.IO;
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
            CreateDockerCompose(projectName);
        }

        public static async Task CreateDockerCompose(string projectName)
        {
            string text =
                "version: '3.4'" +
                "" +
                "services:" +
                "  db:" +
                "    image: \"mcr.microsoft.com/mssql/server\"" +
                "    environment:" +
                "      SA_PASSWORD: \"#Admin123\"" +
                "      ACCEPT_EULA: \"Y\"" +
                "    ports:" +
                "    -\"1433:1433\"" +

                "  "+projectName+":" +
                "    image: ${ DOCKER_REGISTRY -}" + projectName + "" +
                "    build:" +
                "      context: ." +
                "      dockerfile: Dockerfile" +
                "    environment:" +
                "      ConnectionStrings__DefaultConnection: \"Server=db,1433;Initial Catalog=FinanceUnitDB;User ID=sa;password=#Admin123;MultipleActiveResultSets=true\"" +
                "    ports:" +
                "    -\"4800:80\"" +
                "    depends_on:" +
                "      -db";

            await File.WriteAllTextAsync(@$"c:\temp\Template\{projectName}\Docker-Compose.yml", text);
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
