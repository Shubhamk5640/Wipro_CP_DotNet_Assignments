using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstCrudOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Read Employee Data");
                Console.WriteLine("2. Insert Employee Data");
                Console.WriteLine("3. Update Employee Data");
                Console.WriteLine("4. Delete Employee Data");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ReadEmployees();
                        break;
                    case "2":
                        InsertEmployee();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        DeleteEmployee();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

        // Read Employees
        static void ReadEmployees()
        {
            using (var context = new DBFirstCrudEntities())  // Generated DbContext
            {
                var employees = context.Employees.ToList();
                Console.WriteLine("\nEmployee Data:");
                Console.WriteLine("ID\tName\tGender\tAge\tSalary\tDeptId");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.Id}\t{emp.Name}\t{emp.Gender}\t{emp.Age}\t{emp.Salary}\t{emp.DeptId}");
                }
            }
        }

        // Insert a new Employee with try-catch
        static void InsertEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            int deptId;
            using (var context = new DBFirstCrudEntities())
            {
                bool validDeptId = false;
                do
                {
                    Console.Write("Enter DeptId: ");
                    deptId = int.Parse(Console.ReadLine());

                    // Check if DeptId exists in Department table
                    validDeptId = context.Departments.Any(d => d.Id == deptId);
                    if (!validDeptId)
                    {
                        Console.WriteLine("DeptId does not exist. Please enter a valid DeptId.");
                    }
                } while (!validDeptId);

                var newEmployee = new Employee
                {
                    Name = name,
                    Gender = gender,
                    Age = age,
                    Salary = salary,
                    DeptId = deptId
                };
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                Console.WriteLine("Employee inserted successfully.");
            }

            ReadEmployees(); // Display updated table
        }

        // Update an Employee
        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            using (var context = new DBFirstCrudEntities())
            {
                var employee = context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    Console.Write("Enter new Name: ");
                    employee.Name = Console.ReadLine();
                    Console.Write("Enter new Salary: ");
                    employee.Salary = decimal.Parse(Console.ReadLine());

                    context.SaveChanges();
                    Console.WriteLine("Employee updated successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }

            ReadEmployees(); // Display updated table
        }

        // Delete an Employee
        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (var context = new DBFirstCrudEntities())
            {
                var employee = context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }

            ReadEmployees(); // Display updated table
        }
    }
}
