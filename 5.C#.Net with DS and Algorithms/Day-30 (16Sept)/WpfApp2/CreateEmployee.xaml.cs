using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;


namespace WpfApp2
{
    public partial class CreateEmployee : Page
    {
        // Use the Entity Framework context for the database connection
        EmployeeDBEntities context = new EmployeeDBEntities();  // Entity Framework context

        public CreateEmployee()
        {
            InitializeComponent();
        }

        // This method handles the Submit button click to create a new employee
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate input fields
            if (ValidateFields())
            {
                // Create a new Employee object
                Employee newEmployee = new Employee
                {
                    Name = FirstNameTextBox.Text + " " + MiddleNameTextBox.Text + " " + LastNameTextBox.Text,
                    Gender = (MaleRadioButton.IsChecked == true) ? "Male" : "Female",
                    Country = (CountryComboBox.SelectedItem as ComboBoxItem).Content.ToString(),
                    DateOfBirth = DOBPicker.SelectedDate.Value
                };

                // Add the new employee to the context and save the changes to the database
                context.Employees.Add(newEmployee);
                context.SaveChanges();

                // Inform the user that the employee was created
                MessageBox.Show("Employee Created Successfully!");
            }
        }

        // This method validates the input fields
        private bool ValidateFields()
        {
            bool isValid = true;

            // Clear previous validation messages
            ClearValidationMessages();

            // Regular expression for only letters
            Regex onlyLetters = new Regex(@"^[a-zA-Z]+$");

            // Validate First Name
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                FirstNameValidationMessage.Text = "First Name is required";
                isValid = false;
            }
            else if (!onlyLetters.IsMatch(FirstNameTextBox.Text))
            {
                FirstNameValidationMessage.Text = "First Name cannot contain numbers or special characters";
                isValid = false;
            }

            // Validate Last Name
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                LastNameValidationMessage.Text = "Last Name is required";
                isValid = false;
            }
            else if (!onlyLetters.IsMatch(LastNameTextBox.Text))
            {
                LastNameValidationMessage.Text = "Last Name cannot contain numbers or special characters";
                isValid = false;
            }


            // Validate Date of Birth
            if (!DOBPicker.SelectedDate.HasValue)
            {
                DOBValidationMessage.Text = "Date of Birth is required";
                isValid = false;
            }
            else if (DOBPicker.SelectedDate.Value > DateTime.Now)
            {
                DOBValidationMessage.Text = "Date of Birth cannot be in the future";
                isValid = false;
            }

            return isValid;
        }

        // Clears all validation messages
        private void ClearValidationMessages()
        {
            FirstNameValidationMessage.Text = "";
            MiddleNameValidationMessage.Text = "";
            LastNameValidationMessage.Text = "";
            DOBValidationMessage.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
