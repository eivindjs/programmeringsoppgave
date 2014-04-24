﻿using System;
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
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            var threadNewGame = new Thread(ThreadNewGame);
            threadNewGame.Start();
        }

        private void ThreadNewGame()
        {
            GameForm gameform = new GameForm();
            Application.Run(gameform);
        }
        //Kort og enkelt ka det går ut på? ka du tror Tord?
        private void btnAbout_Click(object sender, EventArgs e)
        {

        }
      
    }
}
