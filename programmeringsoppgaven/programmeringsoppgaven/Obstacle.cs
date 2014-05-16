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
        private Random randomPoint = new Random();
        private int manSize { get; set; }

        public Obstacle()
        {
            myPath = new GraphicsPath();
            mySync = new Object();
            randomPoint.Next(0, 100);
            
          
            myPath.StartFigure(); // Starter en ny figur i samme Path. 
            myPath.AddRectangle(new Rectangle(randomPoint.Next(0, 350), randomPoint.Next(0, 250), randomPoint.Next(0, 350), randomPoint.Next(0, 250)));
            myPath.CloseFigure();

            myPath.StartFigure(); // Starter en ny figur i samme Path. 
            myPath.AddRectangle(new Rectangle(randomPoint.Next(0, 350), randomPoint.Next(0, 250), randomPoint.Next(0, 350), randomPoint.Next(0, 250)));
            myPath.CloseFigure();
        }

        public GraphicsPath GetPath()
        {
            return myPath;
        }
  
        public void Draw(Graphics g)
        {
            SolidBrush redBrush = new SolidBrush(Color.Green);

            //Pen redPen = new Pen(Color.Red, 1);

            g.FillPath(redBrush, myPath);

           // g.FillPath(redBrush,manPath);
        }




    }
}
