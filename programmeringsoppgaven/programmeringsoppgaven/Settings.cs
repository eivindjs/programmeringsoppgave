using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectcsharp;

namespace projectcsharp
{
    public partial class Settings : Form
    {

        /// <summary>
        /// Klasse/Form der du kan endre brukernavne ditt, passord og slette poengsummen din
        /// </summary>
        
        private DBConnect db = new DBConnect(); //Oppkobling mot database
        private string query; //Variabel for sql spørringer
        private string username; //Variabel for brukernavn
        private string oldPassword; //Gamle passordet du skriver inn
        private string newPassword; //Nye Passordet
        private int id; //bruker ID'en
        //private DataTable dt;
        //private DBConnect db;


        public Settings()
        {
            InitializeComponent();
            tbUsername.Text = User.Username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            username = tbUsername.Text;
            oldPassword = Encryption.Encrypt(tbOldPass.Text);
            newPassword = Encryption.Encrypt(tbNewPass.Text);
            id = User.Id;

            if (tbOldPass.Text == String.Empty && tbNewPass.Text == String.Empty)
            {
                query = String.Format("UPDATE User SET username = '" + username + "' WHERE userID = " + id + "");
                User.Username = username;
                Update(query);
            }
      
            if (User.Password == oldPassword && tbOldPass.Text != String.Empty && tbNewPass.Text != String.Empty)
            {
                query = String.Format("UPDATE User SET username = '" + username + "', password = '" + newPassword + "' WHERE userID = " + id + "");
                User.Username = username;
                User.Password = newPassword;
                Update(query);
            }

            else
            {
                MessageBox.Show("Feil passord");
            }          
        }
        /// <summary>
        /// Metode for å oppdatere en bruker
        /// </summary>
        /// <param name="sqlquery">sql spørring(string)</param>
        private void Update(string sqlquery)
        {
            try
            {
                db.InsertDeleteUpdate(sqlquery);
                MessageBox.Show("Endring lagret!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Feil oppsto ved UPDATE med melding: " + ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sikker på at du vil slette highscoren din?","", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.OK)
            {
                query = String.Format("DELETE FROM Highscore WHERE userID = '" + User.Id + "'");
                Delete(query);
            }
           
        }
        /// <summary>
        /// Metode for å slette poengsummen til innlogget bruker
        /// </summary>
        /// <param name="sqlquery">sql spørring(string)</param>
        private void Delete(string sqlquery)
        {
            try
            {
                db.InsertDeleteUpdate(sqlquery);
                MessageBox.Show("Highscoren din er slettet!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Feil oppsto ved DELETE med melding: " + ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
        
    }
}
