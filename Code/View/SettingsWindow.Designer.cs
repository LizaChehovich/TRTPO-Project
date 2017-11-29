namespace RSS_Reader.View
{
    partial class SettingsWindow
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
            this.gbResourses = new System.Windows.Forms.GroupBox();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.gbInclude = new System.Windows.Forms.GroupBox();
            this.gbExclude = new System.Windows.Forms.GroupBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btAbort = new System.Windows.Forms.Button();
            this.lbResourses = new System.Windows.Forms.ListBox();
            this.btRemRes = new System.Windows.Forms.Button();
            this.btAddRes = new System.Windows.Forms.Button();
            this.btRemInc = new System.Windows.Forms.Button();
            this.btAddInc = new System.Windows.Forms.Button();
            this.lbInclude = new System.Windows.Forms.ListBox();
            this.btRemExc = new System.Windows.Forms.Button();
            this.btAddExc = new System.Windows.Forms.Button();
            this.lbExclude = new System.Windows.Forms.ListBox();
            this.menuStrip.SuspendLayout();
            this.gbResourses.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.gbInclude.SuspendLayout();
            this.gbExclude.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(1014, 40);
            this.menuStrip.TabIndex = 5;
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(119, 36);
            this.HelpToolStripMenuItem.Text = "Справка";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // gbResourses
            // 
            this.gbResourses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbResourses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbResourses.Controls.Add(this.btRemRes);
            this.gbResourses.Controls.Add(this.btAddRes);
            this.gbResourses.Controls.Add(this.lbResourses);
            this.gbResourses.Location = new System.Drawing.Point(13, 44);
            this.gbResourses.Name = "gbResourses";
            this.gbResourses.Size = new System.Drawing.Size(313, 553);
            this.gbResourses.TabIndex = 6;
            this.gbResourses.TabStop = false;
            this.gbResourses.Text = "Ресурсы";
            // 
            // gbFilters
            // 
            this.gbFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFilters.Controls.Add(this.gbExclude);
            this.gbFilters.Controls.Add(this.gbInclude);
            this.gbFilters.Location = new System.Drawing.Point(332, 44);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(670, 478);
            this.gbFilters.TabIndex = 7;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = " Фильтры";
            // 
            // gbInclude
            // 
            this.gbInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbInclude.Controls.Add(this.btRemInc);
            this.gbInclude.Controls.Add(this.btAddInc);
            this.gbInclude.Controls.Add(this.lbInclude);
            this.gbInclude.Location = new System.Drawing.Point(20, 33);
            this.gbInclude.Name = "gbInclude";
            this.gbInclude.Size = new System.Drawing.Size(313, 429);
            this.gbInclude.TabIndex = 0;
            this.gbInclude.TabStop = false;
            this.gbInclude.Text = "Включить";
            // 
            // gbExclude
            // 
            this.gbExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExclude.Controls.Add(this.btRemExc);
            this.gbExclude.Controls.Add(this.btAddExc);
            this.gbExclude.Controls.Add(this.lbExclude);
            this.gbExclude.Location = new System.Drawing.Point(339, 33);
            this.gbExclude.Name = "gbExclude";
            this.gbExclude.Size = new System.Drawing.Size(313, 429);
            this.gbExclude.TabIndex = 1;
            this.gbExclude.TabStop = false;
            this.gbExclude.Text = "Исключить";
            // 
            // btOK
            // 
            this.btOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btOK.Location = new System.Drawing.Point(492, 548);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(155, 49);
            this.btOK.TabIndex = 8;
            this.btOK.Text = "Сохранить";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btAbort
            // 
            this.btAbort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btAbort.Location = new System.Drawing.Point(688, 548);
            this.btAbort.Name = "btAbort";
            this.btAbort.Size = new System.Drawing.Size(155, 49);
            this.btAbort.TabIndex = 9;
            this.btAbort.Text = "Отмена";
            this.btAbort.UseVisualStyleBackColor = true;
            this.btAbort.Click += new System.EventHandler(this.btAbort_Click);
            // 
            // lbResourses
            // 
            this.lbResourses.FormattingEnabled = true;
            this.lbResourses.ItemHeight = 29;
            this.lbResourses.Location = new System.Drawing.Point(18, 44);
            this.lbResourses.Name = "lbResourses";
            this.lbResourses.Size = new System.Drawing.Size(278, 410);
            this.lbResourses.TabIndex = 0;
            // 
            // btRemRes
            // 
            this.btRemRes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btRemRes.Location = new System.Drawing.Point(160, 487);
            this.btRemRes.Name = "btRemRes";
            this.btRemRes.Size = new System.Drawing.Size(136, 49);
            this.btRemRes.TabIndex = 11;
            this.btRemRes.Text = "Удалить";
            this.btRemRes.UseVisualStyleBackColor = true;
            this.btRemRes.Click += new System.EventHandler(this.btRemRes_Click);
            // 
            // btAddRes
            // 
            this.btAddRes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btAddRes.Location = new System.Drawing.Point(18, 487);
            this.btAddRes.Name = "btAddRes";
            this.btAddRes.Size = new System.Drawing.Size(136, 49);
            this.btAddRes.TabIndex = 10;
            this.btAddRes.Text = "Добавить";
            this.btAddRes.UseVisualStyleBackColor = true;
            this.btAddRes.Click += new System.EventHandler(this.btAddRes_Click);
            // 
            // btRemInc
            // 
            this.btRemInc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btRemInc.Location = new System.Drawing.Point(159, 364);
            this.btRemInc.Name = "btRemInc";
            this.btRemInc.Size = new System.Drawing.Size(136, 49);
            this.btRemInc.TabIndex = 14;
            this.btRemInc.Text = "Удалить";
            this.btRemInc.UseVisualStyleBackColor = true;
            this.btRemInc.Click += new System.EventHandler(this.btRemInc_Click);
            // 
            // btAddInc
            // 
            this.btAddInc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btAddInc.Location = new System.Drawing.Point(17, 364);
            this.btAddInc.Name = "btAddInc";
            this.btAddInc.Size = new System.Drawing.Size(136, 49);
            this.btAddInc.TabIndex = 13;
            this.btAddInc.Text = "Добавить";
            this.btAddInc.UseVisualStyleBackColor = true;
            this.btAddInc.Click += new System.EventHandler(this.btAddInc_Click);
            // 
            // lbInclude
            // 
            this.lbInclude.FormattingEnabled = true;
            this.lbInclude.ItemHeight = 29;
            this.lbInclude.Location = new System.Drawing.Point(17, 35);
            this.lbInclude.Name = "lbInclude";
            this.lbInclude.Size = new System.Drawing.Size(278, 294);
            this.lbInclude.TabIndex = 12;
            // 
            // btRemExc
            // 
            this.btRemExc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btRemExc.Location = new System.Drawing.Point(159, 364);
            this.btRemExc.Name = "btRemExc";
            this.btRemExc.Size = new System.Drawing.Size(136, 49);
            this.btRemExc.TabIndex = 17;
            this.btRemExc.Text = "Удалить";
            this.btRemExc.UseVisualStyleBackColor = true;
            this.btRemExc.Click += new System.EventHandler(this.btRemExc_Click);
            // 
            // btAddExc
            // 
            this.btAddExc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btAddExc.Location = new System.Drawing.Point(17, 364);
            this.btAddExc.Name = "btAddExc";
            this.btAddExc.Size = new System.Drawing.Size(136, 49);
            this.btAddExc.TabIndex = 16;
            this.btAddExc.Text = "Добавить";
            this.btAddExc.UseVisualStyleBackColor = true;
            this.btAddExc.Click += new System.EventHandler(this.btAddExc_Click);
            // 
            // lbExclude
            // 
            this.lbExclude.FormattingEnabled = true;
            this.lbExclude.ItemHeight = 29;
            this.lbExclude.Location = new System.Drawing.Point(17, 35);
            this.lbExclude.Name = "lbExclude";
            this.lbExclude.Size = new System.Drawing.Size(278, 294);
            this.lbExclude.TabIndex = 15;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 609);
            this.ControlBox = false;
            this.Controls.Add(this.btAbort);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.gbResourses);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "SettingsWindow";
            this.Text = "Настойка профиля";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gbResourses.ResumeLayout(false);
            this.gbFilters.ResumeLayout(false);
            this.gbInclude.ResumeLayout(false);
            this.gbExclude.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbResourses;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.GroupBox gbExclude;
        private System.Windows.Forms.GroupBox gbInclude;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btAbort;
        private System.Windows.Forms.Button btRemRes;
        private System.Windows.Forms.Button btAddRes;
        private System.Windows.Forms.ListBox lbResourses;
        private System.Windows.Forms.Button btRemExc;
        private System.Windows.Forms.Button btAddExc;
        private System.Windows.Forms.ListBox lbExclude;
        private System.Windows.Forms.Button btRemInc;
        private System.Windows.Forms.Button btAddInc;
        private System.Windows.Forms.ListBox lbInclude;
    }
}