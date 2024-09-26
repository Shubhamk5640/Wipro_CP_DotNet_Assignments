﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCrudOperation
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}
