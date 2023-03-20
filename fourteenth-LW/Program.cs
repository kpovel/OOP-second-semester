namespace fourteenth_LW;

internal interface IWigwamSize
{
    double Height { get; set; }
    double LowerHeight { get; set; }
    double Width { get; set; }
    double GetArea();
}

internal class Wigwam : IWigwamSize
{
    public double Height { get; set; }
    public double LowerHeight { get; set; }
    public double Width { get; set; }

    public Wigwam() : this(0, 0, 0)
    {
    }

    public Wigwam(double height, double lowerHeight, double width)
    {
        Height = height;
        LowerHeight = lowerHeight;
        Width = width;
    }

    public double GetArea()
    {
        return Math.Round(0.5 * Width * (Height + LowerHeight), 2);
    }
    
    public override string ToString()
    {
        return $"Wigwam: Height = {Height}, LowerHeight = {LowerHeight}, Width = {Width}, Area = {GetArea()}";
    }
}

internal abstract class Program
{
    private static void Main()
    {
        const int n = 5;
        var wigwams = new Wigwam[n];

        var random = new Random();
        for (var i = 0; i < n; i++)
        {
            wigwams[i] = new Wigwam(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
        }

        Console.WriteLine("Array of wigwams: ");
        foreach (var wigwam in wigwams)
        {
            Console.WriteLine(wigwam);
        }

        Array.Sort(wigwams, (x, y) => y.GetArea().CompareTo(x.GetArea()));

        Console.WriteLine("\nSorted array of wigwams:");
        foreach (var wigwam in wigwams)
        {
            Console.WriteLine(wigwam);
        }
    }
}