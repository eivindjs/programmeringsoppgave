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
    public partial class Highscore : Form
    {

        private Image image = projectcsharp.Properties.Resources.loginbackground;
        private DBConnect db = new DBConnect();
        private DataTable dt = new DataTable();
        private BindingSource bs = new BindingSource();

        public Highscore()
        {
            InitializeComponent();
            string query = String.Format("SELECT username, dato, score FROM Highscore ORDER BY score desc");
            dt = db.getAll(query);

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int score = Convert.ToInt16(dt.Rows[i]["score"]);
                    string username = Convert.ToString(dt.Rows[i]["username"]);
                    DateTime dato = Convert.ToDateTime(dt.Rows[i]["dato"]);
                    dtGridviewScore.Rows.Add(username, dato.ToShortDateString(), score);
                   
                 }
            }
        }
    }
}
