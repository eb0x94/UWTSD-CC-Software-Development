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
            generateCells();
        }

        private void generateCells()
        {
            int cellIndex = 1;
            for (int rows = 0; rows < 10; rows++)
            {
                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols < 10; cols++)
                    {
                        cells[rows, cols] = new Cell(posX, posY, cellIndex);
                        posX += 51;
                        cellIndex++;
                    }
                }
                else
                {
                    posY -= 47;
                    for (int cols = 0; cols < 10; cols++)
                    {
                        cells[rows, cols] = new Cell(posX, posY, cellIndex);
                        posX -= 51;
                        cellIndex++;
                    }
                }
            }
           
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

            if (isRedPlayerIn)
            {
                Logics.movePlayer(pictureBox4, dice, ref posX, ref posY, ref playerPosition);
            }


            if (dice == 6 && isRedPlayerIn == false)
            {
                isRedPlayerIn = true;
                this.playerPosition = 1;
                this.pictureBox1.Visible = false;
                this.pictureBox4.Visible = true;
                this.pictureBox4.Location = new Point(posX, posY);
            }
        }

        private void gameBoard1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
