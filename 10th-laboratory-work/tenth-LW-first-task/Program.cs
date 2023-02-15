namespace tenth_LW_first_task;

internal abstract class FirstTask
{
    private static void Main()
    {
        GenerateNewArray(out var array);
        SwapArrayElements(array);
    }

    private static void SwapArrayElements(IList<int> array)
    {
        var indexOfSmallestElement = 0;
        var indexOfBiggestElement = 0;

        for (var i = 1; i < array.Count; i++)
        {
            if (array[i] < array[indexOfSmallestElement]) indexOfSmallestElement = i;
            if (array[i] > array[indexOfBiggestElement]) indexOfBiggestElement = i;
        }
        
        (array[indexOfSmallestElement], array[indexOfBiggestElement]) = 
            (array[indexOfBiggestElement], array[indexOfSmallestElement]);
        
        Console.WriteLine("\nSwapped array:");
        foreach (var i in array)
        {
            Console.Write($"{i} ");
        }
    }

    private static void GenerateNewArray(out int[] array)
    {
        array = new int[10];
        var randomNumber = new Random();
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = randomNumber.Next(-10, 10);
        }

        Console.WriteLine("Generated array:");
        foreach (var i in array)
        {
            Console.Write($"{i} ");
        }
    }
}