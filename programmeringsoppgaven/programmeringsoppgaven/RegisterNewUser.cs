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
    public partial class RegisterNewUser : Form
    {
        //deklarerer variabler
        private DBConnect db = new DBConnect();
        private DataTable table = new DataTable();
        private string username;
        private string password;
        private string passwordIn;
        private String query;

        public RegisterNewUser()
        {
            InitializeComponent();
        }

        //registrerer ny bruker(legges i database) ved trykk
        private void btnRegister_Click(object sender, EventArgs e)
        {
            username = tbUsername.Text;
            passwordIn = tbPassword.Text;
            password = Encryption.Encrypt(passwordIn);
            query = String.Format("INSERT INTO User (username, password) VALUES('{0}', '{1}')", username, password);

            //tar i mot og behandler exceptions
            try
            {
                db.InsertDeleteUpdate(query);
            }
            catch (Exception ex) {
                Console.WriteLine("Feil oppsto ved INSERT med melding: " + ex.Message);
            }
            finally
            {
                this.Close();
            }

        }
    }
}
