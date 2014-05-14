namespace projectcsharp
{
    partial class Highscore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtGridviewScore = new System.Windows.Forms.DataGridView();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridviewScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridviewScore
            // 
            this.dtGridviewScore.AllowUserToDeleteRows = false;
            this.dtGridviewScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridviewScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.username,
            this.dato,
            this.score});
            this.dtGridviewScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridviewScore.Location = new System.Drawing.Point(0, 0);
            this.dtGridviewScore.Name = "dtGridviewScore";
            this.dtGridviewScore.ReadOnly = true;
            this.dtGridviewScore.Size = new System.Drawing.Size(400, 289);
            this.dtGridviewScore.TabIndex = 1;
            // 
            // username
            // 
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 118;
            // 
            // dato
            // 
            this.dato.HeaderText = "Date";
            this.dato.Name = "dato";
            this.dato.ReadOnly = true;
            this.dato.Width = 118;
            // 
            // score
            // 
            this.score.HeaderText = "Score";
            this.score.Name = "score";
            this.score.ReadOnly = true;
            this.score.Width = 118;
            // 
            // Highscore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::projectcsharp.Properties.Resources.loginbackground;
            this.ClientSize = new System.Drawing.Size(400, 289);
            this.Controls.Add(this.dtGridviewScore);
            this.Name = "Highscore";
            this.Text = "Highscore";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridviewScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridviewScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn dato;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
    }
}