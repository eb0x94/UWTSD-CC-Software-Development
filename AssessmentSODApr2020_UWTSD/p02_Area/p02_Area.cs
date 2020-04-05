using System;

namespace p02_Area
{
    class p02_Area
    {
        private static readonly int SMALL_AREA = 4;
        static void Main(string[] args)
        {
            bool tryAgain = true;
            int x = 0;
            int y = 0;
            //Read input from console
            while (tryAgain)
            {

                try
                {
                    Console.Write("Enter X value: ");
                    x = int.Parse(Console.ReadLine());
                    Console.Write("Enter Y value: ");
                    y = int.Parse(Console.ReadLine());
                }
                //Catch exceptions if wrong input is entered
                catch (FormatException wrong)
                {
                    Console.WriteLine("Please, enter a valid integer number.");
                    continue;
                }

                //Calculate area and find shaded area by subtracting the unshaded one.
                int area = (x * y) - (7 * (y - 3) + SMALL_AREA);

                //Print output
                Console.WriteLine("The shaded area is: {0}", area);
                tryAgain = false;
            }
        }
    }
}
