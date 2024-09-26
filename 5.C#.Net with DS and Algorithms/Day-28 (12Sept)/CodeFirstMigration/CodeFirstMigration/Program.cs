using CodeFirstMigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCrudOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Choose from Below Options");
                Console.WriteLine("1: Add Employee 2: Update Employee 3: Delete Employee 4: Get Employees 5: Exit");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        UpdateEmployee();
                        break;
                    case 3:
                        DeleteEmployee();
                        break;
                    case 4:
                        GetEmployees();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please choose again.");
                        break;
                }
            } while (choice != 5);
        }

        static void AddEmployee()
        {
            using (var context = new AppDbContext())
            {
                var departments = context.Departments.ToList();
                Console.WriteLine("Available Departments:");
                foreach (var department in departments)
                {
                    Console.WriteLine($"Department ID: {department.Id}, Department Name: {department.Name}");
                }

                Console.WriteLine("Enter Employee Name:");
                var name = Console.ReadLine();

                Console.WriteLine("Enter Employee Gender:");
                var gender = Console.ReadLine();

                Console.WriteLine("Enter Employee Age:");
                var age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Employee Salary:");
                var salary = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Department Id:");
                var deptId = int.Parse(Console.ReadLine());

                var employee = new Employee
                {
                    Name = name,
                    Gender = gender,
                    Age = age,
                    Salary = salary,
                    DeptId = deptId,

                };

                context.Employees.Add(employee);
                context.SaveChanges();

                Console.WriteLine($"------------------Employee Added with ID: {employee.Id}------------------");
            }
        }

        static void UpdateEmployee()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter Employee Id to be Updated:");
                int id = int.Parse(Console.ReadLine());

                var employee = context.Employees.Find(id);
                if (employee != null)
                {
                    Console.WriteLine("Choose an Option to Update:");
                    Console.WriteLine("1: Update Name 2: Update Age 3: Update Gender 4: Update Salary 5: Update Department 6: Update Hire Date 7: Update Phone Number");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter New Name:");
                            employee.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Age:");
                            employee.Age = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter New Gender:");
                            employee.Gender = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New Salary:");
                            employee.Salary = decimal.Parse(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Enter New Department Id:");
                            employee.DeptId = int.Parse(Console.ReadLine());
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            return;
                    }

                    context.SaveChanges();
                    Console.WriteLine("------------------Employee Updated------------------");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }

        static void DeleteEmployee()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Enter Employee Id to be Deleted:");
                int id = int.Parse(Console.ReadLine());

                var employee = context.Employees.Find(id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    Console.WriteLine("------------------Employee Deleted------------------");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }

        static void GetEmployees()
        {
            using (var context = new AppDbContext())
            {
                var employees = context.Employees.ToList();
                if (employees.Count > 0)
                {
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.Id}; Name: {employee.Name}; Gender: {employee.Gender}; Age: {employee.Age}; Salary: {employee.Salary}; Department: {employee.DeptId}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }
            }
        }
    }
}


