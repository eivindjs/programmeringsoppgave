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
        /// <summary>
        /// Tord og Eivind
        /// Klasse for å lage smileys, tar inn x og y posisjon samt en int for å velge hvilken farge smileyen skal ha
        /// Inneholder også en draw metode for å tegne smileyen.
        /// </summary>
        private int smileyX { get; set; }
        private int smileyY { get; set; }
        private Rectangle rectangle;
        private GraphicsPath myPath = new GraphicsPath();
        public int brushColor { get; set; }
        public Smiley ()
        {

        }
        public Smiley(int _x, int _y, int _brushColor)
        {
            smileyX = _x;
            smileyY = _y;
            brushColor = _brushColor;
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
            if (brushColor == 1)
            {
                b = Brushes.Yellow;
                g.FillEllipse(b, (smileyX - 20), (smileyY - 20), 30, 30);
            }
            else if (brushColor == 2)
            {
                b = Brushes.Pink;
                g.FillEllipse(b, (smileyX - 20), (smileyY - 20), 30, 30);
            }
            else if (brushColor == 3)
            {
                b = Brushes.Red;
                g.FillEllipse(b, (smileyX - 20), (smileyY - 20), 30, 30);
            }
            b = Brushes.Black;
            //øyer
            g.FillEllipse(b, smileyX - 13, smileyY - 13, 5, 10);
            g.FillEllipse(b, smileyX, smileyY - 13, 5, 10);
            //tegner smileyen
            g.DrawArc(blackPen, rectangle, 20, 145);
        }
    }
}