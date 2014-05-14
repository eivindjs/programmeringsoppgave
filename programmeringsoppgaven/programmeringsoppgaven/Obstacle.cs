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
        private Random randomPoint;

        public Obstacle()
        {
            myPath = new GraphicsPath();
            mySync = new Object();
            randomPoint = new Random();
            randomPoint.Next(0,100);

            myPath.StartFigure(); //Starter en figur 

            myPath.AddLine(randomPoint.Next(0,230), randomPoint.Next(30, 290), randomPoint.Next(2, 308), randomPoint.Next(10, 190));
            myPath.AddLine(randomPoint.Next(0, 400), randomPoint.Next(30, 350), randomPoint.Next(2, 308), randomPoint.Next(10, 190));

            myPath.CloseFigure(); //Lukker figuren

            myPath.StartFigure(); // Starter en ny figur i samme Path. 
            myPath.AddRectangle(new Rectangle(randomPoint.Next(0, 350), randomPoint.Next(0, 250), randomPoint.Next(0, 350), randomPoint.Next(0, 250)));
            myPath.CloseFigure();

        }

       
        public void Draw(Graphics g)
        {
            Pen redPen = new Pen(Color.Red, 1);
            g.DrawPath(redPen, myPath); 
        }
    }
}
