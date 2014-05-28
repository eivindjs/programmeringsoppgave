using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using projectcsharp;
using System.Drawing.Drawing2D;

namespace projectcsharp
{
    public class MovingMan
    {
        private float speed = 1.3f;
        private int firstKeyPress = 1;
        private int manSize = 30;
        private int size { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float DX { get; set; }
        public float DY { get; set; }

        private PictureBox superman;
        private GraphicsPath supermanPath;


        public MovingMan()
        {
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.super;
            superman.Size = new System.Drawing.Size(manSize, manSize);
            superman.SizeMode = PictureBoxSizeMode.Zoom;
            superman.Location = new Point((int)X, (int)Y);
            supermanPath = new GraphicsPath();
        }
        public PictureBox GetPictureBox()
        {
            return superman;
        }

        public void SetLocation()
        {
            superman.Location = new Point((int)X, (int)Y);
        }

        public GraphicsPath GetPath()
        {
            supermanPath.Reset();
            supermanPath.StartFigure();
            supermanPath.AddRectangle(new Rectangle((int)X, (int)Y, (int)manSize, (int)manSize));
            supermanPath.CloseFigure();

            return supermanPath;
        }

        public void MoveRight()
        {
            this.X += DX;
        }

        public void MoveLeft()
        {
            this.X -= this.DX;
        }

        public void MoveUp()
        {
            if(firstKeyPress == 1)
            {
                speed = 1;
                firstKeyPress++;
            }
            speed = speed * 1.03f;

            this.Y -= this.DY * speed;
        }

        public void MoveDown()
        {

            firstKeyPress = 1;
            speed = speed * 1.03f;
            this.Y += this.DY * speed;
            
        }

        public void Drop()
        {
            MoveDown();
        }

    }
}
