using System.Windows.Controls;
using System.Windows.Input;

namespace DMGenerator
{
    /// <summary>
    /// Interaction logic for AddPropertiesView.xaml
    /// </summary>
    public partial class AddPropertiesView : Page
    {
        public AddPropertiesView()
        {
            InitializeComponent();

            if(propertiesAddedCheckBox.Items.Count == 0)
            {
            propertiesAddedCheckBox.Items.Add("public int Id { get; set; } ");
            }

            int counterOfArraylistInit = Functionality.props.Count;
            string[] st = new string[counterOfArraylistInit];
            for (int i = 0; i < st.Length; i++)
            {
                propertiesAddedCheckBox.Items.Add("public " + Functionality.types[i] + " " + Functionality.props[i] + " { get; set; } " + Functionality.required[i]);
            }
        }

        private void nextBtnAddProperties(object sender, MouseButtonEventArgs e)
        {

        }

        private void addPropertyButton_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (propertyNameTextBox.Text != "")
            {
                Functionality.props.Add(propertyNameTextBox.Text);
                propertyNameTextBox.Clear();
            }
            Functionality.types.Add(propertyTypeComboBox.Text.ToLower());
            if (propertyRequiredCheckBox.IsChecked ?? false)
            {
                Functionality.required.Add("[Required]");
            }
            else
            {
                Functionality.required.Add("");
            }
            propertiesAddedCheckBox.Items.Clear();
            propertiesAddedCheckBox.Items.Add("public int Id { get; set; } ");
            int counterOfArraylist = Functionality.props.Count;
            string[] str = new string[counterOfArraylist];
            for (int i = 0; i < str.Length; i++)
            {
                propertiesAddedCheckBox.Items.Add("public " + Functionality.types[i] + " " + Functionality.props[i] + " { get; set; } " + Functionality.required[i]);
            }
        }

        private void removePropertyButton_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            //TODO:
            //Get ID numpber
            //Functionality.props.//get id where prop = propertyNameTextBox.SelectedText

            //Remove ID number for all property lists
            //Functionality.props.Remove(//ID);

            //Remove selected text
            if (propertyNameTextBox.SelectedText != null)
            {
            //propertyNameTextBox.Text.Remove(propertyNameTextBox.SelectedText);
            }
        }
    }
}
