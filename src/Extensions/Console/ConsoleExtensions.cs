
namespace Calebs.Extensions.Console
{
    public static class ConsoleExtensions
    {
        public static void WriteLine (this System.ConsoleColor color, string text)
        {
            color.Write(text);
            System.Console.WriteLine();
        }

        public static void Write (this System.ConsoleColor color, string text)
        {
            var currentColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = color;
            System.Console.Write(text);
            System.Console.ForegroundColor = currentColor;
        }
    }
}
