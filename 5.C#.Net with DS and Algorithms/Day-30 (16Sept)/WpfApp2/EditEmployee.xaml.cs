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

namespace WpfApp2
{
    public partial class EditEmployee : Page
    {
        EmployeeDBEntities context = new EmployeeDBEntities(); // Entity Framework context

        public EditEmployee()
        {
            InitializeComponent();
        }

        // Event handler to get employee details based on Employee ID
        private void GetEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EmployeeIdTextBox.Text, out int employeeId))
            {
                // Fetch the employee details
                var employee = context.Employees.SingleOrDefault(emp => emp.EmployeeId == employeeId);

                if (employee != null)
                {
                    // Populate fields with employee data
                    NameTextBox.Text = employee.Name;
                    if (employee.Gender == "Male")
                    {
                        MaleRadioButton.IsChecked = true;
                    }
                    else
                    {
                        FemaleRadioButton.IsChecked = true;
                    }
                    CountryComboBox.SelectedItem = employee.Country;
                    DOBPicker.SelectedDate = employee.DateOfBirth;
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Employee ID.");
            }
        }

       
        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EmployeeIdTextBox.Text, out int employeeId))
            {
            
                var employee = context.Employees.SingleOrDefault(emp => emp.EmployeeId == employeeId);

                if (employee != null)
                {
                   
                    employee.Name = NameTextBox.Text;
                    employee.Gender = (MaleRadioButton.IsChecked == true) ? "Male" : "Female";
                    employee.Country = (CountryComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                    employee.DateOfBirth = DOBPicker.SelectedDate.Value;

                    context.SaveChanges();  

                    MessageBox.Show("Employee updated successfully!");
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }
            }
        }
    }
}

