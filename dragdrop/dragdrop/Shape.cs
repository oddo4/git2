using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dragdrop
{
    [DelimitedRecord(",")]
    class Shape
    {
        public double PosX;
        public double PosY;

        public Shape()
        {

        }

        public Shape(double posX, double posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }
}
