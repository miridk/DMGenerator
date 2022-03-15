using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DMGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string textToReplace = "";
        public string text = "";
        public string rootfolder = @"C:\Temp\Template";
        public string efType = "";
        public static string templateOfChoice = "";

        public static List<string> templates = new List<string>();
        public static List<string> props = new List<string>();
        public static List<string> types = new List<string>();
        public static List<string> required = new List<string>();
        public static List<string> propsConcatList = new List<string>();
        public static List<string> cPropsConcatList = new List<string>();
        public static List<string> efPropsConcatList = new List<string>();
        public static List<string> efDataContextPropsConcatList = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new HomeView();
        }

        private void homeBtn_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new HomeView();
        }
       
        private void createBackendBtn_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new FirstViewAddService();
        }

        private void microserviceBtn_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new MicroservicesView();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void closBtn(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void aboutBtn_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new About();
        }
    }
}
