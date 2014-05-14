using projectcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectcsharp
{
    public partial class MyPanel : Panel
    {
        private MovingMan movingMan;
        private System.Windows.Forms.Timer timer;
        private PictureBox superman;
        private bool running;

        public MyPanel()
        {
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.smallsuperman;
            superman.Size = new System.Drawing.Size(50, 50);
            superman.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(superman);
            this.timer = new System.Windows.Forms.Timer();
            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
            running = true;
            Restart();
            startAnimation();
        }

        public void UpdateGraphics()
        {
            while (running)
            {
                this.Invalidate(); //kaller på OnPaint()
                Thread.Sleep(17); //å la tråden sove i 17 ms er optimalt for å oppnå en framerate på ca 60 FPS
            }
        }

        private void startAnimation()
        {
            ThreadStart ts = new ThreadStart(UpdateGraphics);
            Thread thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Restart()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint,
             true);
            this.UpdateStyles();

            this.movingMan = new MovingMan
            {
                X = 10f,
                Y = 10f,
                DX = 2f,
                DY = 2f,

            };

            superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            var left = KeyboardInfo.GetKeyState(Keys.Left);
            var right = KeyboardInfo.GetKeyState(Keys.Right);
            var up = KeyboardInfo.GetKeyState(Keys.Up);
            var down = KeyboardInfo.GetKeyState(Keys.Down);

            if (movingMan.Y < (this.Parent.Height - ((this.Parent.Height * 0.11) + 50)))
            {

                if (left.IsPressed)
                {
                    movingMan.MoveLeft();
                }

                if (right.IsPressed)
                {
                    movingMan.MoveRight();
                }

                if (up.IsPressed)
                {
                    movingMan.MoveUp();
                }

                if (down.IsPressed)
                {
                    movingMan.MoveDown();
                }
                else
                {
                    if (movingMan.X != 10f && !up.IsPressed)
                    {
                        movingMan.Drop();
                    }
                }

            }
            else
            {
                timer.Stop();

                MessageBox.Show("Game over!");
            }

        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.movingMan != null)
            {
                this.movingMan.Draw(e.Graphics);
            }
            superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);
        }
    }
}
