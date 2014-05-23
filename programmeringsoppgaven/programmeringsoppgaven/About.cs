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
    /// <summary>
    /// About.cs
    /// 
    /// En klasse/form som kort og enkelt forteller hva spillet handler om 
    /// og hvem som har utviklet det. Forteller også om spilleregler.
    /// </summary>
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt
            lblAbout.BackColor = Color.Transparent;
           
        }
    }
}
