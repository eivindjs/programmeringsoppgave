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
        #region  Medlemsvariabler
        private ThreadStart ts;
        private Thread thread;
        private MovingMan movingMan;
        private System.Windows.Forms.Timer timer;
        private PictureBox superman;
        private Random random;
        private int manSize;
        public static Object mySync = new Object();
        private Label lblTime, lblScore, lblLevel;
        private DBConnect db = new DBConnect();
        public static int smileysToCatch = 1;
        public int level { get; set; }
        public int seconds { get; set; }
        public int minutes { get; set; }
        public bool playSound { get; set; }
        public bool running { get; set; }
        public int highScore { get; set; }
        public Level myLevel;
        private int run = 1;
        #endregion

        /// <summary>
        /// Konstruktøren. Her instansieres viktige objekter som skal være tilgjengelig ved oppstart.
        /// </summary>
        public MyPanel()
        {
            seconds = 1;
            minutes = 1;
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


        }

        public void Restart()
        {
            lock (mySync)
            {
                
                myLevel = new Level(this);

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
            if (run == 1)
            {
                ts = new ThreadStart(UpdateGraphics);
                thread = new Thread(ts);
                thread.IsBackground = true;
                thread.Start();

                run++;
            }

            myLevel.StartTimer();
        }
        /// <summary>
        /// Timer for ballene, som skytes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
                    myLevel.StopTimer();

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

                    for (int i = 0; i < myLevel.listSmileys.Count; i++) //tegn alle smileys
                    {
                        Smiley smiley = myLevel.listSmileys[i];
                        smiley.Draw(e.Graphics);
                        if (CheckCollision(smiley.GetPath(), supermanPath, e))
                        {
                            myLevel.AddScore(i);
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
                    for (int i = 0; i < myLevel.listShooters.Count; i++)
                    {
                        Shooter shooter = myLevel.listShooters[i];
                        shooter.Draw(e.Graphics);

                        if (CheckCollision(shooter.GetPath(), supermanPath, e))
                        {
                            running = false;
                            timer.Enabled = false;
                            timer.Stop();

                            myLevel.StopTimer();
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
                
                    for (int i = 0; i < myLevel.listObstacle.Count; i++)
                    {
                        Obstacle obstacle1 = myLevel.listObstacle[i];

                        obstacle1.Draw(e.Graphics);

                        if (CheckCollision(obstacle1.GetPath(), supermanPath, e))
                        {
                            running = false;
                            timer.Enabled = false;
                            timer.Stop();

                            myLevel.StopTimer();

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
