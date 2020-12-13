using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleShip
{
    enum direction { Up, Down, Left, Right };

    abstract class ImgRendingObject
    {
        protected Image img;
        protected Point location;
        protected Size size;
        protected int step;

        public ImgRendingObject(Image img, Point location, Size size, int step)
        {
            this.img = img;
            this.location = location;
            this.size = size;
            this.step = step;
        }

        public Image Img { get => img; set => img = value; }
        public Point Location { get => location; set => location = value; }
        public Size Size { get => size; set => size = value; }
        public int Step { get => step; set => step = value; }

        public Rectangle Rect { get => new Rectangle(location, size); }

        virtual public void Draw(Graphics g)
        {
            g.DrawImage(this.img,
                new Rectangle(this.location, this.size),
                new Rectangle(0, 0, this.img.Width, this.img.Height),
                GraphicsUnit.Pixel);
        }

        virtual public void Move(direction dir)
        {
            switch (dir)
            {
                case direction.Up:
                    location.Y -= step;
                    break;
                case direction.Down:
                    location.Y += step;
                    break;
                case direction.Left:
                    location.X -= step;
                    break;
                case direction.Right:
                    location.X += step;
                    break;               
            }
        }

        virtual public bool isImpact(ImgRendingObject obj)
        {
            return this.Rect.IntersectsWith(obj.Rect);
        }

        virtual public bool isOutFrame(Size size)
        {
            return !(new Rectangle(0, 0, size.Width, size.Height).IntersectsWith(this.Rect));
        }
    }
}
