using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectcsharp
{
    /// <summary>
    /// En klasse for ballene som skal skytes.
    /// </summary>
    public class MovinBall 
    {
        private int x, y, h, w; //variabler for plassering og størrelse av ballene
        private GraphicsPath myPath = new GraphicsPath();

        public MovinBall(int x, int y, int h, int w)
        {
            this.x = x;
            this.y = y;
            this.h = h;
            this.w = w;
        }
        /// <summary>
        /// Metode for hvordan ballene skal beveges i forhold til skytterne
        /// </summary>
        public void Move()
        {

        }
        /// <summary>
        /// Tegner ballene
        /// </summary>
        
        public void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x, y, w, h);
        }
        public GraphicsPath GetPath()
        {
            return myPath;
        }

    }
}
