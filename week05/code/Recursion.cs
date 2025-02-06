using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // TODO Start Problem 1
        // Base Case: If n is less than or equal to 0, return 0
        if (n > 0)
        {
            // Recursive Case: If n is greater than 0, return n^2 + SumSquaresRecursive(n-1)
            return n * n + SumSquaresRecursive(n - 1);
        }
        return 0;
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        // If the size is 0, then add the word to the results
        if (size == 0)
        {
            results.Add(word);
        }
        else
        {
            // For each letter in the letters list remove it and recurse
            for (int i = 0; i < letters.Length; i++)
            {
                PermutationsChoose(results, letters.Remove(i, 1), size - 1, word + letters[i]);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Check if remember is defined. If not, initialize it as an empty dictionary
        remember ??= new Dictionary<int, decimal>();

        // If the value is already in the dictionary, return it
        if (remember.TryGetValue(s, out decimal value))
            return value;

        // Recursively call the function to find all the solutions
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

        // Store the result in the dictionary
        remember[s] = ways;

        // Return the found solutions
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4

        // Base Case: The string does not contain a wildcard
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }

        // Find the index of the wildcard character
        int index = pattern.IndexOf('*');


        // Recursively call the function to solve the problem with the wildcard replaced with a "0"
        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);

        // Recursively call the function to solve the problem with the wildcard replaced with a "1"
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);



    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        currPath ??= [];

        // Error catching: Check if the path is valid before proceeding.
        if (maze.IsValidMove(currPath, x, y))
        {

            // If the path is valid, add the current position to the path.
            currPath.Add((x, y));

            // Recursively call the function to solve the mase.

            // Solve the paths moving to the right side of the maze
            SolveMaze(results, maze, x + 1, y, currPath);

            // Solve the paths moving to the left side of the maze
            SolveMaze(results, maze, x - 1, y, currPath);

            // Solve the paths moving to the bottom side of the maze
            SolveMaze(results, maze, x, y + 1, currPath);

            // Solve the paths moving to the top side of the maze
            SolveMaze(results, maze, x, y - 1, currPath);

            // If the path ends at the end square, then add it to the results list
            if (maze.IsEnd(x, y))
            {
                results.Add(currPath.AsString());
            }

            // Remove the current position from the path so we can try other paths
            currPath.RemoveAt(currPath.Count - 1);
        }


        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution. +
    }
}