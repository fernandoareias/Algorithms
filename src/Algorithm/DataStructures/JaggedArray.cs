namespace Algorithm;

public static class JaggedArray
{
    public static int[][] CreateJaggedArrau()
    {
        int[][] jaggedArray = new int[3][];

        jaggedArray[0] = new[] { 1, 2, 3 };
        jaggedArray[1] = new[] { 4, 5 };
        jaggedArray[2] = new[] { 6, 7, 8, 9 };

        return jaggedArray;
    }
}