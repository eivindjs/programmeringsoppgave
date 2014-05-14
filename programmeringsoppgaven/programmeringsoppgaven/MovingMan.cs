using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using projectcsharp;

namespace projectcsharp
{
    class MovingMan
    {
        private float speed = 1.3f;
        private int firstKeyPress = 1;

        public float X { get; set; }
        public float Y { get; set; }
        public float DX { get; set; }
        public float DY { get; set; }
   

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
