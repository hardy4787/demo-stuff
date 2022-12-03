namespace Shared
{
    public static class ColorConsole
    {
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.Blue)
        {
            var oldColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            Console.Write(message);
            Console.BackgroundColor = oldColor;
            Console.WriteLine();
        }
    }
}