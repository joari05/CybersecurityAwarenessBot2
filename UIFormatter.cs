using System;
using System.Threading;

namespace CybersecurityChatbot.Chatbot
{
    public static class UIFormatter
    {
        public static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteLineColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteWithDelay(string text, int delayMs = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        public static void DrawBorder(string title = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔" + new string('═', 78) + "╗");

            if (!string.IsNullOrEmpty(title))
            {
                int padding = (78 - title.Length) / 2;
                Console.WriteLine("║" + new string(' ', padding) + title +
                                 new string(' ', 78 - padding - title.Length) + "║");
                Console.WriteLine("║" + new string(' ', 78) + "║");
            }

            Console.ResetColor();
        }

        public static void DrawFooter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╚" + new string('═', 78) + "╝");
            Console.ResetColor();
        }

        public static void DrawSectionHeader(string sectionName)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"═══ {sectionName} ═══");
            Console.ResetColor();
        }

        public static void DrawSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('•', 80));
            Console.ResetColor();
        }
    }
}