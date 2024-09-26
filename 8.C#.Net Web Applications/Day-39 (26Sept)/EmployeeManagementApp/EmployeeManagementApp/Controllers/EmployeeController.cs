using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EmployeeManagementApp.Models;


namespace Employee_Management_Web_App.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private static List<Employee> employees = new List<Employee>
        {
           new Employee { Id = 1, FirstName = "Shubham", MiddleName = "P", LastName = "Kumbhar", Salary = 50000,Gender = "Male", Email = "kumbharshubham5640@gmail.com", PhoneNumber = "9865325665", Address = "143 MG Road", Country = "India", Age = 26, DateOfBirth = new DateTime(1999, 09, 10) },
            new Employee { Id = 2, FirstName = "Sanket", MiddleName = "U", LastName = "Mane", Salary = 60000,Gender = "Male", Email = "sanket@gmail.com", PhoneNumber = "8965325686", Address = "456 Street", Country = "India", Age = 29, DateOfBirth = new DateTime(1998, 3, 20) },
            new Employee { Id = 3, FirstName = "Pankaj", MiddleName = "C", LastName = "Sarnobat", Salary = 70000,Gender = "Male", Email = "pankaj@gmail.com", PhoneNumber = "8765325633", Address = "123 Road", Country = "India", Age = 30, DateOfBirth = new DateTime(1995, 6, 28) },
            new Employee { Id = 4, FirstName = "Sangram", MiddleName = "J", LastName = "Patil", Salary = 80000,Gender = "Male", Email = "sangram@gmail.com", PhoneNumber = "986532569", Address = "101 BJ Road", Country = "India", Age = 34, DateOfBirth = new DateTime(1990, 2, 17) },
            new Employee { Id = 5, FirstName = "Sudhansh", MiddleName = "V", LastName = "Bidkar", Salary = 55000,Gender = "Male", Email = "sushansh@gmail.com", PhoneNumber = "9765325554", Address = "154 Circle", Country = "India", Age = 38, DateOfBirth = new DateTime(1989, 5, 22) }
        };


        [Route("employee-list")]
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();

            string connectionString = _configuration.GetConnectionString("EmployeeDbConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, FirstName, MiddleName, LastName, Salary, Email, PhoneNumber, Address, Country, Age, DateOfBirth " +
                               "FROM Employees ORDER BY Id DESC";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"]?.ToString(),
                        LastName = reader["LastName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Country = reader["Country"].ToString(),
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"]
                    };

                    employees.Add(employee);
                }

                reader.Close();
                connection.Close();
            }

            return View(employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                
                string connectionString = _configuration.GetConnectionString("EmployeeDbConnection");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Employees (FirstName, MiddleName, LastName, Salary, Email, PhoneNumber, Address, Country, Age, DateOfBirth) " +
                                   "VALUES (@FirstName, @MiddleName, @LastName, @Salary, @Email, @PhoneNumber, @Address, @Country, @Age, @DateOfBirth)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", (object)employee.MiddleName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Country", employee.Country);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // Get the edit view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = null;

            // Retrieve employee from database based on id
            string connectionString = _configuration.GetConnectionString("EmployeeDbConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    employee = new Employee
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"]?.ToString(),
                        LastName = reader["LastName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Country = reader["Country"].ToString(),
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"]
                    };
                }
                reader.Close();
            }

            return View(employee);
        }

        // Post the edited employee back to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Update the employee in the database
                string connectionString = _configuration.GetConnectionString("EmployeeDbConnection");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Employees SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Salary = @Salary, " +
                                   "Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address, Country = @Country, Age = @Age, DateOfBirth = @DateOfBirth " +
                                   "WHERE Id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", (object)employee.MiddleName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Country", employee.Country);
                    command.Parameters.AddWithValue("@Age", employee.Age);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@Id", employee.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return RedirectToAction("Index");
            }

            return View(employee);
        }


        // GET: Employee/Details/5
        public IActionResult Details(int id)
        {
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string connectionString = _configuration.GetConnectionString("EmployeeDbConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE Id=@Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            return RedirectToAction("Index");
        }

        private Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            string connectionString = _configuration.GetConnectionString("EmployeeDbConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, FirstName, MiddleName, LastName, Salary, Email, PhoneNumber, Address, Country, Age, DateOfBirth " +
                               "FROM Employees WHERE Id=@Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"]?.ToString(),
                        LastName = reader["LastName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Country = reader["Country"].ToString(),
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"]
                    };
                }

                reader.Close();
                connection.Close();
            }

            return employee;
        }


    }
}