namespace TEXTWRITER_2._0
{
    partial class FeedBack
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(63, 69);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(296, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(63, 95);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(296, 20);
            this.textBoxSubject.TabIndex = 1;
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(11, 121);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(348, 143);
            this.textBoxBody.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(11, 69);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(46, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "От кого";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(11, 95);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(46, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "Тема";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(269, 270);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 5;
            this.buttonSubmit.Text = "Отправить";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // FeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 298);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.textBoxName);
            this.Name = "FeedBack";
            this.Text = "FeedBack";
            this.Load += new System.EventHandler(this.FeedBack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button buttonSubmit;
    }
}