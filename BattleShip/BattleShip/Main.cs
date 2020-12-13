using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BattleShip
{
    public partial class Main : Form
    {
        bool isGameOver;
        Ship ship;
        List<Stone> stones;
        int MAX_STONE_SLICE = 10;
        int stoneSlice;
        Image stoneImg;
        Random random;
        List<Rocket> rockets;

        int score;

        public Main()
        {
            InitializeComponent();
            //form
            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(600, 600);

            //object
            Image img = Image.FromFile(@"ship.png");
            ship = new Ship(img,
                            new Point(this.ClientSize.Width / 2 - 30, this.ClientSize.Height - 60),
                            new Size(60, 60), 10);

            stones = new List<Stone>();
            stoneSlice = MAX_STONE_SLICE;
            stoneImg = Image.FromFile(@"stone.png");

            random = new Random((int)DateTime.Now.Ticks);

            rockets = new List<Rocket>();
            score = 0;
            isGameOver = false;

            //
            //Timer update = new Timer();

            // timer stone
            updateStones.Interval = 50;
            updateStones.Tick += update_Tick;
            updateStones.Start();

            // timer rocket
            updateRocket.Interval = 300;
            updateRocket.Tick += updareRocket_Tick;
            updateRocket.Start();
        }

        //  update stone
        private void update_Tick(object sender, EventArgs e)
        {
            if (!isGameOver)
            {
                for (int i = stones.Count - 1; i >= 0; i--)
                {
                    if (ship.isImpact(stones[i]))
                    {
                        isGameOver = true;
                        gameOver();
                    }
                    if (stones[i].isOutFrame(this.ClientSize))
                    {
                        stones.RemoveAt(i);
                    }
                    else
                    {
                        stones[i].Move(direction.Down);
                    }
                }

                if (stoneSlice == 0)
                {
                    stones.Add(new Stone(stoneImg, new Point(random.Next(0, this.ClientSize.Width - 60), 0),
                                new Size(60, 60), 5));
                }
                stoneSlice--;
                if (stoneSlice < 0)
                {
                    stoneSlice = MAX_STONE_SLICE;
                }
                this.Invalidate();
            }
        }

        // update rocket
        private void updareRocket_Tick(object sender, EventArgs e)
        {
            // auto fire
            rockets.Add(ship.rocketFire());

            //
            for (int i = rockets.Count - 1; i >= 0; i--)
            {
                if (rockets[i].IsBoom)
                {
                    rockets.RemoveAt(i);
                    break;
                }
                bool isIpt = false;
                foreach (var s in stones)
                {
                    if (rockets[i].isImpact(s))
                    {
                        isIpt = true;
                        stones.Remove(s);
                        score++;
                        rockets[i].IsBoom = true;
                        break;
                    }
                }
                if (!isIpt)
                {
                    rockets[i].Move(direction.Up);
                }
            }
            this.Invalidate();
        }

        // game over
        private void gameOver()
        {
            if (isGameOver)
            {
                this.updateStones.Stop();
                this.updateRocket.Stop();
                MessageBox.Show("Game Over");

                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            ship.Draw(g);

            foreach (var s in stones)
            {
                s.Draw(g);
            }

            foreach (var r in rockets)
            {
                r.Draw(g);
            }

            string strScore = "Score: " + score.ToString();
            Font scoreFont = new Font(FontFamily.GenericSansSerif, 18);
            Size size = TextRenderer.MeasureText(strScore, scoreFont);
            g.DrawString(strScore, scoreFont, new SolidBrush(Color.White), new Point(0, this.ClientSize.Height - size.Height));

        }

        private void Main_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {           
            switch (e.KeyCode)
            {
                // phim di chuyen ship A,S,D,W va mui ten
                case Keys.Left:
                    ship.Move(direction.Left);
                    break;
                case Keys.Up:
                    ship.Move(direction.Up);
                    break;
                case Keys.Right:
                    ship.Move(direction.Right);
                    break;
                case Keys.Down:
                    ship.Move(direction.Down);
                    break;
                case Keys.W:
                    ship.Move(direction.Up);
                    break;
                case Keys.A:
                    ship.Move(direction.Left);
                    break;
                case Keys.S:
                    ship.Move(direction.Down);
                    break;
                case Keys.D:
                    ship.Move(direction.Right);
                    break;

                // phim space de ban ten lua
                case Keys.Space:
                    rockets.Add(ship.rocketFire());
                    break;
            }
        }
       
    }
}
