using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectcsharp
{
    //Dette blir level 1. Tenker hver level har egen form for å gjøre det enklest mulig. 
    //Bør kanskje ha en egen panel form? som arve fra Panel?
    public partial class GameForm : Form
    {
        private Random random;
        private float x;
        private float y;
        private float h;
        private float w;


        public GameForm()
        {
            InitializeComponent();
            random = new Random();
            x = random.Next(0, mainPanel.Width);
            y = random.Next(0, mainPanel.Height);
            h = 40;
            w = 35;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Rectangle rekt1 = new Rectangle((int)x, (int)y, (int)w, (int)h);
            Rectangle rekt2 = new Rectangle((int)x, (int)y, (int)w, (int)h);
            Rectangle rekt3 = new Rectangle((int)x, (int)y, (int)w, (int)h);

        }
    

    }
}
