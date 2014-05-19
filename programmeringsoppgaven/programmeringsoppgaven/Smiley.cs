using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectcsharp
{
    public class Smiley
    {
        private int smileyX { get; set; }
        private int smileyY { get; set; }
        private Rectangle rectangle;
        private GraphicsPath myPath = new GraphicsPath();

        public Smiley ()
        {

        }
        public Smiley(int _x, int _y)
        {
            smileyX = _x;
            smileyY = _y;
            rectangle = new Rectangle(smileyX - 17, smileyY - 15, 25, 20);   
            myPath.AddRectangle(rectangle);
        }

        public GraphicsPath GetPath()
        {
            return myPath;
        }

        public void Draw(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black);
            Brush b;
            b = Brushes.Yellow;
            g.FillEllipse(b, (smileyX - 20), (smileyY - 20), 30, 30);
            b = Brushes.Black;
            //øyer
            g.FillEllipse(b, smileyX - 13, smileyY - 13, 5, 10);
            g.FillEllipse(b, smileyX, smileyY - 13, 5, 10);
            //tegner smileyen
            g.DrawArc(blackPen, rectangle, 20, 145);
        }
    }
}