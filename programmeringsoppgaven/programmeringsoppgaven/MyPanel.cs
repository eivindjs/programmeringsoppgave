﻿using projectcsharp;
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
    /// Tord og Eivind
    /// Her skjer magien. Klassen tar seg av selve spillbrettet. En egen tråd tar seg av tegning.
    /// </summary>
    public partial class MyPanel : Panel
    {
        #region  Medlemsvariabler

        private ThreadStart ts;
        private Thread thread;
        private ThreadStart playSound;
        private Thread soundThread;
        private Thread gameOverThread;
        private ThreadStart gameOverTS;
        private MovingMan movingMan;
        private System.Windows.Forms.Timer timer;
        private Random random;
        private DBConnect db;
        public bool gameOver { get; set; }
        public Level myLevel;
        public int level { get; set; }
        public int seconds { get; set; }
        public int minutes { get; set; }
        public bool running { get; set; }
        public int highScore { get; set; }
        public static Object mySync;
        
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

            level = 1;
            random = new Random();

            this.timer = new System.Windows.Forms.Timer();
            timer.Interval = 17;
            timer.Tick += new EventHandler(Timer_Tick);
        }
        #region Game controller
        /// <summary>
        /// Kalles fra LevelForm. Her avgjøres det om spillet skal fortsette eller starte på nytt.
        /// </summary>
        public void RunGame()
        {
            highScore = 0;
            if (this.movingMan != null)
            {
                movingMan.GetPictureBox().Hide();
            }
            if (level == 1)
            {
                StartGame();
            }
            else if (myLevel.listSmileys.Count == 0)
            {
                StartNextLevel();
            }
            else
                RestartCurrentGame();
        }

        public void StartGame()
        {
            myLevel = new Level(this);

            movingMan = new MovingMan //setter verdiene til MovingMan tilbake vha properties
            {
                X = 10f,
                Y = 10f,
                DX = 4f,
                DY = 3f,
            };

            this.Controls.Add(movingMan.GetPictureBox()); //legger pictureBox til panelet

            running = true;
            timer.Start();
            startAnimation();
        }

        public void RestartCurrentGame()
        {
            myLevel = new Level(this);
            running = true;
            timer.Start();
            myLevel.StartBallTimer();
            startAnimation();
        }
        /// <summary>
        /// Kalles alltid ved "game over": Når du treffer bakken, en skytter eller dens baller. 
        /// Kalles også når spilletiden går ut.
        /// </summary>
        public void StopGame()
        {
            running = false;
            timer.Stop();
            myLevel.StopBallTimer();
            gameOverTS = new ThreadStart(GameOverSound);
            gameOverThread = new Thread(gameOverTS);
            gameOverThread.IsBackground = true;
            gameOverThread.Start();
            ShowMessageBox();

            movingMan.GetPictureBox().Hide();
            myLevel.ClearBalls();
            level = 1;
        }

        public void StartNextLevel()
        {            
            timer.Enabled = true;
            timer.Start();
            myLevel = new Level(this);
            myLevel.StartBallTimer();
            movingMan.SetLocation();
        }
        #endregion

        #region Thread & timer 

        public void UpdateGraphics()
        {
            while (running)
            {
                Thread.Sleep(17); //å la tråden sove i 17 ms er optimalt for å oppnå en framerate på ca 60 FPS
                this.Invalidate(); //kaller bl.a. på OnPaint()
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
        /// <summary>
        /// Avgjør hvordan spillfiguren skal bevege seg, avhengig av tastetrykk.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
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
                     Insert(highScore);    
                }         
        }

        public void ShowMessageBox()
        {
            lock (mySync)
            {
                if (myLevel.listSmileys.Count == 0)
                {
                    MessageBox.Show("Du klarte det! Trykk start for neste brett.");
                    myLevel.ClearBalls();
                }
                else if (myLevel.level == 6)
                {
                    MessageBox.Show("Gratulerer! Du har fullført spillet! Sjekk din highscore i hovedmenyen!");

                }
                else
                {
                    MessageBox.Show("Du tapte! Trykk start for nytt spill.");
                }
            }
        }
        #endregion

        #region Collision detection
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

        public void GameOverSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.gameover);
            player.PlaySync();
        }
        public void PlaySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.collisionSound);
            player.PlaySync();
        }

        /// <summary>
        /// Sjekker kollisjon på endrede koordinater for spillfigur, hindring, smiley, skyter og dens baller.
        /// </summary>
        /// <param name="e"></param>
        public void UpdateMovement(PaintEventArgs e)
        {
                for (int i = 0; i < myLevel.listSmileys.Count; i++) //tegn alle smileys
                {
                    if (CheckCollision(myLevel.listSmileys[i].GetPath(), movingMan.GetPath(), e))
                    {
                        lock (mySync)
                        {
                            myLevel.AddScore(i);
                        }
                        if (myLevel.level != 6)
                        {
                            playSound = new ThreadStart(PlaySound);
                            soundThread = new Thread(playSound);
                            soundThread.IsBackground = true;
                            soundThread.Start();
                        }
                        if (myLevel.listSmileys.Count == 0)
                        {
                            level++;
                            StartNextLevel();
                            gameOver = false;
                          }
                    }
                }

                for (int i = 0; i < myLevel.listShooters.Count; i++)
                {
                    if (CheckCollision(myLevel.listShooters[i].GetPath(), movingMan.GetPath(), e))
                    {
                        if (running)
                        {
                            StopGame();   
                            Insert(highScore);
                        }
                    }
                }

                for (int i = 0; i < myLevel.listObstacle.Count; i++)
                {
                    if (CheckCollision(myLevel.listObstacle[i].GetPath(), movingMan.GetPath(), e))
                    {
                        highScore--;
                    }
                }
                
                for (int i = 0; i < myLevel.listBalls.Count; i++)
                {
                    if (CheckCollision(myLevel.listBalls[i].GetPath(), movingMan.GetPath(), e))
                    {
                        StopGame();
                    }
                }
                lock (mySync)
                {
                    for (int i = 0; i < myLevel.listBalls.Count; i++)
                    {
                        if (myLevel.listBalls[i].x > this.Width || myLevel.listBalls[i].x < 0)
                        {
                            myLevel.listBalls.RemoveAt(i);
                        }
                        if (myLevel.listBalls[i].y > this.Height || myLevel.listBalls[i].y < 0)
                        {
                            myLevel.listBalls.RemoveAt(i);
                        }
                    }
                }
        }
        #endregion

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
                    if (this.movingMan != null)
                    {
                        base.OnPaint(e);
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        e.Graphics.DrawLine(new Pen(Color.Green), new Point(0, 40), new Point(40, 40)); //plattformen ved start

                        movingMan.SetLocation();
                        myLevel.Draw(e.Graphics);
                        UpdateMovement(e);             
                    } 
            }//running
        } //onPaint

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
