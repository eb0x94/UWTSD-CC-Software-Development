using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Logics
    {
        /// <summary>
        /// This is the a class, which holds all the game logic for all the movement and board control of the charachter.
        /// </summary>
        /// <param name="px"></param>
        /// <param name="diceImg"></param>
        /// <returns></returns>
        internal static int rollDice(PictureBox px, string diceImg)
        {
            //generates random value between 1 and 6 for the dice value.
            Random r = new Random();
            int diceNum = r.Next(1, 7);
            // sets the image from the Resource folder string for the corresponding dice value to the passed from outside PictureBox object.
            px.Image = Image.FromFile(diceImg + "\\dice " + diceNum + ".jpg");


            return diceNum;
        }


        internal static void MovePlayer(PictureBox player, int dice, ref int pPosition, ref Cell[,] cell, ref Label label4)
        {
            player.Visible = false;
            int nextPos = pPosition + dice;
            int nextRow = 0;
            int nextCol = 0;
            bool isFound = false;

            for (int rows = 0; rows <= cell.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols <= cell.GetLength(1) - 1; cols++)
                {
                    if (nextPos == cell[rows, cols].getIndex())
                    {
                        isFound = true;
                        nextRow = rows;
                        nextCol = cols;
                        label4.Text = "You are on normal box, please roll the dice.";
                        if (cell[rows, cols].getLadder() || cell[rows, cols].getSnake())
                        {
                            nextRow = cell[rows, cols].getTargetIndex()[0];
                            nextCol = cell[rows, cols].getTargetIndex()[1];
                            if (cell[rows, cols].getLadder())
                            {
                                label4.Text = "You hit on a ladder box at position "
                                    + cell[rows, cols].getIndex() + "\nand went up to position " +
                                    cell[nextRow, nextCol].getIndex() + "\nPlease, roll the dice.";
                            }
                            else
                            {
                                label4.Text = "You hit a snake box at position " + cell[rows, cols].getIndex() +
                                    "\nand went down to position " + cell[nextRow, nextCol].getIndex() + "\nPlease, roll the dice.";
                            }
                        }
                        player.Location = new Point(cell[nextRow, nextCol].getPosX(), cell[nextRow, nextCol].getPosY());
                        pPosition = cell[nextRow, nextCol].getIndex();
                        break;
                    }

                }
                if (isFound)
                {
                    break;
                }
            }

            if (pPosition == 100)
            {
                label4.Text = "You won the game!!!";
                DialogResult result = MessageBox.Show("You won!", "You won the game!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Retry)
                {
                    Application.Restart();
                }
                else if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
            player.Visible = true;
        }



        internal static void generateCells(ref Cell[,] cells, ref int posX, ref int posY)
        {
            int cellIndex = 1;
            for (int rows = 0; rows <= cells.GetLength(0) - 1; rows++)
            {
                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols <= cells.GetLength(1) - 1; cols++)
                    {

                        cells[rows, cols] = new Cell(posX, posY, cellIndex, rows, cols);
                        if (cols == 9)
                        {
                            posY -= 45;
                            cellIndex++;
                            continue;
                        }
                        posX += 51;
                        cellIndex++;
                    }
                }
                else
                {
                    for (int cols = cells.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        cells[rows, cols] = new Cell(posX, posY, cellIndex, rows, cols);
                        if (cols == 0)
                        {
                            posY -= 45;
                            cellIndex++;
                            continue;
                        }
                        posX -= 51;
                        cellIndex++;
                    }

                }

            }
        }

        //Initalizes the ladders on the board before loading.
        internal static void initLadders(ref Cell[,] cells)
        {
            for (int rows = 0; rows < 10; rows++)
            {
                for (int cols = 0; cols < 10; cols++)
                {
                    switch (cells[rows, cols].getIndex())
                    {
                        case 4:
                            cells[rows, cols].setTargetIndex(1, 6);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 9:
                            cells[rows, cols].setTargetIndex(3, 9);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 21:
                            cells[rows, cols].setTargetIndex(4, 1);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 28:
                            cells[rows, cols].setTargetIndex(8, 3);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 51:
                            cells[rows, cols].setTargetIndex(6, 6);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 71:
                            cells[rows, cols].setTargetIndex(9, 9);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 80:
                            cells[rows, cols].setTargetIndex(9, 0);
                            cells[rows, cols].setLadder(true);
                            break;

                    }
                }
            }
        }

        //Initalizes the snakes on the board before loading.
        internal static void initSnakes(ref Cell[,] cells)
        {
            for (int rows = 0; rows < 10; rows++)
            {
                for (int cols = 0; cols < 10; cols++)
                {
                    switch (cells[rows, cols].getIndex())
                    {
                        case 17:
                            cells[rows, cols].setTargetIndex(0, 6);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 54:
                            cells[rows, cols].setTargetIndex(3, 6);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 62:
                            cells[rows, cols].setTargetIndex(1, 1);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 64:
                            cells[rows, cols].setTargetIndex(5, 0);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 87:
                            cells[rows, cols].setTargetIndex(2, 3);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 93:
                            cells[rows, cols].setTargetIndex(7, 7);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 95:
                            cells[rows, cols].setTargetIndex(7, 5);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 98:
                            cells[rows, cols].setTargetIndex(7, 1);
                            cells[rows, cols].setSnake(true);
                            break;

                    }
                }
            }
        }
    }
}
