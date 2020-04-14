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
        private int posX;
        private int posY;
        private bool isLadder;
        private bool isSnake;
        private int targetIndex;

        public Cell(int xpos, int ypos, int index)
        {
            this.posX = xpos;
            this.posY = ypos;
            this.index = index;
            this.isLadder = false;
            this.isSnake = false;
            this.targetIndex = index;
        }


        public void setTargetIndex(int target)
        {
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

        public int getTargetIndex()
        {
            return this.targetIndex;
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
