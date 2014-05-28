﻿using System;
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
        /// <summary>
        /// Eivind
        /// Klasse som viser highscore for alle brukere og sorterer etter
        /// poengsum. Viser de 10 beste.
        /// </summary>
        private DBConnect db = new DBConnect(); //sql klasse for å koble til databasen
        private DataTable dt = new DataTable(); //DataTable for å hente ut verdier fra sql

        public Highscore()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //størelsen på vinduet er absolutt

            string query = String.Format("SELECT username, dato, score FROM Highscore ORDER BY score desc LIMIT 10");
            dt = db.getAll(query);

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int score = Convert.ToInt16(dt.Rows[i]["score"]); //Henter ut poengsummen
                    string username = Convert.ToString(dt.Rows[i]["username"]); //Henter ut brukernavn
                    DateTime dato = Convert.ToDateTime(dt.Rows[i]["dato"]); //Henter ut dato
                    dtGridviewScore.Rows.Add(username, dato.ToShortDateString(), score); //legger til dato, brukernavn og poengsum i gridviewen
                   
                 }
            }
        }
    }
}
