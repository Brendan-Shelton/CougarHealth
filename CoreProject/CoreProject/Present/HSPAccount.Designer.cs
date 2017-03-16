namespace CoreProject.Present
{
    partial class HSPAccount
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CompanyName = new System.Windows.Forms.TextBox();
            this.ServicesOffered = new System.Windows.Forms.CheckedListBox();
            this.BankName = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.Street = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.accountNum = new System.Windows.Forms.MaskedTextBox();
            this.routingNum = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pin = new System.Windows.Forms.MaskedTextBox();
            this.phoneNum = new System.Windows.Forms.MaskedTextBox();
            this.networkStatus = new System.Windows.Forms.CheckBox();
            this.error = new System.Windows.Forms.Label();
            this.finishPane = new System.Windows.Forms.Panel();
            this.thanks = new System.Windows.Forms.Label();
            this.donezo = new System.Windows.Forms.Button();
            this.finishPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Services Offered";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 201);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Personnel Phone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 287);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bank Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 316);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Account Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 319);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Routing Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 252);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "PIN Number";
            // 
            // CompanyName
            // 
            this.CompanyName.Location = new System.Drawing.Point(297, 28);
            this.CompanyName.Margin = new System.Windows.Forms.Padding(2);
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new System.Drawing.Size(216, 20);
            this.CompanyName.TabIndex = 8;
            // 
            // ServicesOffered
            // 
            this.ServicesOffered.ColumnWidth = 205;
            this.ServicesOffered.FormattingEnabled = true;
            this.ServicesOffered.Items.AddRange(new object[] {
            "Inpatient",
            "Inpatient (Behavioral Health)",
            "Emergency Room",
            "Outpatient Surgery",
            "Diagnostic Lab & X-Ray",
            "Physician Office Visits",
            "Specialist Office Visits",
            "Preventitive Services",
            "Baby Care",
            "Durable Medical Equipment",
            "Nursing Facility",
            "Physical Therapy"});
            this.ServicesOffered.Location = new System.Drawing.Point(214, 79);
            this.ServicesOffered.Margin = new System.Windows.Forms.Padding(2);
            this.ServicesOffered.MultiColumn = true;
            this.ServicesOffered.Name = "ServicesOffered";
            this.ServicesOffered.Size = new System.Drawing.Size(348, 109);
            this.ServicesOffered.TabIndex = 9;
            // 
            // BankName
            // 
            this.BankName.Location = new System.Drawing.Point(288, 284);
            this.BankName.Margin = new System.Windows.Forms.Padding(2);
            this.BankName.Name = "BankName";
            this.BankName.Size = new System.Drawing.Size(124, 20);
            this.BankName.TabIndex = 13;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(549, 358);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(56, 19);
            this.Submit.TabIndex = 17;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Street
            // 
            this.Street.Location = new System.Drawing.Point(288, 220);
            this.Street.Margin = new System.Windows.Forms.Padding(2);
            this.Street.Name = "Street";
            this.Street.Size = new System.Drawing.Size(274, 20);
            this.Street.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(118, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(517, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // accountNum
            // 
            this.accountNum.Location = new System.Drawing.Point(288, 316);
            this.accountNum.Mask = "00000000000000000";
            this.accountNum.Name = "accountNum";
            this.accountNum.Size = new System.Drawing.Size(124, 20);
            this.accountNum.TabIndex = 14;
            // 
            // routingNum
            // 
            this.routingNum.Location = new System.Drawing.Point(545, 316);
            this.routingNum.Mask = "000000000";
            this.routingNum.Name = "routingNum";
            this.routingNum.Size = new System.Drawing.Size(60, 20);
            this.routingNum.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(121, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Bank Information (Optional)";
            // 
            // pin
            // 
            this.pin.AsciiOnly = true;
            this.pin.BeepOnError = true;
            this.pin.Location = new System.Drawing.Point(288, 249);
            this.pin.Mask = "00000000000";
            this.pin.Name = "pin";
            this.pin.PasswordChar = '*';
            this.pin.Size = new System.Drawing.Size(124, 20);
            this.pin.TabIndex = 12;
            this.pin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.pin.UseSystemPasswordChar = true;
            // 
            // phoneNum
            // 
            this.phoneNum.Location = new System.Drawing.Point(288, 193);
            this.phoneNum.Mask = "(999) 000-0000";
            this.phoneNum.Name = "phoneNum";
            this.phoneNum.Size = new System.Drawing.Size(124, 20);
            this.phoneNum.TabIndex = 10;
            // 
            // networkStatus
            // 
            this.networkStatus.AutoSize = true;
            this.networkStatus.Location = new System.Drawing.Point(163, 358);
            this.networkStatus.Name = "networkStatus";
            this.networkStatus.Size = new System.Drawing.Size(187, 17);
            this.networkStatus.TabIndex = 16;
            this.networkStatus.Text = "I agree to \"In Network\" maximums";
            this.networkStatus.UseVisualStyleBackColor = true;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Location = new System.Drawing.Point(353, 389);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(39, 13);
            this.error.TabIndex = 29;
            this.error.Text = "errMsg";
            this.error.Visible = false;
            // 
            // finishPane
            // 
            this.finishPane.Controls.Add(this.donezo);
            this.finishPane.Controls.Add(this.thanks);
            this.finishPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishPane.Location = new System.Drawing.Point(0, 0);
            this.finishPane.Name = "finishPane";
            this.finishPane.Size = new System.Drawing.Size(771, 420);
            this.finishPane.TabIndex = 30;
            this.finishPane.Visible = false;
            // 
            // thanks
            // 
            this.thanks.AutoSize = true;
            this.thanks.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanks.Location = new System.Drawing.Point(115, 65);
            this.thanks.Name = "thanks";
            this.thanks.Size = new System.Drawing.Size(280, 31);
            this.thanks.TabIndex = 0;
            this.thanks.Text = "Congratulations you\'ve won";
            // 
            // donezo
            // 
            this.donezo.Location = new System.Drawing.Point(356, 240);
            this.donezo.Name = "donezo";
            this.donezo.Size = new System.Drawing.Size(75, 23);
            this.donezo.TabIndex = 1;
            this.donezo.Text = "Done";
            this.donezo.UseVisualStyleBackColor = true;
            this.donezo.Click += new System.EventHandler(this.donezo_Click);
            // 
            // HSPAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(771, 420);
            this.Controls.Add(this.finishPane);
            this.Controls.Add(this.error);
            this.Controls.Add(this.networkStatus);
            this.Controls.Add(this.phoneNum);
            this.Controls.Add(this.pin);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.routingNum);
            this.Controls.Add(this.accountNum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.BankName);
            this.Controls.Add(this.ServicesOffered);
            this.Controls.Add(this.Street);
            this.Controls.Add(this.CompanyName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HSPAccount";
            this.Text = "HSPAccount";
            this.finishPane.ResumeLayout(false);
            this.finishPane.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CompanyName;
        private System.Windows.Forms.CheckedListBox ServicesOffered;
        private System.Windows.Forms.TextBox BankName;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox Street;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox accountNum;
        private System.Windows.Forms.MaskedTextBox routingNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox pin;
        private System.Windows.Forms.MaskedTextBox phoneNum;
        private System.Windows.Forms.CheckBox networkStatus;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Panel finishPane;
        private System.Windows.Forms.Button donezo;
        private System.Windows.Forms.Label thanks;
    }
}