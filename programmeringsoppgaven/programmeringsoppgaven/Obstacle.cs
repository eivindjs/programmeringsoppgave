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
        private MyPanel parentPanel;

        public Obstacle()
        {
            myPath = new GraphicsPath();
            mySync = new Object();
            random.Next(0, 100);

            Color obstacleColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));



            myPath.StartFigure(); // Starter en ny figur i samme Path. 
            myPath.AddRectangle(new Rectangle(random.Next(0, 350), random.Next(0, 250), random.Next(0, 350), random.Next(0, 250)));
            myPath.CloseFigure();

            myPath.StartFigure(); // Starter en ny figur i samme Path. 
            myPath.AddRectangle(new Rectangle(random.Next(0, 350), random.Next(0, 250), random.Next(0, 350), random.Next(0, 250)));
            myPath.CloseFigure();
        }

        public Obstacle(MyPanel _parentPanel, int _area)
        {
            parentPanel = _parentPanel;
            myPath = new GraphicsPath();
            mySync = new Object();
            random.Next(0, 100);
            obstacleColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));


            int area = _area;
            switch (area)
            {
                case 1:
                    myPath.StartFigure();
                    myPath.AddLine(new Point(random.Next(parentPanel.Parent.Width / 16, parentPanel.Parent.Width / 4), random.Next(parentPanel.Parent.Height / 16, parentPanel.Parent.Height / 4)),
                                   new Point(random.Next(parentPanel.Parent.Width / 4, parentPanel.Parent.Width / 2), random.Next(parentPanel.Parent.Height / 4, parentPanel.Parent.Height / 2)));

                    myPath.AddLine(new Point(random.Next(parentPanel.Width / 16, parentPanel.Width / 4), random.Next(parentPanel.Height / 16, parentPanel.Height / 4)),
                                    new Point(random.Next(parentPanel.Width / 4, parentPanel.Width / 2), random.Next(parentPanel.Height / 4, parentPanel.Height / 2)));
                    myPath.CloseFigure();

                    break;

                case 2:

                    myPath.StartFigure(); // Starter en ny figur i samme Path. 
                    myPath.AddRectangle(new Rectangle(random.Next(350, 600), random.Next(300, 500), random.Next(200, 350), random.Next(190, 700)));
                    myPath.CloseFigure(); break;
                case 3:

                    myPath.StartFigure(); // Starter en ny figur i samme Path. 
                    myPath.AddRectangle(new Rectangle(random.Next(0, 350), random.Next(0, 250), random.Next(0, 350), random.Next(0, 250)));
                    myPath.CloseFigure(); break;
                case 4:

                    myPath.StartFigure(); // Starter en ny figur i samme Path. 
                    myPath.AddRectangle(new Rectangle(random.Next(0, 350), random.Next(0, 250), random.Next(0, 350), random.Next(0, 250)));
                    myPath.CloseFigure(); break;
                default:

                    myPath.StartFigure(); // Starter en ny figur i samme Path. 
                    myPath.AddRectangle(new Rectangle(random.Next(0, 350), random.Next(0, 250), random.Next(0, 350), random.Next(0, 250)));
                    myPath.CloseFigure(); break;
            }

        }




        public GraphicsPath GetPath()
        {
            return myPath;
        }

        public void Draw(Graphics g)
        {
            SolidBrush redBrush = new SolidBrush(obstacleColor);

            //Pen redPen = new Pen(Color.Red, 1);

            g.FillPath(redBrush, myPath);

            // g.FillPath(redBrush,manPath);
        }




    }
}
