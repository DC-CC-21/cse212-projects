using System.Globalization;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}

        int[] solution = [1, 2, 3, 2, 4, 4, 6, 8, 10, 5];

        Console.WriteLine($"Matches: {Enumerable.SequenceEqual(intResult, solution)}");
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int arr1 = 0;
        int arr2 = 0;

        return select.Select(v =>
        {
            int value = 0;
            if (v == 1)
            {
                value = list1[arr1];
                arr1 += 1;
            }
            else if (v == 2)
            {
                value = list2[arr2];
                arr2 += 1;

            }
            return value;
        }).ToArray();
    }
}