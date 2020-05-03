using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool isRedPlayerIn = false;
        private int posX = 3, posY = 418;
        private string initialDiceImg;
        private string diceImg;
        private string resourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources";
        private int playerPosition;
        private Cell[,] cells;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cells = new Cell[10, 10];
            this.playerPosition = 0;
            this.initialDiceImg = resourcePath + "\\Dices\\roll the dice.png";
            this.diceImg = resourcePath + "\\Dices";
            this.pictureBox4.Visible = false;
            this.pictureBox3.Image = Image.FromFile(initialDiceImg);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            Logics.generateCells(ref cells, ref posX, ref posY);
            Logics.initSnakes(ref cells);
            Logics.initLadders(ref cells);
            this.label4.Text = "Roll a 6 to enter the game.";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int dice = Logics.rollDice(this.pictureBox3, diceImg);
            label1.Text = "Dice: " + dice.ToString();

            if(playerPosition + dice > 100)
            {
                label4.Text = "Next posistion is out of board.\nPlease, roll again.";
            }
            
            
            if (isRedPlayerIn)
            {
                Logics.MovePlayer(pictureBox4, dice, ref playerPosition, ref cells, ref label4);
                this.label2.Text = "Position: " + this.playerPosition;
            }


            if (dice == 6 && !isRedPlayerIn)
            {
                isRedPlayerIn = true;
                this.playerPosition = 1;
                this.pictureBox1.Visible = false;
                this.pictureBox4.Visible = true;
                this.posX = this.cells[0, 0].getPosX();
                this.posY = this.cells[0, 0].getPosY();
                this.pictureBox4.Location = new Point(this.posX, this.posY);
                this.label2.Text = "Position: " + this.playerPosition;
                this.label4.Text = "You entered the game.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gameBoard1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
