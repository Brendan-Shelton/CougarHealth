namespace CoreProject.Present
{
    partial class CreateEmployee
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.MaskedTextBox();
            this.RepeatPass = new System.Windows.Forms.MaskedTextBox();
            this.Permission = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Employee Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(210, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(204, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "User name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(155, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Repeat Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(204, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Permission";
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(321, 103);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(233, 26);
            this.Username.TabIndex = 6;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Arial", 12F);
            this.Password.Location = new System.Drawing.Point(321, 162);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(233, 26);
            this.Password.TabIndex = 8;
            this.Password.UseSystemPasswordChar = true;
            // 
            // RepeatPass
            // 
            this.RepeatPass.Font = new System.Drawing.Font("Arial", 12F);
            this.RepeatPass.Location = new System.Drawing.Point(321, 223);
            this.RepeatPass.Name = "RepeatPass";
            this.RepeatPass.Size = new System.Drawing.Size(233, 26);
            this.RepeatPass.TabIndex = 9;
            this.RepeatPass.UseSystemPasswordChar = true;
            // 
            // Permission
            // 
            this.Permission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Permission.Font = new System.Drawing.Font("Arial", 12F);
            this.Permission.FormattingEnabled = true;
            this.Permission.Items.AddRange(new object[] {
            "Plan Admin",
            "Enrollee Support ",
            "HSP Support",
            "Accountant",
            "Manager "});
            this.Permission.Location = new System.Drawing.Point(321, 278);
            this.Permission.Name = "Permission";
            this.Permission.Size = new System.Drawing.Size(233, 26);
            this.Permission.TabIndex = 10;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(606, 406);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(108, 23);
            this.Submit.TabIndex = 11;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // CreateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(783, 486);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Permission);
            this.Controls.Add(this.RepeatPass);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateEmployee";
            this.Text = "Create Employee ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.MaskedTextBox Password;
        private System.Windows.Forms.MaskedTextBox RepeatPass;
        private System.Windows.Forms.ComboBox Permission;
        private System.Windows.Forms.Button Submit;
    }
}