using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using projectcsharp;

namespace projectcharp
{
    class Ball
    {
        //Størrelse:
        public float diameter;
        private Random rnd = new Random();
        public float x;
        public float y;
        private float dx;
        private float dy;
        private Brush myBrush;
        public bool keepGoing { get; set; }
        private MyPanel parentPanel;
        private Object mySync = new Object();


        public Ball(MyPanel _parentPanel)
        {
            parentPanel = _parentPanel;
            diameter = rnd.Next(9, 39);
            x = rnd.Next(0, _parentPanel.Width);
            y = rnd.Next(0, _parentPanel.Height);
            dx = rnd.Next(1, 10);
            dy = rnd.Next(1, 10);
            Color ballColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            myBrush = new SolidBrush(ballColor);
            keepGoing = true;
            ThreadStart ts = new ThreadStart(Run);
            Thread thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Run()
        {
            while (keepGoing)
            {
                move();
                Thread.Sleep(10);
            }

        }
        public void move()
        {
            lock (mySync)
            {
                x += dx;
                y += dy;
                Size panelSize = parentPanel.ClientRectangle.Size;
                if (x < 0)
                {
                    x = 0;
                    dx = -dx;
                }

                if (x + diameter >= panelSize.Width)
                {
                    x = panelSize.Width - diameter;
                    dx = -dx;
                }

                if (y < 0)
                {
                    y = 0;
                    dy = -dy;
                }

                if (y + diameter >= panelSize.Height)
                {
                    y = panelSize.Height - diameter;
                    dy = -dy;
                }
            }
        }

        public void draw(Graphics g)
        {
            g.FillEllipse(myBrush, x, y, diameter, diameter);
        }

    }
}
