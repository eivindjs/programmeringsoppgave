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
        private GraphicsPath myPath = new GraphicsPath(); //vil ha en path for alle hindringer
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
        public Obstacle(int _x, int _y, int _width, int _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            level = MyPanel.level;
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
            else
            {
                myPath.StartFigure(); //Ny figur. 
                myPath.AddLine(x, y, x + width, y);
                myPath.AddLine(x + width, y + height, x, y + height);
                myPath.CloseFigure(); //Lukk! 
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
