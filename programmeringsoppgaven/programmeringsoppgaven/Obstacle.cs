using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectcsharp
{
    public class Obstacle
    {
        /// <summary>
        /// Tord og Eivind
        /// Klasse for å lage hindringer
        /// </summary>
        private GraphicsPath myPath = new GraphicsPath(); //vil ha en path for alle hindringer(Sjekke kollisjon)
        private Object mySync = new Object();
        private Random random = new Random();
        private Color obstacleColor;
        private int x { get; set; }
        private int y { get; set; }
        private int width { get; set; }
        private int height { get; set; }
        private int level;

        public Obstacle()
        {           
        }
        public Obstacle(int _x, int _y, int _width, int _height, int _level)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            level = _level;
            obstacleColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            if (level < 3)
            {
                myPath.StartFigure(); //Ny figur. 
                myPath.AddLine(x, y, x + width, y);
                myPath.AddLine(x + width, y + height, x, y + height);
                myPath.CloseFigure(); //Lukk! 
              

                myPath.StartFigure(); //Ny figur. 
                myPath.AddEllipse(new Rectangle(x, y + 150, width, height));
                myPath.CloseFigure(); //Lukk! 
            }
            else if(level == 3) //level 3
            {
                myPath.StartFigure(); //Ny figur. 
                myPath.AddLine(x, y, x + width, y);
                myPath.AddLine(x + width, y + height, x, y + height);
                myPath.CloseFigure(); //Lukk! 

                Point[] points = { new Point(60, 80),
                    new Point(70, 90),
                    new Point(50, 110)};

         
                myPath.StartFigure(); //Fancy figur
                myPath.AddArc(175, 50, 50, 50, 0, -180);
                myPath.AddLine(100, 0, 250, 20);
                myPath.AddLine(250, 20, 225, 75);
                myPath.CloseFigure();

                myPath.StartFigure(); // Ny figur
                myPath.AddLine(60, 60, 5, 90);
                myPath.AddCurve(points, 3);
                myPath.AddLine(60, 150, 150, 180);
                myPath.CloseFigure();

                Point[] poin = { new Point(x, y + width + height), new Point(x + y, y + width + height), new Point(x + 30 , y+ height + y) };
                myPath.StartFigure();
                myPath.AddPolygon(poin);
                myPath.CloseFigure();
            }
            else //level 4 og 5 
            {
                myPath.StartFigure(); //Ny figur. 
                myPath.AddLine(x, y, x + width, y);
                myPath.AddLine(x + width, y + height, x, y + height);
                myPath.CloseFigure(); //Lukk! 


                Point[] poin = { new Point(x, y), new Point(x + 50, y), new Point(x + 30, y - 30) };
                myPath.StartFigure();
                myPath.AddPolygon(poin);
                myPath.CloseFigure();

                myPath.StartFigure();
                myPath.AddArc(x + width, y , width, height, 0, 180);
                myPath.AddLine(x + width, y, x, y - 40);
                myPath.AddLine(x, y - 40, x + width, y - 30);
                myPath.CloseFigure();

            }
          
        }

        public GraphicsPath GetPath()
        {
            return myPath;
        }

        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(obstacleColor);
            g.FillPath(brush, myPath);
        }

    }
}
