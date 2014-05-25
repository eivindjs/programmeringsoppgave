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
        /// 
        /// </summary>
        public LevelForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();         
        }
        public void StartGame()
        {
            stopWatch = new System.Windows.Forms.Timer();
            stopWatch.Interval = 1000; //skal "tikke" hvert sekund, for å emulere en stoppeklokke
            stopWatch.Tick += new EventHandler(StopWatch_Tick);
            stopWatch.Enabled = false;

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 17;
            updateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            updateTimer.Enabled = false;

            stopWatch.Enabled = true;
            updateTimer.Enabled = true;

            if (gamePanel.restart)
            {
                gamePanel.StartGame();
            }
            else if (gamePanel.gameOver)
            {
                gamePanel.RestartCurrentGame();
            }
            else
                gamePanel.StartNextLevel();

        }
 

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!gamePanel.running)
            {
                updateTimer.Enabled = false;
            }

            lblScore.Text = "Score: " + gamePanel.highScore;
            lblTime.Text = "Tid Igjen: " + gamePanel.minutes.ToString() + ":" + gamePanel.seconds.ToString();
            lblLevel.Text = "Level " + gamePanel.level;

        }

        private void StopWatch_Tick(object sender, EventArgs e)
        {
            if (!gamePanel.running)
            {
                stopWatch.Enabled = false;
            }
            else
            {
                // når tiden er lik null
                if ((gamePanel.minutes == 0) && (gamePanel.seconds == 0))
                {
                    //må kanskje legge inn mer her
                    stopWatch.Enabled = false; //stopper timeren
                    gamePanel.running = false;
                    // MainForm.levelForm.min
                    lblTime.Text = "Tid Igjen: 00:00";
                    //legge til lagring av highscore
                    // string query = string.Format("INSERT INTO Highscore (username, dato, score, userID) VALUES('{0}', '{1}', '{2}', '{3}')", User.Username, DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), poengsum, User.Id);
                    // Insert(query);

                    gamePanel.ShowMessageBox();

                    gamePanel.highScore = 0;
                    gamePanel.seconds = 10;
                    gamePanel.minutes = 1;
                    gamePanel.level = 1;
                }
                else
                {
                    if (gamePanel.seconds < 1)
                    {
                        gamePanel.seconds = 59;
                        if (gamePanel.minutes == 0)
                        {
                            gamePanel.minutes = 59;

                        }
                        else
                        {
                            gamePanel.minutes -= 1;
                        }
                    }
                    else
                        gamePanel.seconds -= 1;
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
