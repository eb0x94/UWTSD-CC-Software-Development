using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Logics
    {
        private const int ROW_LENGTH = 10;
        public static int rollDice(PictureBox px, string diceImg)
        {
            Random r = new Random();
            int diceNum = r.Next(1, 7);

            px.Image = Image.FromFile(diceImg + "\\dice " + diceNum + ".jpg");

            return diceNum;
        }

        public static void movePlayer(PictureBox player, int dice, ref int x, ref int y, ref int pPosition)
        {
            bool moveLeft = false;
            player.Visible = false;
            int nextPos = pPosition + dice;
            int rowPos = pPosition;

            if (nextPos > ROW_LENGTH)
            {
                rowPos = int.Parse(pPosition.ToString().Substring(1));
                moveLeft = true;
            }

            if (moveLeft)
            {

            }
            pPosition = nextPos;
            player.Visible = true;
        }

    }
}
