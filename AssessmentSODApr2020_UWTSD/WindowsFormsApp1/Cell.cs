using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Cell
    {
        private int index;
        private int rowIndex;
        private int colIndex;
        private int posX;
        private int posY;
        private bool isLadder;
        private bool isSnake;
        private int targetIndex;

        public Cell(int xpos, int ypos, int index, int rowIndex, int colIndex)
        {
            this.posX = xpos;
            this.posY = ypos;
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
            this.index = index;
            this.isLadder = false;
            this.isSnake = false;
            this.targetIndex = index;
        }


        public void setTargetIndex(int target)
        {
            string targetToStr = String.Empty;
            if (target < 10)
            {
                targetToStr += "0";
                targetToStr += target.ToString();
                this.rowIndex = int.Parse(targetToStr[0].ToString());
                this.colIndex = int.Parse(targetToStr[1].ToString()) - 1;
            }
            else
            {
                targetToStr = target.ToString();
                this.rowIndex = int.Parse(targetToStr[0].ToString());
                this.colIndex = 10 - (int.Parse(targetToStr[1].ToString()));
            }

            this.targetIndex = target;
        }
        public void setLadder(bool ladder)
        {
            this.isLadder = ladder;
        }

        public void setSnake(bool snake)
        {
            this.isSnake = snake;
        }

        public bool getLadder()
        {
            return this.isLadder;
        }

        public int[] getTargetIndex()
        {
            int[] targetArray = new int[] { this.rowIndex, colIndex };
            return targetArray;
        }

        public bool getSnake()
        {
            return this.isSnake;
        }

        public int getPosX()
        {
            return this.posX;
        }

        public int getPosY()
        {
            return this.posY;
        }

        public int getIndex()
        {
            return this.index;
        }
    }
}
