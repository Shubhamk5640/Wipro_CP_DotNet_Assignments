using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;


public class ThreadSafeQueue<T>
{
    private ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
    }

    public bool TryDequeue(out T result)
    {
        return _queue.TryDequeue(out result);
    }

    public bool TryPeek(out T result)
    {
        return _queue.TryPeek(out result);
    }

    public bool IsEmpty()
    {
        return _queue.IsEmpty;
    }
}

public class ThreadSafeQueueWithLocks<T>
{
    private Queue<T> _queue = new Queue<T>();
    private readonly object _lock = new object();

    public void Enqueue(T item)
    {
        lock (_lock)
        {
            _queue.Enqueue(item);
            Monitor.PulseAll(_lock);
        }
    }

    public T Dequeue()
    {
        lock (_lock)
        {
            while (_queue.Count == 0)
            {
                Monitor.Wait(_lock);
            }
            return _queue.Dequeue();
        }
    }

    public T Peek()
    {
        lock (_lock)
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _queue.Peek();
        }
    }

    public bool IsEmpty()
    {
        lock (_lock)
        {
            return _queue.Count == 0;
        }
    }
}

class Program
{
    static void Main()
    {
        var queue = new ThreadSafeQueueWithLocks<int>();

        Thread producer = new Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Enqueued: {i}");
                Thread.Sleep(100); // Simulate work
            }
        });

        Thread consumer = new Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                int item = queue.Dequeue();
                Console.WriteLine($"Dequeued: {item}");
                Thread.Sleep(150); // Simulate work
            }
        });

        producer.Start();
        consumer.Start();

        producer.Join();
        consumer.Join();
    }
}