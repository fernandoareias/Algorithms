namespace Algorithm.Algorithms.Sorting;

public static class BubbleSort
{
    public static T[] Sort<T>(T[] input) where T : IComparable<T>
    {
        for (int x = 0; x < input.Length - 1; x++)
        {
            for (int y = 0; y < input.Length - 1 - x; y++)
            {
                if (input[y].CompareTo(input[y + 1]) > 0)
                {
                    (input[y], input[y + 1]) = (input[y + 1], input[y]);
                }
            }
        }

        return input;
    }


    
}