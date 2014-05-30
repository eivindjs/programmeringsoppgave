using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectcsharp
{
    public class Level
    {
        /// <summary>
        /// Tord og Eivind
        /// Level.cs
        /// Her opprettes hver level som et objekt.
        /// 
        /// </summary>
        public int level { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public List<Obstacle> listObstacle { get; set; }
        public List<MovingBall> listBalls{ get; set; }
        public List<Smiley> listSmileys { get; set; }
        public List<Shooter> listShooters { get; set; }
        private MyPanel parentPanel;
        public System.Windows.Forms.Timer ballTimer;
        private Random random;

        public Level(MyPanel _panel)
        {
            random = new Random();
            ballTimer = new System.Windows.Forms.Timer();
            ballTimer.Interval = random.Next(2000, 3000);
            ballTimer.Tick += new EventHandler(ballTimer_Tick);
            parentPanel = _panel;
            level = parentPanel.level;
            listBalls = new List<MovingBall>();
            listObstacle = new List<Obstacle>();
            listSmileys = new List<Smiley>();
            listShooters = new List<Shooter>();

            listBalls.Clear();
            InsertSmileys();
            InsertObstacles();
            InsertShooter(); 
        }
   
        public void ClearBalls()
        {
            listBalls.Clear();
        }
        public void StartBallTimer()
        {
            ballTimer.Start();

        }

        public void StopTimer()
        {
            ballTimer.Stop();

        }
        public void AddScore(int i)
        {
            if (listSmileys[i].brushColor == 1)
            {
               parentPanel.highScore += 50;
            }
            else if (listSmileys[i].brushColor == 2)
            {
                parentPanel.highScore += 100;
            }
            else if (listSmileys[i].brushColor == 3)
            {
                parentPanel.highScore += 150;
            }

            listSmileys.RemoveAt(i);
        }

        #region Insert Objects
        /// <summary>
        /// Metode for å sette inn figurerer med absolutte x,y,w,h verdier
        /// </summary>
        public void InsertObstacles()
        {
            if (level == 1)
            {
                listObstacle.Add(new Obstacle(10, 150, 150, 90, level));
                listObstacle.Add(new Obstacle(300, 30, 90, 50, level));
                listObstacle.Add(new Obstacle(500, 50, 65, 50, level));

            }
            else if (level == 2)
            {
                listObstacle.Add(new Obstacle(90, 90, 120, 60, level));
                listObstacle.Add(new Obstacle(260, 60, 160, 110, level));
                listObstacle.Add(new Obstacle(500, 200, 150, 50, level));

            }
            else if (level == 3)
            {
                listObstacle.Add(new Obstacle(260, 60, 160, 110, level));
                listObstacle.Add(new Obstacle(560, 150, 120, 70, level));
                listObstacle.Add(new Obstacle(5, 240, 80, 70, level));
               
            }
            else if (level == 4)
            {
                listObstacle.Add(new Obstacle(350, 260, 200, 30, level));
                listObstacle.Add(new Obstacle(260, 120, 40, 120, level));
                listObstacle.Add(new Obstacle(50, 300, 60, 40, level));
                listObstacle.Add(new Obstacle(630, 60, 160, 70, level));
                listObstacle.Add(new Obstacle(30, 90, 30, 120, level));
                listObstacle.Add(new Obstacle(410, 60, 60, 50, level));
            }
            else if (level == 5)
            {
                listObstacle.Add(new Obstacle(530, 100, 160, 170, level));
                listObstacle.Add(new Obstacle(140, 80, 100, 30, level));
                listObstacle.Add(new Obstacle(340, 360, 120, 30, level));
                listObstacle.Add(new Obstacle(40, 340, 140, 200, level));
                listObstacle.Add(new Obstacle(240, 170, 10, 100, level));
                listObstacle.Add(new Obstacle(0, 150, 40, 30, level));
                listObstacle.Add(new Obstacle(420, 130, 20, 40, level));
            }
        }
        /// <summary>
        /// Metode for å sette inn smileys med x,y og en int for valg av farge på smiley
        /// </summary>
        public void InsertSmileys()
        {
            if (level == 1)
            {
                listSmileys.Add(new Smiley(100, 100, 1));
                listSmileys.Add(new Smiley(200, 200, 1));
                listSmileys.Add(new Smiley(700, 50, 1));
                listSmileys.Add(new Smiley(600, 300, 2));
                minutes = 1;
                seconds = 10;

            }
            else if (level == 2)
            {

                listSmileys.Add(new Smiley(60, 70, 1));
                listSmileys.Add(new Smiley(160, 340, 1));
                listSmileys.Add(new Smiley(700, 250, 1));
                listSmileys.Add(new Smiley(350, 50, 2));
                listSmileys.Add(new Smiley(550, 190, 3));
                minutes = 0;
                seconds = 50;
            }
            else if (level == 3)
            {
                listSmileys.Add(new Smiley(160, 340, 1));
                listSmileys.Add(new Smiley(40, 120, 3));
                listSmileys.Add(new Smiley(750, 360, 3));
                listSmileys.Add(new Smiley(270, 40, 2));
                listSmileys.Add(new Smiley(20, 350, 2));
                listSmileys.Add(new Smiley(630, 120, 1));
                listSmileys.Add(new Smiley(460, 310, 1));
                minutes = 0;
                seconds = 45;
            }
            else if (level == 4)
            {
                listSmileys.Add(new Smiley(460, 310, 1));
                listSmileys.Add(new Smiley(140, 40, 1));
                listSmileys.Add(new Smiley(40, 250, 2));
                listSmileys.Add(new Smiley(640, 360, 3));
                listSmileys.Add(new Smiley(510, 40, 3));
                listSmileys.Add(new Smiley(740, 260, 2));
                listSmileys.Add(new Smiley(100, 360, 1));
                listSmileys.Add(new Smiley(380, 200, 3));

                minutes = 0;
                seconds = 40;
            }
            else if (level == 5)
            {
                listSmileys.Add(new Smiley(380, 200, 3));
                listSmileys.Add(new Smiley(30, 350, 2));
                listSmileys.Add(new Smiley(25, 200, 2));
                listSmileys.Add(new Smiley(750, 90, 3));
                listSmileys.Add(new Smiley(740, 360, 2));
                listSmileys.Add(new Smiley(620, 340, 2));
                listSmileys.Add(new Smiley(290, 50, 2));
                listSmileys.Add(new Smiley(230, 150, 2));
                listSmileys.Add(new Smiley(510, 140, 1));
                minutes = 0;
                seconds = 30;
            }
            else if (level == 6) //Bonus-level
            { //øverst
                listSmileys.Add(new Smiley(384, 40, 2));
                listSmileys.Add(new Smiley(384, 360, 2));
                listSmileys.Add(new Smiley(192, 180, 2));
                listSmileys.Add(new Smiley(576, 180, 2));
                listSmileys.Add(new Smiley(205, 140, 2));
                listSmileys.Add(new Smiley(560, 140, 2));
                listSmileys.Add(new Smiley(540, 100, 2));
                listSmileys.Add(new Smiley(510, 70, 2));
                listSmileys.Add(new Smiley(470, 50, 2));
                listSmileys.Add(new Smiley(430, 42, 2));
                listSmileys.Add(new Smiley(340, 45, 2));
                listSmileys.Add(new Smiley(300, 55, 2));
                listSmileys.Add(new Smiley(260, 75, 2));
                listSmileys.Add(new Smiley(230, 100, 2));

                //nederst
                listSmileys.Add(new Smiley(200, 225, 2));
                listSmileys.Add(new Smiley(565, 225, 2));
                listSmileys.Add(new Smiley(540, 260, 2));
                listSmileys.Add(new Smiley(510, 290, 2));
                listSmileys.Add(new Smiley(470, 320, 2));
                listSmileys.Add(new Smiley(430, 342, 2));
                listSmileys.Add(new Smiley(340, 354, 2));
                listSmileys.Add(new Smiley(300, 345, 2));
                listSmileys.Add(new Smiley(260, 325, 2));
                listSmileys.Add(new Smiley(230, 300, 2));
                listSmileys.Add(new Smiley(210, 260, 2)); 

                //øyne
                listSmileys.Add(new Smiley(288, 140, 1));
                listSmileys.Add(new Smiley(477, 140, 1)); 

                //munn
                listSmileys.Add(new Smiley(420, 252, 3));
                listSmileys.Add(new Smiley(340, 258, 3));
                listSmileys.Add(new Smiley(300, 245, 3));
                listSmileys.Add(new Smiley(460, 235, 3));
                listSmileys.Add(new Smiley(380, 255, 3));

                seconds = 7;
            }

        }
        /// <summary>
        /// Metode for å sette inn skyttere
        /// </summary>
        public void InsertShooter()
        {
            if (level == 1)
            {
                //fire skyttere
                listShooters.Add(new Shooter(new Point[] { new Point(500, parentPanel.Height), new Point(540, parentPanel.Height), new Point(520, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(parentPanel.Width, 100), new Point(parentPanel.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(320, 80), new Point(360, 80), new Point(340, 110) }));
                listShooters.Add(new Shooter(new Point[] { new Point(30, 280), new Point(0, 260), new Point(0, 300) }));
            }
            else if (level == 2)
            {
                //fem skyttere
                listShooters.Add(new Shooter(new Point[] { new Point(30, 280), new Point(0, 260), new Point(0, 300) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(parentPanel.Width, 100), new Point(parentPanel.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(200, parentPanel.Height), new Point(240, parentPanel.Height), new Point(220, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(140, 90), new Point(180, 90), new Point(160, 65) }));
                listShooters.Add(new Shooter(new Point[] { new Point(540, 250), new Point(580, 250), new Point(560, 280) }));             
            }
            else if (level == 3)
            {
                
                listShooters.Add(new Shooter(new Point[] { new Point(400, parentPanel.Height), new Point(440, parentPanel.Height), new Point(420, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(600, 340), new Point(640, 340), new Point(620, 300) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(parentPanel.Width, 100), new Point(parentPanel.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(200, parentPanel.Height), new Point(240, parentPanel.Height), new Point(220, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(600, 0), new Point(640, 0), new Point(620, 30) }));

            }
            else if (level == 4)
            {
                listShooters.Add(new Shooter(new Point[] { new Point(130, 290), new Point(160, 320), new Point(165, 280) }));
                listShooters.Add(new Shooter(new Point[] { new Point(400, parentPanel.Height), new Point(440, parentPanel.Height), new Point(420, 355) }));
                listShooters.Add(new Shooter(new Point[] { new Point(260, 130), new Point(260, 165), new Point(230, 147) }));
                listShooters.Add(new Shooter(new Point[] { new Point(640, 130), new Point(680, 130), new Point(660, 155) }));
                listShooters.Add(new Shooter(new Point[] { new Point(420, 110), new Point(460, 110), new Point(440, 140) }));
            }
            else if (level == 5)
            {
                listShooters.Add(new Shooter(new Point[] { new Point(240, 180), new Point(240, 220), new Point(205, 200) }));
                listShooters.Add(new Shooter(new Point[] { new Point(280, parentPanel.Height), new Point(320, parentPanel.Height), new Point(300, 355) }));
                listShooters.Add(new Shooter(new Point[] { new Point(540, 200), new Point(540, 250), new Point(500, 225) }));
                listShooters.Add(new Shooter(new Point[] { new Point(420, 0), new Point(460, 0), new Point(440, 30) }));
                listShooters.Add(new Shooter(new Point[] { new Point(0, 60), new Point(0, 100), new Point(30, 80) }));
            }
        }
       

        /// <summary>
        /// Timer tick metode for å sette inn baller som skal skytes fra en viss posisjon.
        /// Timeren ordner for når den skal skyte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ballTimer_Tick(object sender, EventArgs e)
        {
            if (level == 1)
            {
                listBalls.Add(new MovingBall(20, 277, 2));
                listBalls.Add(new MovingBall(517, 340, 1));
                listBalls.Add(new MovingBall(730, 117, 3));
                listBalls.Add(new MovingBall(337, 100, 4));
            }
            else if (level == 2)
            {
                listBalls.Add(new MovingBall(730, 117, 3));
                listBalls.Add(new MovingBall(30, 276, 2));
                listBalls.Add(new MovingBall(216, 340, 1));
                listBalls.Add(new MovingBall(157, 55, 1));
                listBalls.Add(new MovingBall(556, 270, 4));
            }
            else if (level == 3)
            {
                listBalls.Add(new MovingBall(730, 117, 3));
                listBalls.Add(new MovingBall(217, 340, 1));
                listBalls.Add(new MovingBall(617, 20, 4));
                listBalls.Add(new MovingBall(617, 290, 1));
                listBalls.Add(new MovingBall(417, 340, 1));
            }
            else if (level == 4)
            {
                listBalls.Add(new MovingBall(230, 145, 3));
                listBalls.Add(new MovingBall(165, 280, 5));
                listBalls.Add(new MovingBall(417, 355, 1));
                listBalls.Add(new MovingBall(437, 140, 4));
                listBalls.Add(new MovingBall(657, 155, 4));
            }
            else if (level == 5)
            {
                listBalls.Add(new MovingBall(30, 77, 2));
                listBalls.Add(new MovingBall(437, 30, 4));
                listBalls.Add(new MovingBall(500, 222, 3));
                listBalls.Add(new MovingBall(297, 355, 1));
                listBalls.Add(new MovingBall(205, 197, 3));
            }
        }
        #endregion

        /// <summary>
        /// Metode som tegner aller figurer,smileys, skyttere og baller
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            for (int i = 0; i < listSmileys.Count; i++) 
            {
                listSmileys[i].Draw(g);          
            }

            for (int i = 0; i < listShooters.Count; i++)
            {
                listShooters[i].Draw(g);
            }

            for (int i = 0; i < listObstacle.Count; i++)
            {
                listObstacle[i].Draw(g);      
            }

            for (int i = 0; i < listBalls.Count; i++)
            {
                listBalls[i].Draw(g);
            }
        }
    }
}
