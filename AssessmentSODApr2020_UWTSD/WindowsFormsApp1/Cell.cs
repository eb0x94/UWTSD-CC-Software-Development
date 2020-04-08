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
        private bool boostOrSnake;

        public Cell(int xpos, int ypos, int index)
        {
            this.posX = xpos;
            this.posY = ypos;
            this.index = index;
        }

        private void setBoost(bool boost)
        {
            this.boostOrSnake = boost;
        }

        private int getPosX()
        {
            return this.posX;
        }

        private int getPosY()
        {
            return this.posY;
        }
    }
}
