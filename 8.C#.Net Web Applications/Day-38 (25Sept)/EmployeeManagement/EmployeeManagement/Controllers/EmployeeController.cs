using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // Static list of employees to simulate database
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Shubham", MiddleName = "P", LastName = "Kumbhar", Salary = 50000,Gender = "Male", Email = "kumbharshubham5640@gmail.com", PhoneNumber = "9865325665", Address = "143 MG Road", Country = "India", Age = 26, DateOfBirth = new DateTime(1999, 09, 10) },
            new Employee { Id = 2, FirstName = "Sanket", MiddleName = "U", LastName = "Mane", Salary = 60000,Gender = "Male", Email = "sanket@gmail.com", PhoneNumber = "8965325686", Address = "456 Street", Country = "India", Age = 29, DateOfBirth = new DateTime(1998, 3, 20) },
            new Employee { Id = 3, FirstName = "Pankaj", MiddleName = "C", LastName = "Sarnobat", Salary = 70000,Gender = "Male", Email = "pankaj@gmail.com", PhoneNumber = "8765325633", Address = "123 Road", Country = "India", Age = 30, DateOfBirth = new DateTime(1995, 6, 28) },
            new Employee { Id = 4, FirstName = "Sangram", MiddleName = "J", LastName = "Patil", Salary = 80000,Gender = "Male", Email = "sangram@gmail.com", PhoneNumber = "986532569", Address = "101 BJ Road", Country = "India", Age = 34, DateOfBirth = new DateTime(1990, 2, 17) },
            new Employee { Id = 5, FirstName = "Sudhansh", MiddleName = "V", LastName = "Bidkar", Salary = 55000,Gender = "Male", Email = "sushansh@gmail.com", PhoneNumber = "9765325554", Address = "154 Circle", Country = "India", Age = 38, DateOfBirth = new DateTime(1989, 5, 22) }
        };

        // This is the method to display the list of employees
        [Route("employee-list")]
        public IActionResult Index()
        {
            // Pass the list of employees to the view
            return View(employees);
        }

        // This method displays the create employee form (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // This method processes the form submission (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Assign a new Id to the new employee
                employee.Id = employees.Count + 1;

                // Add the new employee to the list
                employees.Add(employee);

                // Redirect to the employee list page after successful creation
                return RedirectToAction("Index");
            }

            // If validation fails, return the same view with validation messages
            return View(employee);
        }
    }
}
