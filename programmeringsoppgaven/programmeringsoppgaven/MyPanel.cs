using projectcsharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        #region  Medlemsvariabler

        private ThreadStart ts;
        private Thread thread;
        private ThreadStart playSound;
        private Thread soundThread;

        private MovingMan movingMan;
        private System.Windows.Forms.Timer timer;
        private PictureBox superman;
        private Random random;
        private int manSize;
        private DBConnect db;
        public bool gameOver { get; set; }
        public bool restart { get; set; }

        public Level myLevel;
        public int level { get; set; }
        public int seconds { get; set; }
        public int minutes { get; set; }
        public bool running { get; set; }
        public int highScore { get; set; }

        public static Object mySync;
        public static int smileysToCatch;

        #endregion

        /// <summary>
        /// Konstruktøren. Her instansieres viktige objekter som skal være tilgjengelig ved oppstart.
        /// </summary>
        public MyPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
       ControlStyles.UserPaint |
       ControlStyles.AllPaintingInWmPaint,
       true);
            this.UpdateStyles();
            db = new DBConnect();
            mySync = new Object();
            restart = true;

            level = 1;
            manSize = 30;
            random = new Random();
            superman = new PictureBox();
            superman.Image = projectcsharp.Properties.Resources.super;
            superman.Size = new System.Drawing.Size(manSize, manSize);
            superman.SizeMode = PictureBoxSizeMode.Zoom;

            this.Controls.Add(superman); //legger pictureBox til panelet
            this.Controls.Add(superman);

            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = 17;
            timer.Tick += new EventHandler(Timer_Tick);




        }


        public void RunGame()
        {
            if (level == 1)
            {
                StartGame();
            }
            else if (smileysToCatch == 0)
            {
                StartNextLevel();
            }
            else
                RestartCurrentGame();
        }

        public void StartGame()
        {
            myLevel = new Level(this);
            seconds = 10; // korrekt???
            minutes = 1; // korrekt???
            smileysToCatch = myLevel.listSmileys.Count;

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

        public void RestartCurrentGame()
        {
            StartGame();
        }

        public void StopGame()
        {
            running = false;
            // timer.Enabled = false;
            timer.Stop();
            myLevel.StopTimer();
            //level = 1; // korrekt???

            myLevel.ClearBalls();

            seconds = 10; // korrekt???
            minutes = 1; // korrekt???

            ShowMessageBox();
        }

        public void StartNextLevel()
        {
            running = true;

            timer.Enabled = true;
            timer.Start();

            myLevel = new Level(this);
            smileysToCatch = myLevel.listSmileys.Count;

            movingMan = new MovingMan //setter verdiene til MovingMan tilbake vha properties
            {
                X = 10f,
                Y = 10f,
                DX = 4f,
                DY = 3f,
            };
            superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);

            startAnimation();
        }

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
            myLevel.StartBallTimer();

        }

        private void Timer_Tick(object sender, EventArgs e)
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
                    StopGame();
                    // Insert(highScore);    
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
                    myLevel.ClearBalls();
                }
                else
                {
                    MessageBox.Show("Du tapte! Trykk start for nytt spill.");
                }
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


        public void PlaySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.collisionSound);
            player.PlaySync();
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
            if (running)
            {

                lock (mySync)
                {
                    if (this.movingMan != null)
                    {
                        base.OnPaint(e);
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                        superman.Location = new Point((int)movingMan.X, (int)movingMan.Y);
                        GraphicsPath supermanPath = new GraphicsPath();
                        supermanPath.StartFigure();
                        supermanPath.AddRectangle(new Rectangle((int)movingMan.X, (int)movingMan.Y, (int)manSize, (int)manSize));
                        supermanPath.CloseFigure();

                        e.Graphics.DrawLine(new Pen(Color.Green), new Point(0, 40), new Point(40, 40)); //plattformen ved start

                        for (int i = 0; i < myLevel.listSmileys.Count; i++) //tegn alle smileys
                        {
                            Smiley smiley = myLevel.listSmileys[i];
                            smiley.Draw(e.Graphics);
                            if (CheckCollision(smiley.GetPath(), supermanPath, e))
                            {
                                myLevel.AddScore(i);
                                smileysToCatch--;

                                playSound = new ThreadStart(PlaySound);
                                soundThread = new Thread(playSound);
                                soundThread.IsBackground = true;
                                soundThread.Start();

                                if (smileysToCatch == 0)
                                {
                                    level++;
                                    StopGame();
                                    restart = false;
                                    gameOver = false;


                                }
                            }
                        }
                        for (int i = 0; i < myLevel.listShooters.Count; i++)
                        {
                            Shooter shooter = myLevel.listShooters[i];
                            shooter.Draw(e.Graphics);

                            if (CheckCollision(shooter.GetPath(), supermanPath, e))
                            {
                                if (running)
                                {
                                    StopGame();
                                    //     Insert(highScore);

                                }
                            }

                        }

                        for (int i = 0; i < myLevel.listObstacle.Count; i++)
                        {
                            Obstacle obstacle1 = myLevel.listObstacle[i];

                            obstacle1.Draw(e.Graphics);
                            if (CheckCollision(obstacle1.GetPath(), supermanPath, e))
                            {
                                highScore--;
                            }
                        }

                        for (int i = 0; i < myLevel.listBalls.Count; i++)
                        {
                            MovingBall ball = myLevel.listBalls[i];
                            ball.Draw(e.Graphics);

                            GraphicsPath myPath = new GraphicsPath();
                            myPath.StartFigure();
                            myPath.AddEllipse(ball.x, ball.y, ball.w, ball.h);
                            myPath.CloseFigure();



                            for (int j = 0; j < myLevel.listSmileys.Count; j++) //tegn alle smileys
                            {
                                Smiley smiley = myLevel.listSmileys[j];
                                if (CheckCollision(smiley.GetPath(), myPath, e))
                                {
                                    myLevel.listBalls.RemoveAt(i);

                                }
                            }


                            for (int j = 0; j < myLevel.listObstacle.Count; j++) //tegn alle smileys
                            {
                                Obstacle obstacle = myLevel.listObstacle[j];
                                if (CheckCollision(obstacle.GetPath(), myPath, e))
                                {
                                    myLevel.listBalls.RemoveAt(i);
                                    
                                }
                            }






                          
                            if (CheckCollision(myPath, supermanPath, e))
                            {
                                //myLevel.listBalls.RemoveAt(i);

                                StopGame();
                            }
                            if (ball.x > this.Width || ball.x < 0)
                            {
                                myLevel.listBalls.RemoveAt(i);
                                Debug.Print("ball fjernet");
                            }
                            if (ball.y > this.Height || ball.y < 0)
                            {
                                myLevel.listBalls.RemoveAt(i);
                                Debug.Print("ball fjernet");
                            }
                        }
                    }
                } //lock
            }//running
        } //onPaint
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
