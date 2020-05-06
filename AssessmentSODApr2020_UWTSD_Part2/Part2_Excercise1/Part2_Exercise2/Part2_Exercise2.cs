using System;
using System.Text;

namespace Part2_Exercise2
{
    class Part2_Exercise2
    {
        static void Main(string[] args)
        {
            int p1TotalPoints = 0; int p2TotalPoints = 0;
            int p1CurrentPoints; int p2CurrentPoints;
            int loopLength = 10;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < loopLength; i++)
            {
                try
                {
                    Console.Write("Goals Player One: ");
                    p1CurrentPoints = int.Parse(Console.ReadLine());
                    p1TotalPoints += p1CurrentPoints;
                    Console.Write("Goals Player Two: ");
                    p2CurrentPoints = int.Parse(Console.ReadLine());
                    p2TotalPoints += p2CurrentPoints;

                    sb.Append(CheckScore(p1CurrentPoints, p2CurrentPoints)[0]);
                    Console.WriteLine(sb);
                    sb.Clear();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Please, enter valid integer value.");
                    loopLength++;
                    continue;
                }
            }

            sb.AppendFormat("Player One points: {0}\nPlayer Two points: {1}\n{2} and is a champion with {3} points",
                p1TotalPoints,
                p2TotalPoints,
                CheckScore(p1TotalPoints, p2TotalPoints)[0],
                CheckScore(p1TotalPoints, p2TotalPoints)[1]);

            if (p1TotalPoints == p2TotalPoints)
            {
                sb.Clear();
                sb.Append("It is a total draw. There is no champion.");
            }

            Console.WriteLine(sb.ToString());
        }

        private static string[] CheckScore(int p1, int p2)
        {
            string[] result = new string[2];
            if (p1 > p2)
            {
                result[0] = "Player One wins";
                result[1] = p1.ToString();
            }
            else if (p1 < p2)
            {
                result[0] = "Player Two wins";
                result[1] = p2.ToString();
            }
            else
            {
                result[0] = "It's a draw";
                result[1] = "0";
            }

            return result;
        }
    }
}
