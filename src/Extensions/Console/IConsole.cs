
using System;

namespace Calebs.Extensions.Console;

public class ConsoleImp : IConsole { }

public interface IConsole
{
    void WriteLine(string text) =>  System.Console.WriteLine(text);
    void Write(string text) => System.Console.Write(text);
    void WriteLine(Exception ex) => System.Console.WriteLine(ex);
    void Error(string text) => ConsoleColor.Red.WriteLine(text);
    void Error(Exception ex) => ConsoleColor.Red.WriteLine(ex);
    ConsoleColor ForegroundColor
    {
        get => System.Console.ForegroundColor;
        set => System.Console.ForegroundColor = value;
    }
    ConsoleColor BackgroundColor
    {
        get => System.Console.BackgroundColor;
        set => System.Console.BackgroundColor = value;
    }

    string ReadLine() => System.Console.ReadLine();
    string ReadLine(string text) => _readline(text);

    private string _readline(string text)
    {
        this.Write(text);
        return this.ReadLine();
    }
}
