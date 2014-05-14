using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectcharp;

namespace projectcsharp
{
    public partial class Settings : Form
    {
        private DataTable dt;
        private DBConnect db;

        public Settings()
        {
            InitializeComponent();
            tbUsername.Text = User.Username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
