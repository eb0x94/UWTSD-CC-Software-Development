using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Logics
    {
        internal static int rollDice(PictureBox px, string diceImg)
        {
            Random r = new Random();
            int diceNum = r.Next(1, 7);

            px.Image = Image.FromFile(diceImg + "\\dice " + diceNum + ".jpg");


            return diceNum;
        }

        internal static void MovePlayer(PictureBox player, int dice, ref int pPosition, ref Cell[,] cell)
        {
            player.Visible = false;
            int nextPos = pPosition + dice;

            for (int rows = 0; rows < 10; rows++)
            {
                for (int cols = 0; cols < 10; cols++)
                {
                    if (nextPos == cell[rows, cols].getIndex())
                    {
                        if (cell[rows, cols].getLadder())
                        {
                            int target = cell[rows, cols].getTargetIndex();
                            break;
                        }
                        else if (cell[rows, cols].getSnake())
                        {
                            break;
                        }
                        player.Location = new Point(cell[rows, cols].getPosX(), cell[rows, cols].getPosY());
                    }
                }
            }
            pPosition = nextPos;
            player.Visible = true;
        }



        internal static void generateCells(ref Cell[,] cells, ref int posX, ref int posY)
        {
            int cellIndex = 1;
            for (int rows = 0; rows < 10; rows++)
            {
                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols < 10; cols++)
                    {

                        cells[rows, cols] = new Cell(posX, posY, cellIndex);
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

                    for (int cols = 10; cols > 0; cols--)
                    {

                        cells[rows, cols - 1] = new Cell(posX, posY, cellIndex);
                        if (cols == 1)
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

        internal static void initLadders(ref Cell[,] cells)
        {
            for (int rows = 0; rows < 10; rows++)
            {
                for (int cols = 0; cols < 10; cols++)
                {
                    switch (cells[rows, cols].getIndex())
                    {
                        case 4:
                            cells[rows, cols].setTargetIndex(14);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 9:
                            cells[rows, cols].setTargetIndex(31);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 21:
                            cells[rows, cols].setTargetIndex(42);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 28:
                            cells[rows, cols].setTargetIndex(84); 
                            cells[rows, cols].setLadder(true);
                            break;
                        case 51:
                            cells[rows, cols].setTargetIndex(67);
                            cells[rows, cols].setLadder(true);
                            break;
                        case 71:
                            cells[rows, cols].setTargetIndex(91); 
                            cells[rows, cols].setLadder(true);
                            break;
                        case 80:
                            cells[rows, cols].setTargetIndex(100);
                            cells[rows, cols].setLadder(true);
                            break;

                    }
                }
            }
        }

        internal static void initSnakes(ref Cell[,] cells)
        {
            for (int rows = 0; rows < 10; rows++)
            {
                for (int cols = 0; cols < 10; cols++)
                {
                    switch (cells[rows, cols].getIndex())
                    {
                        case 17:
                            cells[rows, cols].setTargetIndex(7);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 54:
                            cells[rows, cols].setTargetIndex(34);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 62:
                            cells[rows, cols].setTargetIndex(19);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 64:
                            cells[rows, cols].setTargetIndex(60);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 87:
                            cells[rows, cols].setTargetIndex(24);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 93:
                            cells[rows, cols].setTargetIndex(73);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 95:
                            cells[rows, cols].setTargetIndex(75);
                            cells[rows, cols].setSnake(true);
                            break;
                        case 98:
                            cells[rows, cols].setTargetIndex(79);
                            cells[rows, cols].setSnake(true);
                            break;

                    }
                }
            }
        }
    }
}
