namespace eleventh_laboratory_work;

internal abstract class SolveFirstTask
{
    internal static void Executor()
    {
        var studentName = EnterStudentName();
        DetermineStringsLength(studentName);
        CheckIfNamesStartsWithSpecificLetter("B", studentName);
    }

    private static void CheckIfNamesStartsWithSpecificLetter(string specificLetter, IEnumerable<string> studentName)
    {
        var startsWithSpecificLetter = studentName.Any(name =>
            name.StartsWith(specificLetter.ToLower()) || name.StartsWith(specificLetter.ToUpper()));

        Console.WriteLine(startsWithSpecificLetter
            ? $"At least one of the words starts with letter {specificLetter}."
            : $"None of the words starts with letter {specificLetter}.");
    }

    private static string[] EnterStudentName()
    {
        Console.Write("Enter your first name: ");
        var firstName = Console.ReadLine()!;
        Console.Write("Enter your middle name: ");
        var middleName = Console.ReadLine()!;
        Console.Write("Enter your last name: ");
        var lastName = Console.ReadLine()!;
        string[] studentName = { firstName, middleName, lastName };
        return studentName;
    }

    private static void DetermineStringsLength(IReadOnlyList<string> studentName)
    {
        Console.WriteLine($"\nLength of your first name: {studentName[0].Length}");
        Console.WriteLine($"Length of your middle name: {studentName[1].Length}");
        Console.WriteLine($"Length of your last name: {studentName[2].Length}");
    }
}

internal static class SolveSecondTask
{
    internal static void Executor()
    {
        const string originalText = "Hello, world!";
        var encryptedText = EncryptText(originalText);
        DecryptText(encryptedText);
    }
    
    private const int Shift = 3;

    private static string EncryptText(string originalText)
    {
        var encryptedChars = new char[originalText.Length];
        for (var i = 0; i < originalText.Length; i++)
        {
            var originalChar = originalText[i];
            var encryptedChar = EncryptChar(originalChar);
            encryptedChars[i] = encryptedChar;
        }
        var encryptedText = new string(encryptedChars);

        Console.WriteLine($"The encrypted text is: {encryptedText}");
        
        return encryptedText;
    }

    private static void DecryptText(string encryptedText)
    {
        var decryptedChars = new char[encryptedText.Length];
        for (var i = 0; i < encryptedText.Length; i++)
        {
            var encryptedChar = encryptedText[i];
            var decryptedChar = DecryptChar(encryptedChar);
            decryptedChars[i] = decryptedChar;
        }
        var decryptedText = new string(decryptedChars);

        Console.WriteLine($"The decrypted text is: {decryptedText}");
    }

    private static char EncryptChar(char c)
    {
        var originalCode = (int)c;
        var encryptedCode = originalCode + Shift;
        return (char)encryptedCode;
    }

    private static char DecryptChar(char c)
    {
        var encryptedCode = (int)c;
        var decryptedCode = encryptedCode - Shift;
        return (char)decryptedCode;
    }
}

internal abstract class EleventhLaboratoryWork
{
    private static void Main()
    {
        SolveFirstTask.Executor();
        // SolveSecondTask.Executor();
    }
}