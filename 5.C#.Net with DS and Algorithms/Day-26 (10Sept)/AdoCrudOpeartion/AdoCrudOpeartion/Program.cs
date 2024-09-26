using System;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoCrudOperation
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        static void Main(string[] args)
        {
            // Create tables at the start
            CreateTables();

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

        static void CreateTables()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create Department table
                string createDepartmentTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Department' AND xtype='U')
                    CREATE TABLE Department (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(50)
                    );";

                SqlCommand cmd = new SqlCommand(createDepartmentTable, connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Department table created successfully.");

                // Create Employee table
                string createEmployeeTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employee' AND xtype='U')
                    CREATE TABLE Employee (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(50),
                        Gender NVARCHAR(10),
                        Age INT,
                        Salary DECIMAL(18, 2),
                        DeptId INT,
                        CONSTRAINT FK_Employee_Department FOREIGN KEY (DeptId)
                        REFERENCES Department(Id)
                    );";
                cmd = new SqlCommand(createEmployeeTable, connection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee table created successfully.");
            }
        }

        static void ReadEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nEmployee Data:");
                Console.WriteLine("ID\tName\tGender\tAge\tSalary\tDeptId");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]}\t{reader["Name"]}\t{reader["Gender"]}\t{reader["Age"]}\t{reader["Salary"]}\t{reader["DeptId"]}");
                }
            }
        }

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
            Console.Write("Enter DeptId: ");
            int deptId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Employee (Name, Gender, Age, Salary, DeptId) VALUES (@Name, @Gender, @Age, @Salary, @DeptId)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.Parameters.AddWithValue("@DeptId", deptId);
               cmd.ExecuteNonQuery();
                Console.WriteLine("\nEmployee Inserted Successfully.");
            }

            ReadEmployees(); // Display updated table
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Employee SET Name = @Name, Salary = @Salary WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nEmployee Updated Successfully.");
            }

            ReadEmployees(); // Display updated table
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employee WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nEmployee Deleted Successfully.");
            }

            ReadEmployees(); // Display updated table
        }
    }
}
