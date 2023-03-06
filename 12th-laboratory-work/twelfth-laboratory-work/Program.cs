namespace twelfth_laboratory_work;

internal class Cone
{
    internal double Height { get; set; }
    internal double Radius { get; set; }

    internal Cone()
    {
        Height = 0;
        Radius = 0;
    }

    internal Cone(double height, double radius)
    {
        Height = height;
        Radius = radius;
    }

    internal double GetVolume()
    {
        return Math.Round(Math.PI * Radius * Radius * Height / 3, 2);
    }
    
    internal double GetArea()
    {
        return Math.Round(Math.PI * Radius * (Radius + Math.Sqrt(Height * Height + Radius * Radius)), 2);
    }

    public override string ToString()
    {
        return $"Cone with height {Height} and radius {Radius}";
    }

    public static Cone operator +(Cone cone1, Cone cone2)
    {
        return new Cone(cone1.Height + cone2.Height, cone1.Radius + cone2.Radius);
    }
}

internal static class Executor
{
    public static void Main()
    {
        var cone = new Cone(10, 20);
        var cone2 = new Cone(20, 30);
        Console.WriteLine(cone.GetVolume());
        Console.WriteLine(cone + cone2);
    }
}