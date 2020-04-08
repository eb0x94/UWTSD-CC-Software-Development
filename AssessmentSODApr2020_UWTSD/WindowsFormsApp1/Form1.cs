using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        bool isRedPlayerIn = false;
        int x = 3, y = 418;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.pictureBox4.Visible = false;
            this.pictureBox3.Image = Image.FromFile(@"C:\Users\megap\OneDrive\Documents\UWTSD Courses\Level 4\Term 2\Software Engineering\VisualStudio\Assessment\AssessmentMay20\WindowsFormsApp1\Resources\Dices\roll the dice.png");
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dice = Logics.rollDice(this.pictureBox3);

            if (isRedPlayerIn)
            {
                x += 51;
                Logics.movePlayer(pictureBox4, dice, x, y);
            }


            if (dice == 6 && isRedPlayerIn == false)
            {
                isRedPlayerIn = true;
                this.pictureBox1.Visible = false;
                this.pictureBox4.Visible = true;
                this.pictureBox4.Location = new Point(x, y);
            }
        }

        private void gameBoard1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
