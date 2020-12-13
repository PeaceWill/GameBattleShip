using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleShip
{
    class Stone: ImgRendingObject
    {
        public Stone(Image img, Point location, Size size, int step) : base(img, location, size, step)
        {

        }
    }
}
