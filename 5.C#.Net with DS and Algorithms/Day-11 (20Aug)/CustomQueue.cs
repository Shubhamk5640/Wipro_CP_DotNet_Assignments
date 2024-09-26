using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue_Assignment
{

    public class CustomQueue<T>
    {
        public List<T> queue = new List<T>();

        public void Enqueue(T item)
        {
            queue.Add(item);
            Console.WriteLine($"{item} is enqueued to queue");
        }


        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = queue[0];
            queue.RemoveAt(0);
            Console.WriteLine($"Dequeue: {item}");
            return item;
        }


        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = queue[0];
            Console.WriteLine($"Peek: {item}");
            return item;
        }


        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
    }
}
