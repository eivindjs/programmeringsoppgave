using projectcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectcsharp
{
    public partial class MyPanel : Panel
    {
        private ThreadStart ts;
        private Thread thread;
        private MovingMan movingMan;
        private System.Windows.Forms.Timer timer;
        private PictureBox superman;
        private bool running;
        private Obstacle obstacle1;
        private int manSize;
        private List<Obstacle> listObstacle;
        private Object mySync = new Object();
        
        public MyPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint,
           true);
            this.UpdateStyles();

            manSize = 30;
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.super;
            superman.Size = new System.Drawing.Size(manSize, manSize);
            superman.SizeMode = PictureBoxSizeMode.Zoom;

            this.Controls.Add(superman);
           

            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
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
            ts = new ThreadStart(UpdateGraphics);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Restart()
        {
            listObstacle = new List<Obstacle>();

            for (int i = 1; i <= 2; i++)
            {
                obstacle1 = new Obstacle(i);

                listObstacle.Add(obstacle1);
            }
               
            running = true;

            this.movingMan = new MovingMan
            {
                X = 10f,
                Y = 10f,
                DX = 4f,
                DY = 3f,
            };

            superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);
            timer.Start();

            startAnimation();
        }
     

        void timer_Tick(object sender, EventArgs e)
        {
            var left = KeyEvent.GetKeyState(Keys.Left);
            var right = KeyEvent.GetKeyState(Keys.Right);
            var up = KeyEvent.GetKeyState(Keys.Up);
            var down = KeyEvent.GetKeyState(Keys.Down);

            if (movingMan.Y < (this.Parent.Height - ((this.Parent.Height * 0.11) + 50)))
            {
                int size = this.Size.Height;


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

                if (running)
                {

                    MessageBox.Show("Game over!");
                }
            }
        }
        /// <summary>
        /// Kjøres ved this.Invalidate();
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            lock (mySync)
            {
                if (this.movingMan != null)
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    base.OnPaint(e);

                    GraphicsPath supermanPath = new GraphicsPath();

                    supermanPath.StartFigure(); // Starter en ny figur i samme Path. 
                    supermanPath.AddRectangle(new Rectangle((int)movingMan.X, (int)movingMan.Y, (int)manSize, (int)manSize));
                    supermanPath.CloseFigure();

                    for (int i = 0; i < listObstacle.Count; i++)
                    {
                        Obstacle obstacle = listObstacle[i]; //henter hindring fra lista

                        //LAG REGION


                        //Lag for-løkke for Obstacles 

                        //SJEKK KOLLISJON
                        Region obstacleRegion = new Region(obstacle.GetPath());
                        Region supermanRegion = new Region(supermanPath);


                        obstacleRegion.Intersect(supermanRegion);

                        if (!obstacleRegion.IsEmpty(e.Graphics)) //Kollisjon dersom snittet ikke er tomt. 
                        {
                            timer.Stop();

                            running = false;
                          //  MessageBox.Show("Game over!");

                        }


                        movingMan.Draw(e.Graphics);

                        switch (i)
                        {
                            case 1:
                                obstacle1.Draw(e.Graphics, 100, 100);

                                break;
                            case 2:
                                obstacle1.Draw(e.Graphics, 300, 300);

                                break;
                            default:
                                break;

                        }
                        

                        superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);
                    }
                }
            }
        }
    }
}
