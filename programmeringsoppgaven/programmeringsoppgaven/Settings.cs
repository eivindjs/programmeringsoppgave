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
        /// Eivind
        /// Klasse/Form der du kan endre brukernavne ditt, passord og slette poengsummen din
        /// </summary>
        #region Private Medlemsvariabler
        private DBConnect db = new DBConnect(); //Oppkobling mot database
        private string query; //Variabel for sql spørringer
        private string username; //Variabel for brukernavn
        private string oldPassword; //Gamle passordet du skriver inn
        private string newPassword; //Nye Passordet
        private int id; //bruker ID'en
        #endregion 

        public Settings()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt

            InitializeComponent();
            tbUsername.Text = User.Username;
            if (User.Difficulty_level > 0)
            {
                if (User.Difficulty_level == 1)
                {
                    rbEasy.Checked = true;
                }
                if (User.Difficulty_level == 2)
                {
                    rbNormal.Checked = true;
                }
                if (User.Difficulty_level == 3)
                {
                    rbHard.Checked = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text != String.Empty)
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
                    Level();
                }

                if (User.Password == oldPassword && tbOldPass.Text != String.Empty && tbNewPass.Text != String.Empty)
                {
                    query = String.Format("UPDATE User SET username = '" + username + "', password = '" + newPassword + "' WHERE userID = " + id + "");
                    User.Username = username;
                    User.Password = newPassword;
                    Update(query);
                    Level();
                }

                else
                {
                    MessageBox.Show("Feil passord eller du har ikke satt et nytt passord");
                }
            }
            else
            {
                MessageBox.Show("Kan ikke lagre tomme felter");
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
            if (dialogResult == DialogResult.Yes)
            {
                query = String.Format("DELETE FROM Highscore WHERE userID = '" + User.Id + "'");
                Delete(query);
            }
           
        }
        /// <summary>
        /// Metode for valg av level
        /// </summary>
        private void Level()
        {
            if (rbEasy.Checked == true)
            {
                User.Difficulty_level = 1;
                rbNormal.Checked = false;
                rbHard.Checked = false;
            }
            else if (rbNormal.Checked == true)
            {
                User.Difficulty_level = 2;
                rbHard.Checked = false;
                rbEasy.Checked = false;
            }
            else if (rbHard.Checked == true)
            {
                User.Difficulty_level = 3;
                rbEasy.Checked = false;
                rbNormal.Checked = false;
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
