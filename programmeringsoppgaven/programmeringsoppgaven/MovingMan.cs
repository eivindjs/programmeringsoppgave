using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using projectcsharp;

namespace projectcsharp
{
    public class MovingMan
    {
        private float speed = 1.3f;
        private int firstKeyPress = 1;
        private int size { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float DX { get; set; }
        public float DY { get; set; }

        private PictureBox superman;

        public MovingMan()
        {
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.super;
            superman.Size = new System.Drawing.Size(50, 50);
            superman.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public MovingMan(int _size)
        {
            size = _size;
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.super;
            superman.Size = new System.Drawing.Size(size, size);
            superman.SizeMode = PictureBoxSizeMode.Zoom;        
        }
   

        public void Draw(Graphics g)
        {
           
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
