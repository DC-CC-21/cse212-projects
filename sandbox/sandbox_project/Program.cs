using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");

        // Test 1: Two empty sets
        HashSet<int> a1 = new HashSet<int>();
        HashSet<int> b1 = new HashSet<int>();
        HashSet<int> result1 = Intersect(a1, b1);
        Console.WriteLine("Test 1 (Two empty sets): " + (result1.Count == 0 ? "PASS" : "FAIL"));

        // Test 2: One empty set
        HashSet<int> a2 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b2 = new HashSet<int>();
        HashSet<int> result2 = Intersect(a2, b2);
        Console.WriteLine("Test 2 (One empty set): " + (result2.Count == 0 ? "PASS" : "FAIL"));

        // Test 3: Two sets with no intersection
        HashSet<int> a3 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b3 = new HashSet<int> { 4, 5, 6 };
        HashSet<int> result3 = Intersect(a3, b3);
        Console.WriteLine("Test 3 (Two sets with no intersection): " + (result3.Count == 0 ? "PASS" : "FAIL"));

        // Test 4: Two sets with intersection
        HashSet<int> a4 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b4 = new HashSet<int> { 2, 3, 4 };
        HashSet<int> result4 = Intersect(a4, b4);
        Console.WriteLine("Test 4 (Two sets with intersection): " + (result4.Count == 2 ? "PASS" : "FAIL"));


        // Test 1: Both sets are empty
        HashSet<int> a5 = new HashSet<int>();
        HashSet<int> b5 = new HashSet<int>();
        HashSet<int> result5 = Intersect(a5, b5);
        Console.WriteLine("Test 1 (Both sets empty): " + (result5.Count == 0 ? "PASS" : "FAIL"));

        // Test 2: One set is empty
        HashSet<int> a6 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b6 = new HashSet<int>();
        HashSet<int> result6 = Intersect(a6, b6);
        Console.WriteLine("Test 2 (One empty set): " + (result6.Count == 0 ? "PASS" : "FAIL"));

        // Test 3: Both sets have the same elements
        HashSet<int> a7 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b7 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> result7 = Intersect(a7, b7);
        Console.WriteLine("Test 3 (Both sets same elements): " + (result7.SetEquals(new HashSet<int> { 1, 2, 3 }) ? "PASS" : "FAIL"));

        // Test 4: Two sets with no intersection
        HashSet<int> a8 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b8 = new HashSet<int> { 4, 5, 6 };
        HashSet<int> result8 = Intersect(a8, b8);
        Console.WriteLine("Test 4 (Two sets with no intersection): " + (result8.Count == 0 ? "PASS" : "FAIL"));

        // Test 5: Two sets with partial intersection
        HashSet<int> a9 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b9 = new HashSet<int> { 2, 3, 4 };
        HashSet<int> result9 = Intersect(a9, b9);
        Console.WriteLine("Test 5 (Two sets with partial intersection): " + (result9.SetEquals(new HashSet<int> { 2, 3 }) ? "PASS" : "FAIL"));


        // Test 1: Both sets are empty
        HashSet<int> a10 = new HashSet<int>();
        HashSet<int> b10 = new HashSet<int>();
        HashSet<int> result10 = Union(a10, b10);
        Console.WriteLine("Test 1 (Both sets empty): " + (result10.Count == 0 ? "PASS" : "FAIL"));

        // Test 2: One set is empty
        HashSet<int> a11 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b11 = new HashSet<int>();
        HashSet<int> result11 = Union(a11, b11);
        Console.WriteLine("Test 2 (One empty set): " + (result11.SetEquals(new HashSet<int> { 1, 2, 3 }) ? "PASS" : "FAIL"));

        // Test 3: Both sets have the same elements
        HashSet<int> a12 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b12 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> result12 = Union(a12, b12);
        Console.WriteLine("Test 3 (Both sets same elements): " + (result12.SetEquals(new HashSet<int> { 1, 2, 3 }) ? "PASS" : "FAIL"));

        // Test 4: Two sets with no intersection
        HashSet<int> a13 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b13 = new HashSet<int> { 4, 5, 6 };
        HashSet<int> result13 = Union(a13, b13);
        Console.WriteLine("Test 4 (Two sets with no intersection): " + (result13.SetEquals(new HashSet<int> { 1, 2, 3, 4, 5, 6 }) ? "PASS" : "FAIL"));

        // Test 5: Two sets with partial intersection
        HashSet<int> a14 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> b14 = new HashSet<int> { 2, 3, 4 };
        HashSet<int> result14 = Union(a14, b14);
        Console.WriteLine("Test 5 (Two sets with partial intersection): " + (result14.SetEquals(new HashSet<int> { 1, 2, 3, 4 }) ? "PASS" : "FAIL"));

    }
    // Define a function called intersect that takes two sets
    public static HashSet<int> Intersect(HashSet<int> a, HashSet<int> b)
    {
        // Define an empty set to store the values that intersect
        HashSet<int> result = new HashSet<int>();

        // Loop through each value in the second set
        foreach (int value in b)
        {
            // If the value is also in the first set, add it to the result set
            if (a.Contains(value))
            {
                result.Add(value);
            }
        }

        // Return the result set
        return result;
    }

    // Define a function call union that takes two sets
    public static HashSet<int> Union(HashSet<int> a, HashSet<int> b)
    {
        /* ALTERNATIVE
            return a spread result of each set
        
            example: return [..a, ..b]
        
        */


        // define an a new set with the same values as set a
        HashSet<int> result = new HashSet<int>(a);

        // Loop through each value in the second set
        foreach (int value in b)
        {
            // foreach value in b, add it to the result set
            result.Add(value);
        }


        // return the result set
        return [..a, ..b];
    }
}