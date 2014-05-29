using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectcsharp
{
   public class Shooter 
   {
       private Point[] point; //Punkt
       private GraphicsPath myPath = new GraphicsPath(); //path for kollisjonsdeteksjon

       /// <summary>
       /// Eivind
       /// Klasse for skytterne, tar inn point array som inneholder 3 point objekter for posisjonen den skal stå. Inneholder også en
       /// draw metode for å tegne skytterene
       /// </summary>
       /// <param name="_point">punkt/plassering(point[]{new Point(x,y),new Point(x,y),new Point(x,y),};)</param>
       public Shooter(Point[] _point)
       {
           point = _point;
           myPath.AddPolygon(point);

       }
       public GraphicsPath GetPath()
       {
           return myPath;
       }
       //Tegner skytterene
       public void Draw(Graphics g)
       {
           Brush b;
           b = Brushes.Orange;
           g.FillPolygon(b, point);
       }
    }
}
