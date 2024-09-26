using System;

class RatInMaze
{
    // Maze size
    static int N = 4;

    // Function to print the solution matrix
    static void PrintSolution(int[,] solution)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(solution[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // A utility function to check if x, y is valid index for N*N maze
    static bool IsSafe(int[,] maze, int x, int y)
    {
        // If (x,y) is within the maze bounds and is not blocked (i.e., maze[x][y] == 1), then return true
        return (x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1);
    }

    // Solves the Maze problem using Backtracking. It mainly uses solveMazeUtil() to solve the problem.
    static bool SolveMaze(int[,] maze)
    {
        int[,] solution = new int[N, N];

        if (SolveMazeUtil(maze, 0, 0, solution) == false)
        {
            Console.WriteLine("No solution exists");
            return false;
        }

        PrintSolution(solution);
        return true;
    }

    // A recursive utility function to solve Maze problem
    static bool SolveMazeUtil(int[,] maze, int x, int y, int[,] solution)
    {
        // If (x, y) is the bottom-right corner, the solution is found
        if (x == N - 1 && y == N - 1)
        {
            solution[x, y] = 1;
            return true;
        }

        // Check if maze[x][y] is a valid move
        if (IsSafe(maze, x, y))
        {
            // Mark x, y as part of the solution path
            solution[x, y] = 1;

            // Move forward in the x direction
            if (SolveMazeUtil(maze, x + 1, y, solution))
                return true;

            // If moving in x direction doesn't give a solution, move down in y direction
            if (SolveMazeUtil(maze, x, y + 1, solution))
                return true;

            // If neither direction works, backtrack by unmarking x, y as part of the solution path
            solution[x, y] = 0;
            return false;
        }

        return false;
    }

    // Driver program to test above function
    static void Main()
    {
        int[,] maze = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 1, 1, 0, 0 },
            { 0, 1, 1, 1 }
        };

        SolveMaze(maze);
    }
}