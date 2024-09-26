using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue_Assignment
{
    public class Employee
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }


        public Employee(string name, string gender, string contactNo)
        {
            Name = name;
            Gender = gender;
            ContactNo = contactNo;
        }

        public override string ToString()
        {
            return $"{{ Name: {Name}; Gender: {Gender}; ContactNo: {ContactNo} }}";
        }
    }
}
