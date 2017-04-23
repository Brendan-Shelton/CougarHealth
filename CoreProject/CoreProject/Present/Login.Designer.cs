namespace CoreProject.Present
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emailLogin = new System.Windows.Forms.TextBox();
            this.pinLogin = new System.Windows.Forms.TextBox();
            this.loginSubmit = new System.Windows.Forms.Button();
            this.errMsg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(56)))));
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(264, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary Enrollee Login ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(56)))));
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(135, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(56)))));
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(150, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pin: ";
            // 
            // emailLogin
            // 
            this.emailLogin.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLogin.Location = new System.Drawing.Point(226, 106);
            this.emailLogin.Name = "emailLogin";
            this.emailLogin.Size = new System.Drawing.Size(318, 35);
            this.emailLogin.TabIndex = 3;
            // 
            // pinLogin
            // 
            this.pinLogin.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinLogin.Location = new System.Drawing.Point(226, 183);
            this.pinLogin.Name = "pinLogin";
            this.pinLogin.Size = new System.Drawing.Size(318, 35);
            this.pinLogin.TabIndex = 4;
            // 
            // loginSubmit
            // 
            this.loginSubmit.Location = new System.Drawing.Point(646, 366);
            this.loginSubmit.Name = "loginSubmit";
            this.loginSubmit.Size = new System.Drawing.Size(75, 23);
            this.loginSubmit.TabIndex = 5;
            this.loginSubmit.Text = "Login";
            this.loginSubmit.UseVisualStyleBackColor = true;
            this.loginSubmit.Click += new System.EventHandler(this.loginSubmit_Click);
            // 
            // errMsg
            // 
            this.errMsg.AutoSize = true;
            this.errMsg.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errMsg.ForeColor = System.Drawing.Color.White;
            this.errMsg.Location = new System.Drawing.Point(324, 330);
            this.errMsg.Name = "errMsg";
            this.errMsg.Size = new System.Drawing.Size(51, 20);
            this.errMsg.TabIndex = 6;
            this.errMsg.Text = "errMsg";
            this.errMsg.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(243, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dr Mayer: Login as email: guest@guest password: 1234";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(771, 420);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.errMsg);
            this.Controls.Add(this.loginSubmit);
            this.Controls.Add(this.pinLogin);
            this.Controls.Add(this.emailLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailLogin;
        private System.Windows.Forms.TextBox pinLogin;
        private System.Windows.Forms.Button loginSubmit;
        private System.Windows.Forms.Label errMsg;
        private System.Windows.Forms.Label label4;
    }
}