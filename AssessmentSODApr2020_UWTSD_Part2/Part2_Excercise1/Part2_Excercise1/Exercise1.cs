using System;
using System.Collections.Generic;

namespace Part2_Excercise1
{
    class Exercise1
    {
        static void Main(string[] args)
        {
            Console.Write("This program calculates pairs of numbers.\nPlease enter Y to start the program or N to close it.\nDo you want to start: Y/N - ");
            List<int> numbers = new List<int>();
            List<int> numbersToPrint = new List<int>();

            bool _continue = true;
            string userInput = Console.ReadLine();

            while (_continue)
            {

                if (userInput.ToLower() == "n")
                {
                    _continue = false;
                    break;
                }
                else if (userInput.ToLower() == "y")
                {
                    Console.Write("Please, enter a integer number: ");
                    userInput = readNumber();
                    if(userInput == "")
                    {
                        Console.WriteLine();
                        continue;
                    }
                    numbers.Add(int.Parse(userInput));
                }
                else
                {
                    Console.Write("Please, enter a valid input!");
                }

                Console.Write("\nDo you want to add a number? : Y/N - ");
                userInput = Console.ReadLine();
            }


            if (numbers.Count % 2 != 0)
            {
                numbers.Add(1);
            }

            for (int i = 0; i < numbers.Count; i+= 2)
            {
                numbersToPrint.Add(numbers[i] * numbers[i + 1]);
            }

            Console.WriteLine("The list of pairs is: " + string.Join(", ", numbersToPrint));
            Console.WriteLine("End");
        }
        static string readNumber()
        {
            ConsoleKeyInfo key;
            string _val = "";

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                    if (_x)
                    {
                        _val += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                    {
                        _val = _val.Substring(0, (_val.Length - 1));
                        Console.Write("\b \b");
                    }

                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);

            return _val;
        }
    }
}
