using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigration
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string City { get; set; }
        public string Role { get; set; }
        public int Experience { get; set; } 
        //foreign key
        public int DeptId { get; set; }
        public Department Department { get; set; }

    }
}