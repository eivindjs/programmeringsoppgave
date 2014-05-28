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
        /// <summary>
        /// Tord og Eivind
        /// </summary>
        public LevelForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt

            stopWatch = new System.Windows.Forms.Timer();
            stopWatch.Interval = 1000; //skal "tikke" hvert sekund, for å emulere en stoppeklokke
            stopWatch.Tick += new EventHandler(StopWatch_Tick);
            stopWatch.Enabled = false;

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 17;
            updateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            updateTimer.Enabled = false;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gamePanel.RunGame();

            stopWatch.Enabled = true;
            updateTimer.Enabled = true;
        }


        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!gamePanel.running)
            {
                updateTimer.Enabled = false;
                stopWatch.Enabled = false;
            }

            lblScore.Text = "Score: " + gamePanel.highScore;
            lblTime.Text = "Tid Igjen: " + gamePanel.myLevel.minutes.ToString() + ":" + gamePanel.myLevel.seconds.ToString();
            lblLevel.Text = "Level " + gamePanel.level;

        }

        private void StopWatch_Tick(object sender, EventArgs e)
        {
            if (!gamePanel.running)
            {
                updateTimer.Enabled = false;
                stopWatch.Enabled = false;
            }
            else
            {
                // når tiden er lik null
                if ((gamePanel.myLevel.minutes == 0) && (gamePanel.myLevel.seconds == 0))
                {
                    //må kanskje legge inn mer her
                    stopWatch.Enabled = false; //stopper timeren
                    // MainForm.levelForm.min
                    lblTime.Text = "Tid Igjen: 00:00";
                    //legge til lagring av highscore
                    // string query = string.Format("INSERT INTO Highscore (username, dato, score, userID) VALUES('{0}', '{1}', '{2}', '{3}')", User.Username, DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), poengsum, User.Id);
                    // Insert(query);
                    stopWatch.Stop();
                    gamePanel.StopGame();
                }
                else
                {
                    if (gamePanel.myLevel.seconds < 1)
                    {
                        gamePanel.myLevel.seconds = 59;
                        if (gamePanel.myLevel.minutes == 0)
                        {
                            gamePanel.myLevel.minutes = 59;

                        }
                        else
                        {
                            gamePanel.myLevel.minutes -= 1;
                        }
                    }
                    else
                        gamePanel.myLevel.seconds -= 1;
                    //myPanel.Insert highscore
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
