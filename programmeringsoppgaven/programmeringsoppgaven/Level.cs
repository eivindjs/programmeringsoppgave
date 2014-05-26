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
        public int level { get; set; }
        public int minutes, seconds;
        public List<Obstacle> listObstacle { get; set; }
        public List<MovingBall> listBalls{ get; set; }
        public List<Smiley> listSmileys { get; set; }
        public List<Shooter> listShooters { get; set; }
        private MyPanel parentPanel;
        public System.Windows.Forms.Timer ballTimer;
        private Random random;
       // public int highScore { get; set; } 

        public Level(MyPanel _panel)
        {
            random = new Random();
            ballTimer = new System.Windows.Forms.Timer();
            ballTimer.Interval = random.Next(1000, 4000);
            ballTimer.Tick += new EventHandler(ballTimer_Tick);
            parentPanel = _panel;
            level = parentPanel.level;
            listBalls = new List<MovingBall>();

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
        public void InsertObstacles()
        {
            if (level == 1)
            {
                listObstacle = new List<Obstacle>();
                listObstacle.Add(new Obstacle(10, 150, 150, 90, level));
                listObstacle.Add(new Obstacle(300, 30, 90, 50, level));
                listObstacle.Add(new Obstacle(500, 50, 65, 50, level));

            }
            else if (level == 2)
            {
                listObstacle = new List<Obstacle>();
                listObstacle.Add(new Obstacle(90, 90, 120, 60, level));
                listObstacle.Add(new Obstacle(260, 60, 160, 110, level));
                listObstacle.Add(new Obstacle(500, 200, 150, 50, level));

            }
            else if (level == 3)
            {
                listObstacle = new List<Obstacle>();
                listObstacle.Add(new Obstacle(260, 60, 160, 110, level));
                listObstacle.Add(new Obstacle(560, 150, 120, 70, level));
                listObstacle.Add(new Obstacle(5, 240, 80, 70, level));
               
            }
            else if (level == 4)
            {

            }
            else if (level == 5)
            {

            }




        }
        public void InsertSmileys()
        {
            if (level == 1)
            {
                listSmileys = new List<Smiley>();
                listSmileys.Add(new Smiley(100, 100, 1));
                listSmileys.Add(new Smiley(200, 200, 1));
                listSmileys.Add(new Smiley(700, 50, 1));
                listSmileys.Add(new Smiley(600, 300, 2));
                minutes = 1;
                seconds = 10;

            }
            else if (level == 2)
            {

                listSmileys = new List<Smiley>();
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
                listSmileys = new List<Smiley>();
                listSmileys.Add(new Smiley(160, 340, 1));
                listSmileys.Add(new Smiley(40, 120, 3));
                listSmileys.Add(new Smiley(750, 360, 3));
                listSmileys.Add(new Smiley(270, 40, 2));
                listSmileys.Add(new Smiley(20, 350, 2));
                listSmileys.Add(new Smiley(630, 120, 1));
                listSmileys.Add(new Smiley(460, 310, 1));
            }
            else if (level == 4)
            {

            }
            else if (level == 5)
            {

            }

            MyPanel.smileysToCatch = listSmileys.Count();

        }

        public void InsertShooter()
        {
            if (level == 1)
            {
                //fire skyttere
                listShooters = new List<Shooter>();
                listShooters.Add(new Shooter(new Point[] { new Point(500, parentPanel.Height), new Point(540, parentPanel.Height), new Point(520, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(parentPanel.Width, 100), new Point(parentPanel.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(320, 80), new Point(360, 80), new Point(340, 110) }));
                listShooters.Add(new Shooter(new Point[] { new Point(30, 280), new Point(0, 260), new Point(0, 300) }));


            }
            else if (level == 2)
            {
                //fem skyttere
                listShooters = new List<Shooter>();
                listShooters.Add(new Shooter(new Point[] { new Point(30, 280), new Point(0, 260), new Point(0, 300) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(parentPanel.Width, 100), new Point(parentPanel.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(200, parentPanel.Height), new Point(240, parentPanel.Height), new Point(220, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(140, 90), new Point(180, 90), new Point(160, 65) }));
                listShooters.Add(new Shooter(new Point[] { new Point(540, 250), new Point(580, 250), new Point(560, 280) }));
                

            }
            else if (level == 3)
            {
                
                listShooters = new List<Shooter>();
                listShooters.Add(new Shooter(new Point[] { new Point(400, parentPanel.Height), new Point(440, parentPanel.Height), new Point(420, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(600, 340), new Point(640, 340), new Point(620, 300) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(parentPanel.Width, 100), new Point(parentPanel.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(200, parentPanel.Height), new Point(240, parentPanel.Height), new Point(220, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(600, 0), new Point(640, 0), new Point(620, 30) }));

            }
            else if (level == 4)
            {
            }
            else if (level == 5)
            {
            }

        }
        #endregion


        private void ballTimer_Tick(object sender, EventArgs e)
        {
            //ordne bare en if for hver level her
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

            }
            else if (level == 5)
            {

            }
        }
    }
}
