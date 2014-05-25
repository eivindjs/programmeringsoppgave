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
        private DBConnect db = new DBConnect(); //Databasetilkobling
        private DataTable table = new DataTable(); //Tabell for data
        private string username; //Brukernavn
        private string password; //Passord
        private string passwordIn; //Passord du skriver inn
        private List<string> checkUsername = new List<string>(); //liste for å lagre alle brukerne for så å sjekke om brukernavn eksisterer
        private String query; //sql spørringer
      
        /// <summary>
        /// Klasse for å registrere ny bruker
        /// </summary>
        public RegisterNewUser()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt

        }

        //registrerer ny bruker(legges i database) ved trykk
        private void btnRegister_Click(object sender, EventArgs e)
        {
            username = tbUsername.Text;
            passwordIn = tbPassword.Text;
            password = Encryption.Encrypt(passwordIn);
            query = "SELECT username FROM User";
            table = db.getAll(query);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                checkUsername.Add(table.Rows[i]["username"].ToString());
            }
            if (checkUsername.Contains(username))
            {
                MessageBox.Show("Brukernavnet eksisterer fra før, velg et annet!");
            }
            else
            {
                query = String.Format("INSERT INTO User (username, password) VALUES('{0}', '{1}')", username, password);
                Insert(query);
            }
        }

        /// <summary>
        /// Metode for å legge til en ny bruker
        /// </summary>
        /// <param name="sqlquery">Sql spørring</param>
        private void Insert(string sqlquery)
        {
            //tar i mot og behandler exceptions

            try
            {
                db.InsertDeleteUpdate(query);
                MessageBox.Show("Ny bruker registrert!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Feil oppsto ved INSERT med melding: " + ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
