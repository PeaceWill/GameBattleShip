using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleShip
{
    class Rocket:ImgRendingObject
    {
        Image effectBoom;
        bool isBoom;

        public Rocket(Image effectBoom, Image img, Point location, Size size, int step):base(img, location, size, step)
        {
            this.effectBoom = effectBoom;
            this.isBoom = false;
        }

        public Image EffectBoom { get => effectBoom; set => effectBoom = value; }
        public bool IsBoom { get => isBoom; set => isBoom = value; }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawImage(this.img,
                new Rectangle(this.location, this.size),
                new Rectangle(0, 0, this.img.Width, this.img.Height),
                GraphicsUnit.Pixel);
        }

        public override bool isImpact(ImgRendingObject obj)
        {
            bool isIpt = base.isImpact(obj);
            if (isIpt)
            {
                this.isBoom = true;
                this.img = this.effectBoom;
            }
            return isIpt;
        }
    }
}
