﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectcsharp
{
    public partial class LoginForm : Form
    {
        //HEIA EIVIND!!
        //HEIA TORD!!
        //Herlig at du såg det Eivind aka The Rock!

        private DBConnect db = new DBConnect();
        private DataTable dt = new DataTable();
        private string username;
        private string password;
        private string passwordIn;

        public LoginForm()
        {
            InitializeComponent();

        }

        //kjører når knappen btnLogin trykkes. Sjekker om bruker er registert med riktig passord
        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = tbUsername.Text;
            password = tbPassword.Text;
            passwordIn = Encryption.Encrypt(password);

            string query = String.Format("SELECT userID, password FROM User WHERE username = '{0}'", username);
            dt = db.getAll(query);


            if (dt != null && dt.Rows.Count > 0)
            {
                int userID = Convert.ToInt16(dt.Rows[0]["userID"]);
                string userPW = Convert.ToString(dt.Rows[0]["password"]);

                if (passwordIn == userPW)
                {
                    var threadNewGame= new Thread(ThreadNewGame);
                    threadNewGame.Start();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Feil brukernavn og/eller passord.");
                }

            }
            else
            {
                MessageBox.Show("Feil brukernavn og/eller passord.");
            }

         
        }

        private void ThreadRegister()
        {
            RegisterNewUser registerNewUser = new RegisterNewUser();
            Application.Run(registerNewUser);
        }

        private void ThreadNewGame()
        {
            GameForm gameform = new GameForm();
            Application.Run(gameform);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var threadRegisterNew = new Thread(ThreadRegister);
            threadRegisterNew.Start();
            //lukker registrering om LoginFrom lukkes
            threadRegisterNew.IsBackground = true;
            
        }
     
    }
}
