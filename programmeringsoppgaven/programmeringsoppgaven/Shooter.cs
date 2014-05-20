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
       private Point[] point;
       private GraphicsPath myPath = new GraphicsPath();

       public Shooter() { }
       public Shooter(Point[] _point)
       {
           point = _point;
           myPath.AddPolygon(point);

       }
       public GraphicsPath GetPath()
       {
           return myPath;
       }
       public void Draw(Graphics g)
       {
           Brush b;
           b = Brushes.Orange;
           g.FillPolygon(b, point);
       }
    }
}
