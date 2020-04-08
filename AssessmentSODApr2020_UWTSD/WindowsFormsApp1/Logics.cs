using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Logics
    {
        public static int rollDice(PictureBox px)
        {
            Random r = new Random();
            int diceNum = r.Next(1, 7);

            px.Image = Image.FromFile(@"C:\Users\megap\OneDrive\Documents\UWTSD Courses\Level 4\Term 2\Software Engineering\VisualStudio\Assessment\AssessmentMay20\WindowsFormsApp1\Resources\Dices\dice " + diceNum + ".jpg");

            return diceNum;
        }

        public static void movePlayer(PictureBox player, int dice, int x, int y)
        {
            player.Location = new Point(x, y);

        }

    }
}
