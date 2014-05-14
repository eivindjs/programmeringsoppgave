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
    //Dette blir level 1. Tenker hver level har egen form for å gjøre det enklest mulig. 
    //Har lagt til en mypanel klasse som arver fra panel 
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
      
    }
}
