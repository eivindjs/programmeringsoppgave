using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectcsharp
{
    class Obstacle
    {
        private GraphicsPath myPath;
        private Object mySync;
        private Random random = new Random();
        private int manSize { get; set; }
        private Color obstacleColor;
        private int smileyX;
        private int smileyY;
        private Rectangle rect;

        public Obstacle ()
        {

        }
        public Obstacle(MyPanel parentPanel)
        {
            smileyX = random.Next(60, parentPanel.Parent.Width);
            smileyY = random.Next(60, parentPanel.Parent.Height);

            rect = new Rectangle(smileyX - 17, smileyY - 15, 25, 20);

            myPath = new GraphicsPath();
            myPath.AddRectangle(new Rectangle(smileyX - 17, smileyY - 15, 25, 20));
        }

    

        public Obstacle(int position)
        {
            myPath = new GraphicsPath();
            mySync = new Object();

            obstacleColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

            switch (position)
            {
                case 1:
                    myPath.StartFigure(); //Ny figur. 
                    myPath.AddLine(300, 300, 380, 300);
                    myPath.AddLine(380, 370, 300, 370);
                    myPath.CloseFigure(); //Lukk! 
                    break;
                case 2:
                    myPath.StartFigure(); //Ny figur. 
                    myPath.AddEllipse(new Rectangle(100, 100, 110, 80));
                    myPath.CloseFigure(); //Lukk! 
                    break;
                default:
                 
                    break;
            }
        }

        public GraphicsPath GetPath()
        {
            return myPath;
        }

        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(obstacleColor);
            g.TranslateTransform(200, 200);
            g.FillPath(brush, myPath);

            Pen blackPen = new Pen(Color.Black);

            Brush b;
            b = Brushes.Yellow;
            g.FillEllipse(b, (smileyX - 20), (smileyY - 20), 30, 30);
            b = Brushes.Black;
            //eyes
            g.FillEllipse(b, smileyX - 13, smileyY - 13, 5, 10);
            g.FillEllipse(b, smileyX, smileyY - 13, 5, 10);
            //tegner smileyn

            g.DrawArc(blackPen, rect, 20, 145);

        }

        public void Draw(Graphics g, int x, int y)
        {
            SolidBrush brush = new SolidBrush(obstacleColor);
            g.TranslateTransform(x, y);
            g.FillPath(brush, myPath);

        }

    }
}
