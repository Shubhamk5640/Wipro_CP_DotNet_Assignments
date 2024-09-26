using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTask2
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity()
        {
            Id = new Random().Next(1, 100);
        }
    }
}
