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
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            myPanel.Restart();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void myPanel_Paint(object sender, PaintEventArgs e)
        {

        }
      
    }
}
