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
        public int x { get; set; }
        public int y { get; set; }
        private int direction; //variabler for plassering og retning
        public int h { get; set; }
        public int w { get; set; }
        private int ballSpeed;
        private GraphicsPath myPath;

        private System.Windows.Forms.Timer moveBallTimer;

        public MovingBall()
        {

        }

        public MovingBall(int x, int y, int direction)
        {
            Difficulty(User.Difficulty_level);

            w = h = 7;
            moveBallTimer = new System.Windows.Forms.Timer();
            moveBallTimer.Interval = 17;
            moveBallTimer.Tick += new EventHandler(MoveBallTimer_Tick);
            this.x = x;
            this.y = y;
            myPath = new GraphicsPath();
            myPath.StartFigure();
            myPath.AddEllipse(x, y, w, h);
            myPath.CloseFigure();
            this.direction = direction;
            moveBallTimer.Start();
        }
        public void Difficulty(int grade)
        {
            switch (grade)
            {
                case 1: ballSpeed = 1;
                    break;
                case 2: ballSpeed = 2;
                    break;
                case 3: ballSpeed = 3;
                    break;
            }
        }
        private void MoveBallTimer_Tick(object sender, EventArgs e)
        {
            Move();
        }
        /// <summary>
        /// Metode for hvordan ballene skal beveges i forhold til skytterne
        /// </summary>
        public void Move()
        {
            //finner ut sånn at ballene skyter rett

            if (direction == 1)
            {
                y -= ballSpeed;
            }
            else if (direction == 2)
            {
                x += ballSpeed;
            }
            else if (direction == 3)
            {
                x -= ballSpeed;
            }
            else if (direction == 4)
            {
                y += ballSpeed;
            }
            else if (direction == 5)
            {
                x -= y;
                
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
