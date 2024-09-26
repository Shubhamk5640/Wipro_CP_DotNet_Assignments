using Stack_Queue_Assignment;

public class Program
{
    public static void Main()
    {
        //Main Method for Stack Question

        CustomStack employeeStack = new CustomStack();

        // Push employees onto the stack
        employeeStack.Push(new Employee("Shubham", "Male", "9678975685"));
        employeeStack.Push(new Employee("Sanket", "Female", "9767474767"));
        employeeStack.Push(new Employee("Pankaj", "Male", "9366677878"));
        employeeStack.Push(new Employee("Pawan", "Male", "8998956566"));


        employeeStack.Pop();


        employeeStack.Peek();


        Console.WriteLine($"\nisEmpty:{employeeStack.IsEmpty()}");

        Console.ReadLine();





        ////Main Method for Queue Question
        //CustomQueue<int> intQueue = new CustomQueue<int>();

        //Console.WriteLine("--------------Queue Checking using integers---------------");
        //intQueue.Enqueue(10);
        //intQueue.Enqueue(20);
        //intQueue.Enqueue(30);

        //Console.WriteLine("--------------Dequeue Checking using integers---------------");
        //intQueue.Dequeue();
        //intQueue.Peek();
        //intQueue.Dequeue();
        //intQueue.Dequeue();


        //Console.WriteLine($"isEmpty: {intQueue.IsEmpty()}");


        //Console.WriteLine("--------------Queue Checking using string---------------");
        //CustomQueue<string> stringQueue = new CustomQueue<string>();

        //stringQueue.Enqueue("Shubham");
        //stringQueue.Enqueue("Pankaj");

        //Console.WriteLine("--------------Dequeue Checking using string---------------");
        //stringQueue.Dequeue();
        //stringQueue.Peek();
        //stringQueue.Dequeue();


        //Console.WriteLine($"isEmpty: {stringQueue.IsEmpty()}");

        //Console.WriteLine("--------------Queue Checking using Objects---------------");
        //CustomQueue<Employee> employeeQueue = new CustomQueue<Employee>();


        //employeeQueue.Enqueue(new Employee("Sanket", "Male", "935853036"));
        //employeeQueue.Enqueue(new Employee("Sudhansh", "Female", "987588899"));
        //employeeQueue.Enqueue(new Employee("Pawan", "Male", "795676785"));

        //Console.WriteLine("--------------Dequeue Checking using Objects---------------");
        //employeeQueue.Dequeue();
        //employeeQueue.Peek();
        //employeeQueue.Dequeue();
        //employeeQueue.Dequeue();


        //Console.WriteLine($"isEmpty: {employeeQueue.IsEmpty()}");

        //Console.ReadLine();
    }
}