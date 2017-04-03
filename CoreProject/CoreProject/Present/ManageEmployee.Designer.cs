namespace CoreProject.Present
{
    partial class ManageEmployee
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserMenu = new System.Windows.Forms.ComboBox();
            this.Select = new System.Windows.Forms.Button();
            this.ModifyPanel = new System.Windows.Forms.Panel();
            this.Submit = new System.Windows.Forms.Button();
            this.Permission = new System.Windows.Forms.ComboBox();
            this.RepeatPass = new System.Windows.Forms.MaskedTextBox();
            this.Password = new System.Windows.Forms.MaskedTextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ModifyWhom = new System.Windows.Forms.Label();
            this.ModifyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(256, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Modify Employee";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(118, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Employee:";
            // 
            // UserMenu
            // 
            this.UserMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserMenu.Font = new System.Drawing.Font("Arial", 12F);
            this.UserMenu.FormattingEnabled = true;
            this.UserMenu.Location = new System.Drawing.Point(356, 201);
            this.UserMenu.Name = "UserMenu";
            this.UserMenu.Size = new System.Drawing.Size(276, 26);
            this.UserMenu.TabIndex = 4;
            // 
            // Select
            // 
            this.Select.Font = new System.Drawing.Font("Arial", 12F);
            this.Select.Location = new System.Drawing.Point(551, 413);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(75, 23);
            this.Select.TabIndex = 5;
            this.Select.Text = "select";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // ModifyPanel
            // 
            this.ModifyPanel.Controls.Add(this.Submit);
            this.ModifyPanel.Controls.Add(this.Permission);
            this.ModifyPanel.Controls.Add(this.RepeatPass);
            this.ModifyPanel.Controls.Add(this.Password);
            this.ModifyPanel.Controls.Add(this.Username);
            this.ModifyPanel.Controls.Add(this.label5);
            this.ModifyPanel.Controls.Add(this.label4);
            this.ModifyPanel.Controls.Add(this.label3);
            this.ModifyPanel.Controls.Add(this.label6);
            this.ModifyPanel.Controls.Add(this.ModifyWhom);
            this.ModifyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifyPanel.Location = new System.Drawing.Point(0, 0);
            this.ModifyPanel.Name = "ModifyPanel";
            this.ModifyPanel.Size = new System.Drawing.Size(783, 486);
            this.ModifyPanel.TabIndex = 6;
            this.ModifyPanel.Visible = false;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(598, 413);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(108, 23);
            this.Submit.TabIndex = 20;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Permission
            // 
            this.Permission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Permission.Font = new System.Drawing.Font("Arial", 12F);
            this.Permission.FormattingEnabled = true;
            this.Permission.Location = new System.Drawing.Point(313, 285);
            this.Permission.Name = "Permission";
            this.Permission.Size = new System.Drawing.Size(233, 26);
            this.Permission.TabIndex = 19;
            // 
            // RepeatPass
            // 
            this.RepeatPass.Font = new System.Drawing.Font("Arial", 12F);
            this.RepeatPass.Location = new System.Drawing.Point(313, 230);
            this.RepeatPass.Name = "RepeatPass";
            this.RepeatPass.Size = new System.Drawing.Size(233, 26);
            this.RepeatPass.TabIndex = 18;
            this.RepeatPass.UseSystemPasswordChar = true;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Arial", 12F);
            this.Password.Location = new System.Drawing.Point(313, 169);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(233, 26);
            this.Password.TabIndex = 17;
            this.Password.UseSystemPasswordChar = true;
            // 
            // Username
            // 
            this.Username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(313, 110);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(233, 26);
            this.Username.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(196, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Permission";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(147, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Repeat Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(196, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "User name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(202, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Password:";
            // 
            // ModifyWhom
            // 
            this.ModifyWhom.AutoSize = true;
            this.ModifyWhom.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyWhom.Location = new System.Drawing.Point(282, 34);
            this.ModifyWhom.Name = "ModifyWhom";
            this.ModifyWhom.Size = new System.Drawing.Size(98, 33);
            this.ModifyWhom.TabIndex = 2;
            this.ModifyWhom.Text = "Modify";
            // 
            // ManageEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(783, 486);
            this.Controls.Add(this.ModifyPanel);
            this.Controls.Add(this.Select);
            this.Controls.Add(this.UserMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ManageEmployee";
            this.Text = "Modify Employee";
            this.Load += new System.EventHandler(this.ManageEmployee_Load);
            this.ModifyPanel.ResumeLayout(false);
            this.ModifyPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UserMenu;
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.Panel ModifyPanel;
        private System.Windows.Forms.Label ModifyWhom;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.ComboBox Permission;
        private System.Windows.Forms.MaskedTextBox RepeatPass;
        private System.Windows.Forms.MaskedTextBox Password;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}