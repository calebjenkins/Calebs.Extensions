
using System;

namespace Calebs.Extensions.Console;

public static class ConsoleExtensions
{
    public static IConsole Imp => new ConsoleImp();
    public static void WriteLine (this ConsoleColor color, string text)
    {
        color.Write(text);
        Imp.WriteLine("");
    }
    public static void WriteLine(this ConsoleColor color, Exception ex)
    {
        color.WriteLine(ex.ToString());
    }

    public static void Write (this ConsoleColor color, string text)
    {
        color.Do(() =>
        {
            Imp.Write(text);
        });
    }

    public static void Write(this ConsoleColor color, Exception ex)
    {
        color.Write(ex.ToString());
    }

    public static void WriteLable(this ConsoleColor color, string text, int Margin = 2)
    {
        WriteLable(color, text, Margin, color);
    }
    public static void WriteLable(this ConsoleColor color, string text, int Margin, ConsoleColor BorderColor)
    {
        var labelLength = text.Length + (Margin * 2) + 2; // length + margin + margin + 2 - the last 2 are for the border characters
        var margin = " ".Times(Margin);

        Imp.WriteLine("");
        Imp.Write(" "); // spacer before label
        BorderColor.WriteTimes("-", labelLength);
        Imp.WriteLine("");
        
        BorderColor.Write(" |" + margin);
        color.Write(text);
        BorderColor.WriteLine(margin + "|");

        Imp.Write(" ");
        BorderColor.WriteTimes("-", labelLength);
        Imp.WriteLine("");
    }

    public static void WriteTimes(this ConsoleColor color, string text, int Times = 1)
    {
        if(Times < 0) {  throw new ArgumentOutOfRangeException(nameof(Times), "Times cannot be a negative number"); }

        color.Do(() =>
        {
            for(var i =0; i < Times; i++)
            {
                Imp.Write(text);
            }
        });

    }

    public static void Do(this ConsoleColor color, Action act)
    {
        var currentColor = Imp.ForegroundColor;
        Imp.ForegroundColor = color;

        act.Invoke();

        Imp.ForegroundColor = currentColor;
    }
}
