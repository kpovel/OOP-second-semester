using static lab16.NumericalIntegration;

namespace lab16;

using System;

public static class NumericalIntegration
{
    // Define a delegate type for functions with a single double input and a double output
    public delegate double FunctionDelegate(double x);

    // Trapezoidal rule for numerical integration
    public static double TrapezoidalRule(FunctionDelegate function, double a, double b, int n)
    {
        var h = (b - a) / n;
        var sum = 0.5 * (function(a) + function(b));

        for (var i = 1; i <= n; i++)
        {
            var x = a + i * h;
            sum += function(x);
        }

        return h * sum;
    }

    // Define the functions as static methods
    public static double F1(double x)
    {
        return 1 / Math.Pow(x, 1.0 / 3);
    }

    public static double F2(double x)
    {
        return Math.Exp(x) / Math.Sqrt(x);
    }

    public static double F3(double x)
    {
        return Math.Log(x, 2);
    }
}

internal static class Program
{
    private static void Main()
    {
        // Define integration limits and the number of trapezoids
        const double a = 1;
        const double b = 2;
        const int n = 1000;

        // Calculate the integral for each function using the trapezoidal method
        var result1 = TrapezoidalRule(F1, a, b, n);
        var result2 = TrapezoidalRule(F2, a, b, n);
        var result3 = TrapezoidalRule(F3, a, b, n);
        var result4 = TrapezoidalRule(x => x, 0, 1, 1000);

        Console.WriteLine($"Result for f(x) = 1 / ∛x: {result1}");
        Console.WriteLine($"Result for f(x) = e^x / √x: {result2}");
        Console.WriteLine($"Result for f(x) = log2(x): {result3}");
        Console.WriteLine($"Result of 4th execution: {result4}");
    }
}