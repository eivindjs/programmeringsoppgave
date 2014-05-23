using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectcsharp
{
    public partial class LevelForm : Form
    {
        private System.Windows.Forms.Timer stopWatch;
        private System.Windows.Forms.Timer updateTimer;


        public LevelForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt

            stopWatch = new System.Windows.Forms.Timer();
            stopWatch.Interval = 1000; //skal "tikke" hvert sekund, for å emulere en stoppeklokke
            stopWatch.Tick += new EventHandler(StopWatch_Tick);

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 17;
            updateTimer.Tick += new EventHandler(UpdateTimer_Tick);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            myPanel1.Restart(); 
            stopWatch.Enabled = true;
            updateTimer.Enabled = true;     
        }

        public void PlaySound()
        {
            myPanel1.playSound = false;

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.collisionSound);
            player.PlaySync();
        }


        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!myPanel1.running)
            {
                updateTimer.Enabled = false;
            }

            lblScore.Text = "Score: " + myPanel1.highScore;
            lblTime.Text = "Tid Igjen: " + myPanel1.minutes.ToString() + ":" + myPanel1.seconds.ToString();
            lblLevel.Text = "Level " + myPanel1.level;

            if (myPanel1.playSound)
            {
                ThreadStart playSound = new ThreadStart(PlaySound);
                Thread soundThread = new Thread(playSound);
                soundThread.IsBackground = true;
                soundThread.Start();
            }

          
        }


        private void StopWatch_Tick(object sender, EventArgs e)
        {
            if (!myPanel1.running)
            {
                stopWatch.Enabled = false;
            }
            else
            {
                // når tiden er lik null
                if ((myPanel1.minutes == 0) && (myPanel1.seconds == 0))
                {
                    //må kanskje legge inn mer her
                    stopWatch.Enabled = false; //stopper timeren
                    myPanel1.running = false;
                    // MainForm.levelForm.min
                    lblTime.Text = "Tid Igjen: 00:00";
                    //legge til lagring av highscore
                    // string query = string.Format("INSERT INTO Highscore (username, dato, score, userID) VALUES('{0}', '{1}', '{2}', '{3}')", User.Username, DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), poengsum, User.Id);
                    // Insert(query);

                    myPanel1.ShowMessageBox();

                    myPanel1.highScore = 0;
                    myPanel1.seconds = 10;
                    myPanel1.minutes = 1;
                    myPanel1.level = 1;
                }
                else
                {
                    if (myPanel1.seconds < 1)
                    {
                        myPanel1.seconds = 59;
                        if (myPanel1.minutes == 0)
                        {
                            myPanel1.minutes = 59;

                        }
                        else
                        {
                            myPanel1.minutes -= 1;
                        }
                    }
                    else
                        myPanel1.seconds -= 1;
                    // Display the current values of hours, minutes and seconds in
                    // the corresponding fields.
                    //  myPanel1.Insert(myPanel1.highScore);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
