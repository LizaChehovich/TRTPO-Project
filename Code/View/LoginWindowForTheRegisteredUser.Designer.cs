namespace RSS_Reader.View
{
    partial class LoginWindowForTheRegisteredUser
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbUserName = new System.Windows.Forms.ListBox();
            this.label = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btAbort = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(599, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(119, 36);
            this.HelpToolStripMenuItem.Text = "Справка";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbUserName.FormattingEnabled = true;
            this.lbUserName.ItemHeight = 29;
            this.lbUserName.Location = new System.Drawing.Point(145, 128);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(304, 265);
            this.lbUserName.TabIndex = 1;
            this.lbUserName.SelectedIndexChanged += new System.EventHandler(this.lbUserName_SelectedIndexChanged);
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(124, 79);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(436, 32);
            this.label.TabIndex = 2;
            this.label.Text = "Выберите своё имя(псевдоним)";
            // 
            // btOK
            // 
            this.btOK.AccessibleName = "OK";
            this.btOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btOK.Enabled = false;
            this.btOK.Location = new System.Drawing.Point(145, 430);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(304, 46);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "Готово";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btAbort
            // 
            this.btAbort.AccessibleName = "Abort";
            this.btAbort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btAbort.Location = new System.Drawing.Point(145, 482);
            this.btAbort.Name = "btAbort";
            this.btAbort.Size = new System.Drawing.Size(304, 46);
            this.btAbort.TabIndex = 4;
            this.btAbort.Text = "Отмена";
            this.btAbort.UseVisualStyleBackColor = true;
            this.btAbort.Click += new System.EventHandler(this.btAbort_Click);
            // 
            // LoginWindowForTheRegisteredUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 585);
            this.Controls.Add(this.btAbort);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.label);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LoginWindowForTheRegisteredUser";
            this.Text = "RSS-агрегатор новостей";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ListBox lbUserName;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btAbort;
    }
}