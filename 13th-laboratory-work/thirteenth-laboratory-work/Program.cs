namespace thirteenth_laboratory_work;

public abstract class Figure
{
    public enum FigureColor
    {
        White,
        Black
    }

    protected FigureColor Color { get; }

    protected Figure(FigureColor color)
    {
        Color = color;
    }
}

public abstract class ChessCoordinate : Figure
{
    private int X { get; set; }

    private string Y { get; set; }

    protected ChessCoordinate(FigureColor color, int x, string y) : base(color)
    {
        X = x;
        Y = y;
    }

    public void SetCoordinate(int x, string y)
    {
        X = x;
        Y = y;
    }

    public string GetCoordinate()
    {
        return $"{X}, {Y}";
    }
}

public abstract class ChessFigure : ChessCoordinate
{
    public enum FigureType
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    internal FigureType Type { get; init; }

    protected ChessFigure(FigureColor color, int x, string y) : base(color, x, y)
    {
    }

    public override string ToString()
    {
        return $"The {Type} has color {Color}";
    }
}

public class King : ChessFigure
{
    public King(FigureColor color, int x, string y) : base(color, x, y)
    {
        Type = FigureType.King;
    }
}

public class Queen : ChessFigure
{
    public Queen(FigureColor color, int x, string y) : base(color, x, y)
    {
        Type = FigureType.Queen;
    }
}

public class Rook : ChessFigure
{
    public Rook(FigureColor color, int x, string y) : base(color, x, y)
    {
        Type = FigureType.Rook;
    }
}

public class Bishop : ChessFigure
{
    public Bishop(FigureColor color, int x, string y) : base(color, x, y)
    {
        Type = FigureType.Bishop;
    }
}

public class Knight : ChessFigure
{
    public Knight(FigureColor color, int x, string y) : base(color, x, y)
    {
        Type = FigureType.Knight;
    }
}

public class Pawn : ChessFigure
{
    public Pawn(FigureColor color, int x, string y) : base(color, x, y)
    {
        Type = FigureType.Pawn;
    }
}

internal static class Executor
{
    public static void Main()
    {
        var king = new King(Figure.FigureColor.White, 3, "a");
        king.SetCoordinate(5, "c");
        Console.WriteLine(king);
        Console.WriteLine($"The king have coordinate: {king.GetCoordinate()}");
    }
}