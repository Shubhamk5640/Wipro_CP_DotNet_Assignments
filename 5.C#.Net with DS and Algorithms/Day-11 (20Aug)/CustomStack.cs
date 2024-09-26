using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue_Assignment
{
    public class CustomStack
    {
        private List<Employee> stack = new List<Employee>();


        public void Push(Employee item)
        {
            stack.Add(item);
            Console.WriteLine($"{item.Name} is pushed to stack");
        }


        public Employee Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            Employee item = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            Console.WriteLine($"\nPop: {{ {item.Name}; {item.Gender}; {item.ContactNo} }}");
            return item;
        }


        public Employee Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            Employee item = stack[stack.Count - 1];
            Console.WriteLine($"\nPeek: {{ {item.Name}; {item.Gender}; {item.ContactNo} }}");
            return item;
        }


        public bool IsEmpty()
        {
            return stack.Count == 0;
        }
    }
}
