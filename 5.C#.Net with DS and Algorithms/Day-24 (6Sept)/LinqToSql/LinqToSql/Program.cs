using LinqToSql;
using System;
using System.Linq;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CompanyDB;Integrated Security=True";
            using (var db = new CompanyDBDataContext(connectionString))
            {
                // Show list of all employees
                ShowAllEmployees(db);

                // Create a new employee
                CreateEmployee(db);
               ShowAllEmployees(db);

               //Update an employee
               UpdateEmployee(db);
               ShowAllEmployees(db);

                // Delete an employee
                DeleteEmployee(db);
                ShowAllEmployees(db);
            }
            Console.ReadLine();
        }

        // 1. Show list of all employees
        static void ShowAllEmployees(CompanyDBDataContext db)
        {
            Console.WriteLine("List of all employees:");
            var employees = db.Employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id: {employee.EmployeeId}, Name: {employee.Name}, Gender: {employee.Gender}, Age: {employee.Age}, Salary: {employee.Salary}, DeptId: {employee.DeptId}");
            }
        }

        // 2. Create a new employee
        static void CreateEmployee(CompanyDBDataContext db)
        {
            Console.WriteLine("\nEnter the employee details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("DeptId: ");
            int deptId = int.Parse(Console.ReadLine());

            Employee newEmployee = new Employee
            {
                Name = name,
                Gender = gender,
                Age = age,
                Salary = salary,
                DeptId = deptId
            };

            db.Employees.InsertOnSubmit(newEmployee);
            db.SubmitChanges();

            Console.WriteLine("Employee created successfully.");
        }

        // 3. Update an existing employee
        static void UpdateEmployee(CompanyDBDataContext db)
        {
            Console.Write("\nEnter the Employee ID to update: ");
            int empId = int.Parse(Console.ReadLine());

            var employee = db.Employees.SingleOrDefault(e => e.EmployeeId == empId);

            if (employee != null)
            {
                Console.WriteLine("Enter the updated details:");
                Console.Write("Name: ");
                employee.Name = Console.ReadLine();
                Console.Write("Gender: ");
                employee.Gender = Console.ReadLine();
                Console.Write("Age: ");
                employee.Age = int.Parse(Console.ReadLine());
                Console.Write("Salary: ");
                employee.Salary = decimal.Parse(Console.ReadLine());
                Console.Write("DeptId: ");
                employee.DeptId = int.Parse(Console.ReadLine());

                db.SubmitChanges();
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // 4. Delete an employee
        static void DeleteEmployee(CompanyDBDataContext db)
        {
            Console.Write("\nEnter the Employee ID to delete: ");
            int empId = int.Parse(Console.ReadLine());

            var employee = db.Employees.SingleOrDefault(e => e.EmployeeId == empId);

            if (employee != null)
            {
                db.Employees.DeleteOnSubmit(employee);
                db.SubmitChanges();
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
