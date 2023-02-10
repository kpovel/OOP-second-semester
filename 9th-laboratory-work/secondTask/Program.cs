namespace secondTask;

internal abstract class SecondTask
{
    private static void Main()
    {
        EnterProductivityOfPlants(out var firstSort, out var secondSort, out var thirdSort);
        EnterSizeOfGround(out var firstGround, out var secondGround, out var thirdGround);

        HarvestedCrops(firstSort, secondSort, thirdSort, firstGround, secondGround, thirdGround);
    }

    private static void HarvestedCrops(int firstSort, int secondSort, int thirdSort,
        int firstGround, int secondGround, int thirdGround)
    {
        var firstHarvest = firstSort * firstGround;
        var secondHarvest = secondSort * secondGround;
        var thirdHarvest = thirdSort * thirdGround;

        Console.WriteLine($"Harvested from first ground: {firstHarvest}");
        Console.WriteLine($"Harvested from second ground: {secondHarvest}");
        Console.WriteLine($"Harvested from third ground: {thirdHarvest}");

        var totalHarvest = firstHarvest + secondHarvest + thirdHarvest;

        Console.WriteLine($"Total harvest: {totalHarvest}");
    }

    private static void EnterSizeOfGround(out int firstPlant, out int secondPlant, out int thirdPlant)
    {
        Console.Write("Enter size of first ground: ");
        firstPlant = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Enter size of second ground: ");
        secondPlant = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Enter size of third ground: ");
        thirdPlant = int.Parse(Console.ReadLine() ?? string.Empty);
    }

    private static void EnterProductivityOfPlants(out int firstSort, out int secondSort, out int thirdSort)
    {
        Console.Write("First sort productivity: ");
        firstSort = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Second sort productivity: ");
        secondSort = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.Write("Third sort productivity: ");
        thirdSort = int.Parse(Console.ReadLine() ?? string.Empty);
    }
}