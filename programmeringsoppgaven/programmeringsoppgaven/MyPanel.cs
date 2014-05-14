using projectcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectcsharp
{
    public partial class MyPanel : Panel
    {
        private MovingMan movingMan;
        private Timer timer;
        private PictureBox superman;
   

        public MyPanel()
        {
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.smallsuperman;
            superman.Size = new System.Drawing.Size(50, 50);
            superman.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(superman);
            this.timer = new Timer();
            this.timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
          

            Restart();
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
                    this.Invalidate();
                }

                if (right.IsPressed)
                {
                    movingMan.MoveRight();
                    this.Invalidate();
                }

                if (up.IsPressed)
                {
                    movingMan.MoveUp();
                    this.Invalidate();
                }

                if (down.IsPressed)
                {
                    movingMan.MoveDown();
                    this.Invalidate();
                }
                else
                {
                    if (movingMan.X != 10f && !up.IsPressed)
                    {
                        movingMan.Drop();
                        this.Invalidate();
                    }
                }

                superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);
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
        }
    }
}
