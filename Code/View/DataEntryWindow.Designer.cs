namespace RSS_Reader.View
{
    partial class DataEntryWindow
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
            this.btAbort = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btAbort
            // 
            this.btAbort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btAbort.Location = new System.Drawing.Point(228, 117);
            this.btAbort.Name = "btAbort";
            this.btAbort.Size = new System.Drawing.Size(136, 49);
            this.btAbort.TabIndex = 16;
            this.btAbort.Text = "Отмена";
            this.btAbort.UseVisualStyleBackColor = true;
            this.btAbort.Click += new System.EventHandler(this.btAbort_Click);
            // 
            // btOK
            // 
            this.btOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btOK.Enabled = false;
            this.btOK.Location = new System.Drawing.Point(86, 117);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(136, 49);
            this.btOK.TabIndex = 15;
            this.btOK.Text = "Готово";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(26, 44);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(409, 34);
            this.tbResult.TabIndex = 17;
            this.tbResult.TextChanged += new System.EventHandler(this.tbResult_TextChanged);
            // 
            // DataEntryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 178);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btAbort);
            this.Controls.Add(this.btOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DataEntryWindow";
            this.Text = "Добавление элемента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAbort;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.TextBox tbResult;
    }
}