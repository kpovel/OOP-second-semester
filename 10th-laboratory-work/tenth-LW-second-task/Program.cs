namespace tenth_LW_second_task;

internal abstract class FirstTask
{
    private static void Main()
    {
        GenerateArray(out var array);
        ShowArray(array);
        ExecuteTask(array);
    }

    private static void ExecuteTask(IReadOnlyList<int> array)
    {
        var indexOfMaxNumber = 0;
        for (var i = 1; i < array.Count; i++)
        {
            if (array[i] > array[indexOfMaxNumber]) indexOfMaxNumber = i;
        }
        
        Console.WriteLine($"\nIndex of max element: {indexOfMaxNumber}");

        var averageValue = array.Average();
        var sumAboveAverage = array.Where(i => i > averageValue).Sum();
        Console.WriteLine($"A sum of elements that are bigger than the average value: {sumAboveAverage}");
    }

    private static void ShowArray(IEnumerable<int> array)
    {
        Console.WriteLine("Generated array:");
        foreach (var i in array)
        {
            Console.Write($"{i} ");
        }
    }

    private static void GenerateArray(out int[] array)
    {
        array = new int[10];
        var randomNumber = new Random();
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = randomNumber.Next(-10, 10);
        }
    }
}

