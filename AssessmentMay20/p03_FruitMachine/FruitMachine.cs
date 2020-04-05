using System;

namespace p03_FruitMachine
{
    class FruitMachine
    {
        private static readonly int SMALL_BONUS = 5;
        private static readonly int BIG_BONUS = 5;
        private static readonly int SMALL_JACKPOT = 200;
        private static readonly int BIG_JACKPOT = 2000;
        static void Main(string[] args)
        {
            Random rndGen = new Random();
            int totalPoints = 0;
            string winOrLose;
            Console.Write("Spin? Y/N: ");
            string choice = Console.ReadLine().ToLower();
            int[] numbers = new int[3];

            while (choice == "y")
            {
                winOrLose = "lose";
                numbers[0] = rndGen.Next(0, 10);
                numbers[1] = rndGen.Next(0, 10);
                numbers[2] = rndGen.Next(0, 10);

                if (numbers[0] == 9 && numbers[1] == numbers[0] && numbers[2] == numbers[0])
                {
                    totalPoints += BIG_JACKPOT;
                    winOrLose = "win";
                }
                else if ((numbers[0] == 9 && numbers[1] == numbers[0]) || 
                    (numbers[1] == 9 && numbers[2] == numbers[1]) || 
                    (numbers[2] == 9 && numbers[0] == numbers[2]))
                {
                    totalPoints += SMALL_JACKPOT;
                    winOrLose = "win";
                }
                else if (numbers[0] == numbers[1] ||
                    numbers[1] == numbers[2] ||
                    numbers[0] == numbers[2])
                {
                    totalPoints += SMALL_BONUS;
                    winOrLose = "win";
                }
                else if (numbers[0] == numbers[1] && numbers[1] == numbers[2])
                {
                    totalPoints += BIG_BONUS;
                    winOrLose = "win";
                }

                Console.WriteLine("{2} {3} {4}\nYou {0}, your points are: {1}", winOrLose, totalPoints, numbers[0], numbers[1], numbers[2]);
                Console.Write("Spin? Y/N: ");
                choice = Console.ReadLine().ToLower();
            }
            Console.WriteLine("Total points for this game: {0}", totalPoints);
        }
    }
}
