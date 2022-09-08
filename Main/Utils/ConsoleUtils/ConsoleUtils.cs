using System;

namespace Utils.ConsoleUtils
{
    public static class ConsoleUtils
    {
        static public void ClearLine(int length, bool line)
        {
            if (line)
                Console.SetCursorPosition(0, --Console.CursorTop);
            else
                PositionStartLine();
            Console.Write(new String(' ', length));
            PositionStartLine();
        }

        static public void PositionStartLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
        }

        static public void DisplayWithColor(string text, bool line, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            if (line)
                Console.Write("\n");
        }

        static public void DisplayText(string text, string textNotAvailable, bool line)
        {
            if (string.IsNullOrWhiteSpace(text))
                DisplayNotAvailable(textNotAvailable, line);
            else
                DisplayTextLine(text, line);
        }

        static public void DisplayTextLine(string text, bool line)
        {
            if (line)
                Console.WriteLine(text);
            else
                Console.Write(text);
        }

        static public void DisplayNotAvailable(string textNotAvailable, bool line)
        {
            DisplayWithColor($" {textNotAvailable} ", line, ConsoleColor.Black, ConsoleColor.White);
        }

        static public void DisplaySpace(int space)
        {
            for (int i = 0; i < space; i++)
            {
                Console.Write(' ');
            }
        }
    }
}
