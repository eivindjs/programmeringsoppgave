namespace projectcsharp
{
    partial class LevelForm
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
            this.mainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.infoTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblLevel = new System.Windows.Forms.Label();
            this.buttonTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.gamePanel1 = new projectcsharp.GamePanel();
            this.mainTablePanel.SuspendLayout();
            this.infoTablePanel.SuspendLayout();
            this.buttonTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTablePanel
            // 
            this.mainTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTablePanel.AutoSize = true;
            this.mainTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainTablePanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.mainTablePanel.ColumnCount = 1;
            this.mainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTablePanel.Controls.Add(this.infoTablePanel, 0, 0);
            this.mainTablePanel.Controls.Add(this.buttonTablePanel, 0, 2);
            this.mainTablePanel.Controls.Add(this.gamePanel1, 0, 1);
            this.mainTablePanel.Location = new System.Drawing.Point(0, 0);
            this.mainTablePanel.Name = "mainTablePanel";
            this.mainTablePanel.RowCount = 3;
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainTablePanel.Size = new System.Drawing.Size(1510, 822);
            this.mainTablePanel.TabIndex = 0;
            // 
            // infoTablePanel
            // 
            this.infoTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.infoTablePanel.ColumnCount = 4;
            this.infoTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.infoTablePanel.Controls.Add(this.lblLevel, 0, 0);
            this.infoTablePanel.Location = new System.Drawing.Point(3, 3);
            this.infoTablePanel.Name = "infoTablePanel";
            this.infoTablePanel.RowCount = 1;
            this.infoTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.infoTablePanel.Size = new System.Drawing.Size(1504, 35);
            this.infoTablePanel.TabIndex = 1;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(3, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(76, 25);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level1";
            // 
            // buttonTablePanel
            // 
            this.buttonTablePanel.ColumnCount = 4;
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTablePanel.Controls.Add(this.btnStart, 0, 0);
            this.buttonTablePanel.Location = new System.Drawing.Point(3, 742);
            this.buttonTablePanel.Name = "buttonTablePanel";
            this.buttonTablePanel.RowCount = 1;
            this.buttonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.buttonTablePanel.Size = new System.Drawing.Size(1504, 77);
            this.buttonTablePanel.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(370, 71);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gamePanel1
            // 
            this.gamePanel1.Location = new System.Drawing.Point(3, 44);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(1485, 692);
            this.gamePanel1.TabIndex = 3;
            // 
            // LevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1512, 841);
            this.Controls.Add(this.mainTablePanel);
            this.Name = "LevelForm";
            this.Text = "LevelForm";
            this.mainTablePanel.ResumeLayout(false);
            this.infoTablePanel.ResumeLayout(false);
            this.infoTablePanel.PerformLayout();
            this.buttonTablePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTablePanel;
        private System.Windows.Forms.TableLayoutPanel infoTablePanel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.TableLayoutPanel buttonTablePanel;
        private System.Windows.Forms.Button btnStart;
        private GamePanel gamePanel1;
    }
}