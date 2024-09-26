using System;
using System.Collections.Generic;
using System.Linq;

class Jobsequencing
{
    // Define a class to represent a job with its profit and deadline
    class Job
    {
        public string Id { get; set; } // Changed from char to string
        public int Profit { get; set; }
        public int Deadline { get; set; }

        public Job(string id, int profit, int deadline) // Changed parameter type to string
        {
            Id = id;
            Profit = profit;
            Deadline = deadline;
        }
    }

    static void Main()
    {
        // Array of jobs with their profit and deadline
        List<Job> jobs = new List<Job>
        {
            new Job("J1", 20, 2),
            new Job("J2", 25, 2),
            new Job("J3", 15, 1),
            new Job("J4", 40, 4),
            new Job("J5", 5, 3),
            new Job("J6", 10, 3),
            new Job("J7", 9, 4)
        };

        // Sort jobs based on profit in descending order
        var sortedJobs = jobs.OrderByDescending(j => j.Profit).ToList();

        // Find the maximum deadline to create a schedule array
        int maxDeadline = sortedJobs.Max(j => j.Deadline);
        bool[] slot = new bool[maxDeadline];
        string[] result = new string[maxDeadline]; // Changed from char to string

        // Initialize slot array to false
        for (int i = 0; i < maxDeadline; i++)
        {
            slot[i] = false;
        }

        // Greedily select jobs
        foreach (var job in sortedJobs)
        {
            // Find a slot for this job
            for (int j = Math.Min(maxDeadline - 1, job.Deadline - 1); j >= 0; j--)
            {
                if (!slot[j])
                {
                    // Assign job to this slot
                    slot[j] = true;
                    result[j] = job.Id;
                    break;
                }
            }
        }

        // Calculate the total profit
        int totalProfit = sortedJobs
            .Where(job => result.Contains(job.Id))
            .Sum(job => job.Profit);

        // Display the result
        Console.WriteLine("Job sequence for maximum profit:");
        foreach (var jobId in result)
        {
            if (!string.IsNullOrEmpty(jobId))
            {
                Console.Write(jobId + " ");
            }
        }

        Console.WriteLine($"\nTotal Profit: {totalProfit}");
    }
}