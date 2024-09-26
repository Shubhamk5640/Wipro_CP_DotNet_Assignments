using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            ClearValidationMessages();

            // Validate First Name
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                FirstNameValidationMessage.Text = "First Name is required";
                isValid = false;
            }

            // Validate Middle Name (Optional)
            if (string.IsNullOrWhiteSpace(MiddleNameTextBox.Text))
            {
                MiddleNameValidationMessage.Text = "Middle Name is required";
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                LastNameValidationMessage.Text = "Last Name is required";
                isValid = false;
            }

            // Validate Date of Birth
            if (!DOBPicker.SelectedDate.HasValue)
            {
                DOBValidationMessage.Text = "Date of Birth is required";
                isValid = false;
            }
            else
            {
                DateTime dob = DOBPicker.SelectedDate.Value;
                if (dob > DateTime.Now)
                {
                    DOBValidationMessage.Text = "Date of Birth cannot be in the future";
                    isValid = false;
                }
            }

            // If all validations pass, show entered data
            if (isValid)
            {
                string firstName = FirstNameTextBox.Text;
                string middleName = MiddleNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                string country = (CountryComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                string dob = DOBPicker.SelectedDate.Value.ToShortDateString();

                // Show a message box with all the entered data
                MessageBox.Show($"First Name: {firstName}\nMiddle Name: {middleName}\nLast Name: {lastName}\nCountry: {country}\nDate of Birth: {dob}",
                                "Submitted Data", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearValidationMessages()
        {
            FirstNameValidationMessage.Text = "";
            MiddleNameValidationMessage.Text = "";
            LastNameValidationMessage.Text = "";
            DOBValidationMessage.Text = "";
        }
    }
}
    
