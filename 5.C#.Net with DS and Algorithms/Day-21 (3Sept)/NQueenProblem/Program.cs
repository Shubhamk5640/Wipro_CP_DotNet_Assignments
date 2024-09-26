using System;

class NQueens
{
    // Function to print the board and positions of queens
    static void PrintSolution(int[,] board, int N)
    {
        Console.WriteLine("Chessboard arrangement:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(board[i, j] == 1 ? "Q " : ". ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        Console.WriteLine("Queen positions:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (board[i, j] == 1)
                {
                    // Print queen's position in (row, column) format
                    Console.WriteLine($"Queen at: ({i + 1}, {j + 1})");
                }
            }
        }
        Console.WriteLine();
    }

    // Function to check if a queen can be placed on board[row, col]
    static bool IsSafe(int[,] board, int row, int col, int N)
    {
        // Check this column on the upper side
        for (int i = 0; i < row; i++)
            if (board[i, col] == 1)
                return false;

        // Check the upper left diagonal
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        // Check the upper right diagonal
        for (int i = row, j = col; i >= 0 && j < N; i--, j++)
            if (board[i, j] == 1)
                return false;

        return true;
    }

    // A recursive utility function to solve the N-Queens problem
    static bool SolveNQUtil(int[,] board, int row, int N)
    {
        // Base case: If all queens are placed
        if (row >= N)
            return true;

        // Consider this row and try placing the queen in all columns one by one
        for (int i = 0; i < N; i++)
        {
            if (IsSafe(board, row, i, N))
            {
                // Place the queen
                board[row, i] = 1;

                // Recur to place rest of the queens
                if (SolveNQUtil(board, row + 1, N))
                    return true;

                // If placing queen in board[row, i] doesn't lead to a solution
                // then remove the queen (backtrack)
                board[row, i] = 0;
            }
        }

        // If the queen cannot be placed in any column in this row, return false
        return false;
    }

    // Function to solve the N-Queens problem using backtracking
    static bool SolveNQ(int N)
    {
        int[,] board = new int[N, N];

        if (!SolveNQUtil(board, 0, N))
        {
            Console.WriteLine("Solution does not exist");
            return false;
        }

        PrintSolution(board, N);
        return true;
    }

    static void Main()
    {
        int N = 4; // Number of queens
        SolveNQ(N);
    }
}