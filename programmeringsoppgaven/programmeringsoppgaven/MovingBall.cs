using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projectcsharp
{
    /// <summary>
    /// En klasse for ballene som skal skytes.
    /// </summary>
    public class MovingBall
    {

        
        private int x, y, direction; //variabler for plassering og retning
        private int h = 7;
        private int w = 7;
        private GraphicsPath myPath = new GraphicsPath();

        public MovingBall(int x, int y, int direction)
        {

            this.x = x;
            this.y = y;
            myPath.AddEllipse(x, y, w, h);
            this.direction = direction;
            Thread t = new Thread(new ThreadStart(Run));
            t.IsBackground = true;
            t.Start(); 
        }
        /// <summary>
        /// Metode for hvordan ballene skal beveges i forhold til skytterne
        /// </summary>
        public void Move()
        { 
            //finner ut sånn at ballene skyter rett
            if (direction == 1)
            {
                y --;
            }
            else if (direction == 2)
            {
                x ++;
            }
            else if (direction == 3)
            {
                x--;
            }
            else if (direction == 4)
            {
                y++;
            }
        }
        /// <summary>
        /// beveger ballene
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Move();
                //kan bruke random for når den skal skyte
                Thread.Sleep(10); 
            }
        } 
        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x, y, w, h);
        }
        public GraphicsPath GetPath()
        {
            return myPath;
        }

    }
}
