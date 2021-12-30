using System;
using System.Threading;

namespace Metawork
{
    class Program
    {
        static readonly Random rand = new Random();
        private static ConsoleColor originalBackgroundColor;
        private static ConsoleColor originalForegroundColor;

        static void Main(string[] args)
        {
            SetUpWindow();
            PrintLineCenterAndWaitForEnter("Metawork Is More Fun Than Work", 1500);
            PrintLineCenterAndWaitForEnter("What Is Metawork?");
            PrintLineCenterAndWaitForEnter("Example #1");
            PrintLineCenterAndWaitForEnter("This Presentation");
            PrintLineCenterAndWaitForEnter("Example #2");
            PrintLineCenterAndWaitForEnter("Writing A Framework Is More Fun Than Creating A Data Entry Form", 3000);
            PrintLineCenterAndWaitForEnter("Example #3");
            PrintLineCenterAndWaitForEnter("It's Funner To Learn A New Framework Than Use An Existing One", 3000);
            PrintLineCenterAndWaitForEnter("Example #4");
            PrintLineCenterAndWaitForEnter("It's Funner To Start A Greenfield Project Than Maintain An Existing Project", 3000);
            PrintLineCenterAndWaitForEnter("Sometimes Metawork Is The Right Thing To Do");
            PrintLineCenterAndWaitForEnter("Sometimes Metawork Distracts Us From Delivering Actual Value", 3000);
            PrintLineCenterAndWaitForEnter("Suggestion #1");
            PrintLineCenterAndWaitForEnter("Ask Yourself If You Are Being Distracted By Metawork");
            PrintLineCenterAndWaitForEnter("Suggestion #2");
            PrintLineCenterAndWaitForEnter("Watch Out Anytime Anyone Says, \"Wouldn't it be cool if...\"", 2000);

            WaitForEnter(() => PrintLineCenter("The End"));
            CleanUp();
        }

        private static void PrintLineCenterAndWaitForEnter(string message, int milliseconds = 1000)
        {
            WaitForEnter(() => PrintLineCenter(message, milliseconds: milliseconds));
        }

        private static void CleanUp()
        {
            Console.BackgroundColor = originalBackgroundColor;
            Console.ForegroundColor = originalForegroundColor;
            Clear();
        }

        private static void Clear()
        {
            Console.Clear();
        }

        private static void Test()
        {
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                Console.ForegroundColor = GetRandomColor();
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(x % 10);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            var centerVertical = Console.WindowHeight / 2;
            var centerHorizontal = Console.WindowWidth / 2;
            Console.SetCursorPosition(centerHorizontal, centerVertical);
            Console.Write("X");

            System.Console.WriteLine();
            System.Console.WriteLine(Console.WindowWidth);
            System.Console.WriteLine(Console.WindowHeight);
        }

        private static ConsoleColor GetRandomColor()
        {
            var values = Enum.GetValues(typeof(ConsoleColor));
            var color = (ConsoleColor)values.GetValue(rand.Next(values.Length));
            return color;
        }

        private static void SetUpWindow()
        {
            Console.Title = "Metawork";
            originalBackgroundColor = Console.BackgroundColor;
            originalForegroundColor = Console.ForegroundColor;
            Clear();
        }

        static void WaitForEnter(Action action)
        {
            action();
            Console.ReadLine();
        }

        static void PrintLineCenter(string message, bool clear = true, int milliseconds = 1000)
        {
            if (clear) Clear();
            var vertical = Console.WindowHeight / 2;
            var horizontal = (Console.WindowWidth / 2) - (message.Length / 2);
            Console.SetCursorPosition(horizontal, vertical);
            var pausePerCharacter = milliseconds / message.Length;
            foreach (var character in message)
            {
                Console.Write(character);
                Thread.Sleep(pausePerCharacter);
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
