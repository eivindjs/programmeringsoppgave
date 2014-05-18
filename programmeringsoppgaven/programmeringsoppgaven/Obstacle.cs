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

        public Obstacle()
        {

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
                    myPath.AddLine(0, 0, 80, 0);
                    myPath.AddLine(80, 70, 0, 70);
                    myPath.CloseFigure(); //Lukk! 
                    break;
                case 2:
                    myPath.StartFigure(); //Ny figur. 
                    myPath.AddEllipse(new Rectangle(0, 0, 110, 80));
                    myPath.CloseFigure(); //Lukk! 
                    break;
                default:
                    myPath.StartFigure(); //Ny figur. 
                    myPath.AddEllipse(new Rectangle(0, 0, 110, 80));
                    myPath.CloseFigure(); //Lukk! 
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

        }

        public void Draw(Graphics g, int x, int y)
        {
            SolidBrush brush = new SolidBrush(obstacleColor);
            g.TranslateTransform(x, y);
            g.FillPath(brush, myPath);

        }

    }
}
