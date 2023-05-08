namespace lab16._2
{
    internal static class Program
    {
        public delegate void KeyPressHandler(char key);

        public static event KeyPressHandler? OnKeyPress;

        private static void Main()
        {
            OnKeyPress += NameDisplay;

            Console.WriteLine("Натисніть клавішу, яка відповідає першій літері вашого імені:");
            char key = Console.ReadKey().KeyChar;

            OnKeyPress(key);

            Console.ReadLine();
        }

        private static void NameDisplay(char key)
        {
            const string myName = "Pavlo";
            char firstLetter = myName[0];

            if (char.ToLower(key) == char.ToLower(firstLetter))
            {
                Console.WriteLine($"\n{myName}");
            }
            else
            {
                Console.WriteLine("\nНеправильна клавіша. Спробуйте ще раз.");
            }
        }
    }
}