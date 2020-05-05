using System;

namespace TestAppendixApp
{
    class Program
    {
        const int MAXNUMBERS = 3;
        static void Main(string[] args)
        {
            int[] theNumbers = new int[MAXNUMBERS]; 
            int chosenOption = 0;
            bool quit = false;
            InitialiseNumbers(theNumbers);
            while (quit == false)
            {
                DisplayHeader();
                DisplayMenu();
                chosenOption = ReadNumber("Please choose an option: ");
                quit = ProcessMenu(chosenOption, theNumbers);
                Console.Clear();
            }
        }

        static void InitialiseNumbers(int[] numbers)
        {
            for (int index = 0; index < MAXNUMBERS; index++)
            {
                numbers[index] = 0;
            }
        }

        static void DisplayHeader()
        {
            WriteText("*******************************************************************************", 0, 0); // Top left hand corner of screen is x = 0, y = 0
            WriteText("* This application is designed to allow you to choose numbers *", 0, 1); // Next line down is x = 0, y = 1, etc
            WriteText("* and finds the biggest and the smallest value *", 0, 2);
            WriteText("*******************************************************************************", 0, 3);
        }

        static void DisplayMenu()
        {
            WriteText("Select an option", 20, 8); // Display menu at at x = 20, y = 8
            WriteText("1. Enter the numbers", 20, 9);
            WriteText("2. Find the smallest", 20, 10);
            WriteText("3. Find the largest", 20, 11);
            WriteText("4. Display all numbers", 20,
            12); WriteText("5. Quit", 20, 13);
        }

        static void WriteText(string text, int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(text);
        }

        static int ReadNumber(string prompt)
        {
            string text;
            int number;
            WriteText(prompt, 20, 14);
            text = Console.ReadLine();
            number = int.Parse(text);
            ClearText(20, 14, prompt.Length + text.Length); // Clear the text at this line
            return number;
        }

        static void ClearText(int x, int y, int length)
        {
            // Write space ' ' characters starting at x, y for 'length' times
            WriteText(new String(' ', length), x, y);
        }

        static bool ProcessMenu(int option, int[] numbers)
        {
            bool quit = false;
            switch (option)
            {
                case 1:
            GetNumbers(numbers);
                    break;
                case 2:
                    WriteText(string.Format("The smallest value is {0}", FindSmallest(numbers)), 20, 15);
                    Console.ReadKey(); // Pause
                    break;
                case 3:
                    WriteText(string.Format("The largest value is {0}", FindLargest(numbers)), 20, 15);
                    Console.ReadKey(); // Pause
                    break;
                case 4:
                    quit = IsQuitting();
                    break;
                case 5:
                    quit = IsQuitting();
                    break;
                default:
                    WriteText("Unknown option value entered", 20, 15);
                    Console.ReadKey(); // Pause
                    break;
            }
            return quit;
        }

        static void GetNumbers(int[] numbers)
        {
            for (int index = 0; index < MAXNUMBERS; index++)
            {
                numbers[index] = ReadNumber("Enter number: ");
            }

        }

        static int FindSmallest(int[] numbers)
        {
            int smallest = numbers[0];
            for (int index = 0; index < MAXNUMBERS - 1; index++) // <-- subtract 1
            {
                if (numbers[index + 1] < smallest)
                {
                    smallest = numbers[index + 1];
                }
            }
            return smallest;
        }

        static int FindLargest(int[] numbers)
        {
            int largest = numbers[0];
            for (int index = 0; index < MAXNUMBERS - 1; index++) // <-- subtract 1
            {
                if (numbers[index + 1] > largest)
                {
                    largest = numbers[index + 1];
                }
            }
            return largest;
        }

        static bool IsQuitting()
        {
            string response;
            bool quit = false;
            WriteText("Do you really wish to quit? ", 20,
            13); response = Console.ReadLine();
            if (response == "YES")
            {
                quit = true;
            }
            return quit;
        }

    }
}
