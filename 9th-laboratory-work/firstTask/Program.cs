// 11th option

namespace firstTask;

internal abstract class FirstTask
{
    private static void Main()
    {
        while (true)
        {
            Input(out var x, out var y, out var z);
            var result = SolveTheEquation(x, y, z);
            Console.WriteLine($"Result: {result}");
            RangeNameForX(x);
            RangeNameForResult(result);
            if (x == 0) break;
        }
    }

    private static void Input(out int x, out int y, out int z)
    {
        Console.Write("x = ");
        x = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("y = ");
        y = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("z = ");
        z = int.Parse(Console.ReadLine() ?? string.Empty);
    }

    private static double SolveTheEquation(int x, int y, int z)
    {
        var numerator = Math.Pow(y, 3);
        var denominator = z + Math.Pow(z, 2) + (z + Math.Pow(y, 2));
        return x + numerator / denominator;
    }

    private static void RangeNameForX(int i)
    {
        switch (i)
        {
            case < -10:
                Console.WriteLine("X is less then -10");
                break;
            case < -1:
                Console.WriteLine("X is less then -1");
                break;
            case > 10:
                Console.WriteLine("X is more then 10");
                break;
            case > 1:
                Console.WriteLine("X is more then 1");
                break;
            case 0:
                Console.WriteLine("X is equal to 0");
                break;
            default:
                Console.WriteLine("X is between -1 and 1");
                break;
        }
    }

    private static void RangeNameForResult(double result)
    {
        switch (result)
        {
            case < 0:
                Console.WriteLine("The result is negative");
                break;
            case > 0:
                Console.WriteLine("The result is positive");
                break;
            default:
                Console.WriteLine("The result is zero");
                break;
        }
    }
}