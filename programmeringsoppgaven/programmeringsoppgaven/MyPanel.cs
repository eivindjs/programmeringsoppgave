using projectcharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectcsharp;

namespace projectcsharp
{
    public partial class MyPanel : Panel
    {
        private List<Ball> listBall = new List<Ball>();

        public MyPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint,
             true);
            this.UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (Ball ball in listBall)
            {
                ball.draw(e.Graphics);
            }
        }

        public void AddBall()
        {

            listBall.Add(new Ball(this));

        }
    }
}
