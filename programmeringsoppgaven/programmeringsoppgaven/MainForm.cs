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
    public partial class MainForm : Form
    {
        public static LevelForm levelForm;
        /// <summary>
        /// Tord og Eivind
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            var threadNewGame = new Thread(ThreadNewGame);
            threadNewGame.Start();
        }

        private void ThreadNewGame()
        {
            levelForm = new LevelForm();
            Application.Run(levelForm);

        }
        public static void EndGame()
        {


        }

        public void ShowMainForm()
        {
            levelForm.Close();
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            var threadAbout = new Thread(ThreadAbout);
            threadAbout.Start();
        }
        private void ThreadAbout()
        {
            About about = new About();
            Application.Run(about);
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            var threadScore = new Thread(ThreadHighScore);
            threadScore.Start();
        }
        private void ThreadHighScore()
        {
            Highscore highScore = new Highscore();
            Application.Run(highScore);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            var threadSettings = new Thread(ThreadSettings);
            threadSettings.Start();

        }
        private void ThreadSettings()
        {
            Settings settings = new Settings();
            Application.Run(settings);
        }

        private void lukkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void instillingerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var threadAbout = new Thread(ThreadAbout);
            threadAbout.Start();
        }

        private void loggUtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var threadLogOut = new Thread(ThreadLogOut);
            threadLogOut.Start();
            this.Close();
        }

        private void ThreadLogOut()
        {
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}
