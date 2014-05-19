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
    public partial class LevelForm : Form
    {

        public LevelForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            myPanel1.Restart();

        }
    }
}
