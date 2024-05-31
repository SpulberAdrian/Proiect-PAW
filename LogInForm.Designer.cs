namespace Proiect_PAW_2
{
    partial class LogInForm
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
            this.loginControl1 = new Proiect_PAW_2.LoginControl();
            this.userControl11 = new Proiect_PAW_2.UserControl1();
            this.SuspendLayout();
            // 
            // loginControl1
            // 
            this.loginControl1.Location = new System.Drawing.Point(39, 36);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Password = "";
            this.loginControl1.Size = new System.Drawing.Size(220, 100);
            this.loginControl1.TabIndex = 0;
            this.loginControl1.Username = "";
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(12, 12);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(75, 18);
            this.userControl11.TabIndex = 1;
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 154);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.loginControl1);
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginControl loginControl1;
        private UserControl1 userControl11;
    }
}