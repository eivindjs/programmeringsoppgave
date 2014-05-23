using projectcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectcsharp
{
    /// <summary>
    /// Her skjer magien.
    /// </summary>
    public partial class MyPanel : Panel
    {
        #region Private medlemsvariabler
        private ThreadStart ts;
        private Thread thread;
        private MovingMan movingMan;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer ballTimer;
        private PictureBox superman;
        private Random random;
        private int manSize;
        private List<Obstacle> listObstacle;
        private List<MovinBall> listBalls = new List<MovinBall>();
        private List<Smiley> listSmileys;
        private List<Shooter> listShooters;
        public static Object mySync = new Object();
        private Label lblTime, lblScore, lblLevel;
        private DBConnect db = new DBConnect();
        private int smileysToCatch = 1;
        #endregion

        public int level { get; set; }
        public int seconds { get; set; }
        public int minutes { get; set; }
        public bool playSound { get; set; }
        public bool running { get; set; }
        public int highScore { get; set; }
       
        /// <summary>
        /// Konstruktøren. Her instansieres viktige objekter som skal være tilgjengelig ved oppstart.
        /// </summary>
        public MyPanel()
        {
            level = 1;
            this.SetStyle(ControlStyles.DoubleBuffer |
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint,
           true);
            this.UpdateStyles();
            lblTime = new Label();
            lblScore = new Label();
            lblLevel = new Label();
            lblTime.Location = new Point(300, 0);
            lblScore.Location = new Point(400, 0);
            lblLevel.Location = new Point(240, 0);
            this.Controls.Add(lblTime);
            this.Controls.Add(lblScore);
            this.Controls.Add(lblLevel);
            manSize = 30;
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.super;
            superman.Size = new System.Drawing.Size(manSize, manSize);
            superman.SizeMode = PictureBoxSizeMode.Zoom;
            
            this.Controls.Add(superman); //legger pictureBox til panelet

            this.Controls.Add(superman);

            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);

            random = new Random();
            ballTimer = new System.Windows.Forms.Timer();
            ballTimer.Interval = random.Next(1000, 4000);
            ballTimer.Tick += new EventHandler(ballTimer_Tick);

        }
        public void Restart()
        {
            lock (mySync)
            {
                listBalls.Clear();
                InsertSmileys();
                InsertObstacles();
                InsertShooter();
                movingMan = new MovingMan //setter verdiene til MovingMan tilbake vha properties
                {
                    X = 10f,
                    Y = 10f,
                    DX = 4f,
                    DY = 3f,
                };

                superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);
                running = true;
                timer.Start();
                startAnimation();
            }
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

            }
            else if (level == 4)
            {

                lblLevel.Text = "Level 4";
            }
            else if (level == 5)
            {

                lblLevel.Text = "Level 5";
            }

            smileysToCatch = listSmileys.Count();

        }

        public void InsertShooter()
        {
            if (level == 1)
            {
                //fire skyttere
                listShooters = new List<Shooter>();
                listShooters.Add(new Shooter(new Point[] { new Point(500, this.Height), new Point(540, this.Height), new Point(520, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(this.Width, 100), new Point(this.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(320, 80), new Point(360, 80), new Point(340, 110) }));
                listShooters.Add(new Shooter(new Point[] { new Point(30, 280), new Point(0, 260), new Point(0, 300) }));

                
            }
            else if (level == 2)
            {
                //fem skyttere
                listShooters = new List<Shooter>();
                listShooters.Add(new Shooter(new Point[] { new Point(30, 280), new Point(0, 260), new Point(0, 300) }));
                listShooters.Add(new Shooter(new Point[] { new Point(730, 120), new Point(this.Width, 100), new Point(this.Width, 140) }));
                listShooters.Add(new Shooter(new Point[] { new Point(200, this.Height), new Point(240, this.Height), new Point(220, 350) }));
                listShooters.Add(new Shooter(new Point[] { new Point(140, 90), new Point(180, 90), new Point(160, 65) }));
                listShooters.Add(new Shooter(new Point[] { new Point(540, 250), new Point(580, 250), new Point(560, 280) }));


            }
            else if (level == 3)
            {
                //seks skyttere
            }
            else if (level == 4)
            {
                //sju
            }
            else if (level == 5)
            {
                //åtte
            }

        }
        #endregion

        #region Tråd- og timer-håndtering

        

        public void UpdateGraphics()
        {
            while (running)
            {
                Thread.Sleep(17); //å la tråden sove i 17 ms er optimalt for å oppnå en framerate på ca 60 FPS

                this.Invalidate(); //kaller på OnPaint()
            }
        }

        private void startAnimation()
        {
            ts = new ThreadStart(UpdateGraphics);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
            ballTimer.Start();
        }
        /// <summary>
        /// Timer for ballene, som skytes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ballTimer_Tick(object sender, EventArgs e)
        {
            //ordne bare en if for hver level her
            if (level == 1)
            {
                listBalls.Add(new MovinBall(10, 280, 2));
                listBalls.Add(new MovinBall(520, 340, 1));
                listBalls.Add(new MovinBall(this.Width, 120, 3));
                listBalls.Add(new MovinBall(340, 100, 4));
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            lock (mySync)
            {
                var left = KeyEvent.GetKeyState(Keys.Left);
                var right = KeyEvent.GetKeyState(Keys.Right);
                var up = KeyEvent.GetKeyState(Keys.Up);
                var down = KeyEvent.GetKeyState(Keys.Down);

                if (movingMan.Y < (this.Height - 30))
                {
                    if (left.IsPressed)
                    {
                        movingMan.MoveLeft();
                    }

                    if (right.IsPressed)
                    {
                        movingMan.MoveRight();
                    }

                    if (up.IsPressed)
                    {
                        movingMan.MoveUp();
                    }

                    if (down.IsPressed)
                    {
                        movingMan.MoveDown();
                    }
                    else
                    {
                        if (movingMan.X != 10f && !up.IsPressed)
                        {
                            movingMan.Drop();
                        }
                    }
                }
                else
                {
                    running = false;
                    timer.Enabled = false;
                    timer.Stop();
                    ballTimer.Stop();


                    Insert(highScore);

                    MessageBox.Show("Du tapte! Prøv igjen.");

                    level = 1;
                    highScore = 0;

                }
            }
        }

    

        public void ShowMessageBox()
        {
            lock (mySync)
            {

                if (smileysToCatch == 0)
                {
                    MessageBox.Show("Du klarte det! Trykk start for neste brett.");

                }
                else
                    MessageBox.Show("Du tapte! Trykk start for nytt spill.");
            }
        }

        #endregion
        /// <summary>
        /// Sjekker kollisjon for alle typer graphicsPath. GraphicsPath a og b danner hver sin Region. Har de kontakt med hverandre, vil metoden returnere true. Ellers false.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool CheckCollision(GraphicsPath a, GraphicsPath b, PaintEventArgs e)
        {
            Region obstacleRegion = new Region(a);
            Region supermanRegion = new Region(b);
            obstacleRegion.Intersect(supermanRegion);

            if (!obstacleRegion.IsEmpty(e.Graphics)) //Kollisjon dersom snittet ikke er tomt. 
            {
                return true;
            }
            else
                return false;
        }
        #region OnPaint
        /// <summary>
        /// Kjøres ved this.Invalidate();
        /// Viktigste klassen i programmet mtp. kollisjonsdeteksjon. MovingMan sin picture box blir lagt til en GraphicsPath,
        /// som igjen blir lagt til en region som for hver hindring (Obstacle) sjekker om de berører hverandre. Da stopper spillet.
        /// Her tegnes også alt opp for hver kjøring (hvert 17. ms i tråden). Smileys, Obstacles, startplattform, skytere
        /// med dens kuler, og MovingMan tegnes.
        /// </summary>
        /// <param name="e"></param>
        /// 
        protected override void OnPaint(PaintEventArgs e)
        {
            lock (mySync)
            {
                if (this.movingMan != null)
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    base.OnPaint(e);

                    superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);

                    GraphicsPath supermanPath = new GraphicsPath();
                    supermanPath.StartFigure(); // Starter en ny figur i samme Path. 
                    supermanPath.AddRectangle(new Rectangle((int)movingMan.X, (int)movingMan.Y, (int)manSize, (int)manSize));
                    supermanPath.CloseFigure();

                    e.Graphics.DrawLine(new Pen(Color.Green), new Point(0, 40), new Point(40, 40)); //plattformen ved start

                    for (int i = 0; i < listSmileys.Count; i++) //tegn alle smileys
                    {
                        Smiley smiley = listSmileys[i];
                        smiley.Draw(e.Graphics);
                        if (CheckCollision(smiley.GetPath(), supermanPath, e))
                        {
                            if (listSmileys[i].brushColor == 1)
                            {
                                highScore += 50;
                            }
                            else if (listSmileys[i].brushColor == 2)
                            {
                                highScore += 100;
                            }
                            else if (listSmileys[i].brushColor == 3)
                            {
                                highScore += 150;
                            }

                            listSmileys.RemoveAt(i);


                            playSound = true;

                            smileysToCatch--;

                            if (smileysToCatch == 0)
                            {
                                running = false;
                                timer.Enabled = false;
                                timer.Stop();
                                level++;

                                ShowMessageBox();
                            }
                        }
                    }
                    for (int i = 0; i < listShooters.Count; i++)
                    {
                        Shooter shooter = listShooters[i];
                        shooter.Draw(e.Graphics);

                        if (CheckCollision(shooter.GetPath(), supermanPath, e))
                        {
                            running = false;
                            timer.Enabled = false;
                            timer.Stop();
                            ballTimer.Stop();
                            Insert(highScore);


                            ShowMessageBox();
                                Restart();
                                level = 1;
                                highScore = 0;
                                seconds = 10;
                                minutes = 1;
                          
                        }
                        superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);

                    }
                    for (int i = 0; i < listBalls.Count; i++)
                    {
                        MovinBall ball = listBalls[i];

                        ball.Draw(e.Graphics);
                        if (CheckCollision(ball.GetPath(), supermanPath, e))
                        {

                            ShowMessageBox();

                                level = 1;
                                highScore = 0;
                                seconds = 10;
                                minutes = 1;            
                        }
                    }
                    for (int i = 0; i < listObstacle.Count; i++)
                    {
                        Obstacle obstacle1 = listObstacle[i];

                        obstacle1.Draw(e.Graphics);

                        if (CheckCollision(obstacle1.GetPath(), supermanPath, e))
                        {
                            running = false;
                            timer.Enabled = false;
                            timer.Stop();
                            ballTimer.Stop();

                            Insert(highScore);

                            ShowMessageBox();
                                
                            level = 1;                                                    
                        }
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// Metode for å sette inn data i databasen
        /// </summary>
        /// <param name="sql">sql spørring</param>
        public void Insert(int score)
        {
            string query = String.Format("INSERT INTO Highscore (username, dato, score, userID) VALUES('{0}', '{1}', '{2}', '{3}')", User.Username, DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), highScore, User.Id);

            try
            {
                db.InsertDeleteUpdate(query);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Feil oppsto ved INSERT med melding: " + ex.Message);
            }
        }
    }
}
