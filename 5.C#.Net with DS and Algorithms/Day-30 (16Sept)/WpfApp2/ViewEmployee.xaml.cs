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
    public partial class ViewEmployee : Page
    {
        EmployeeDBEntities context = new EmployeeDBEntities();  

        public ViewEmployee()
        {
            InitializeComponent();
        }

        // Event handler to fetch and display employee details
        private void GetEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(EmployeeIdTextBox.Text, out int employeeId))
            {
                var employee = context.Employees.SingleOrDefault(emp => emp.EmployeeId == employeeId);

                if (employee != null)
                {
                    // Display employee details in text blocks
                    NameTextBlock.Text = employee.Name;
                    GenderTextBlock.Text = employee.Gender;
                    CountryTextBlock.Text = employee.Country;
                    DOBTextBlock.Text = employee.DateOfBirth?.ToString("d");
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
    }
}
