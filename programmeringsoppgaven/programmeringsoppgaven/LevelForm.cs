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
        /// LevelForm.cs
        /// Her er rammen til spillbrettet (MyPanel). Inneholder en timer for å oppdatere tiden som gjenstår.
        /// LevelForm er delt inn i paneler. 2 rader og 1 kolonne. Øverste rad inneholder MyPanel. Nederste rad 
        /// inneholder et nytt panel med 4 kolonner som holder på knapper og labels.
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
                    stopWatch.Enabled = false; //stopper timeren
                    lblTime.Text = "Tid Igjen: 00:00";               
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
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}
