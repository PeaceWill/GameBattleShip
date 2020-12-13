using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleShip
{
    class Ship:ImgRendingObject
    {
        public Ship(Image img, Point location, Size size, int step) : base(img, location, size, step)
        {

        }
        public Rocket rocketFire()
        {
            Image boom = Image.FromFile(@"boom.png");
            Image rocket = Image.FromFile(@"rocket.png");
            return new Rocket(boom, rocket, new Point(this.location.X, this.location.Y - this.size.Height), this.size, 10);
                 
        }
    }
}
