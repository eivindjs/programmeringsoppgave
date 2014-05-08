namespace projectcsharp
{
    partial class GameForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.myPanel = new projectcsharp.MyPanel();
            this.lblLevel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.myPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.myPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.95349F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.04651F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 433);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.buttonStart);
            this.panelButton.Location = new System.Drawing.Point(3, 388);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(618, 42);
            this.panelButton.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(107, 35);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // myPanel
            // 
            this.myPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.myPanel.Controls.Add(this.lblLevel);
            this.myPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanel.Location = new System.Drawing.Point(3, 3);
            this.myPanel.Name = "myPanel";
            this.myPanel.Size = new System.Drawing.Size(618, 379);
            this.myPanel.TabIndex = 2;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(275, 6);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(42, 13);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level 1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 433);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.myPanel.ResumeLayout(false);
            this.myPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPanel myPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label lblLevel;
    }
}