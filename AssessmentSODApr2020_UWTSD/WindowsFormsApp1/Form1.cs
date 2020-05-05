using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private bool isPlayerIn = false;
        private int posX = 3, posY = 418;
        private string initialDiceImg;
        private string diceImg;
        private string resourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources";
        private int playerPosition;
        private Cell[,] cells;

        public Form1()
        {
            //Initializes all the components for the game.
            InitializeComponent();
        }

        // Loads all the initial logic for the game and components.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cells = new Cell[10, 10];
            this.playerPosition = 0;
            this.initialDiceImg = resourcePath + "\\Dices\\roll the dice.png";
            this.diceImg = resourcePath + "\\Dices";
            this.pictureBox4.Visible = false;
            this.pictureBox3.Image = Image.FromFile(initialDiceImg);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            Logics.generateCells(ref cells, ref posX, ref posY); // Calls funtion from Logics.cs class to generate the skeleton for the gameboard.
            Logics.initSnakes(ref cells); // Initalizes the snake boxes and their location.
            Logics.initLadders(ref cells);// Initializes the ladder boxes and their location.
            this.label4.Text = "Roll a 6 to enter the game.";
        }


        //Event handler for clicking the "Roll button"
        private void button1_Click(object sender, EventArgs e)
        {
            /// It creates a random value for dice.
            int dice = Logics.rollDice(this.pictureBox3, diceImg);
            label1.Text = "Dice: " + dice.ToString();

            /// If the position of the player is more than 100 it doesn't move the player to next position, unless it is less than 100.
            if (playerPosition + dice > 100)
            {
                label4.Text = "Next posistion is out of board.\nPlease, roll again.";
            }


            /// If the player is on the board, it calls a function from the Logics.cs class to move the player. 
            /// The function takes reference to the fields from this class and it changes their value after calculation.
            if (isPlayerIn)
            {
                Logics.MovePlayer(pictureBox4, dice, ref playerPosition, ref cells, ref label4);
                this.label2.Text = "Position: " + this.playerPosition;
            }

            /// If the rolled dice has value of 6 and the player is not on the board,it sets player position on the board and it moves the player element on starting point.
            /// It tells to the player that his character is on the board.
            if (dice == 6 && !isPlayerIn)
            {
                isPlayerIn = true;
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
    }
}
