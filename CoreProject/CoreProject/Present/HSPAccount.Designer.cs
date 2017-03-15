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
            this.Street = new System.Windows.Forms.TextBox();
            this.City = new System.Windows.Forms.TextBox();
            this.State = new System.Windows.Forms.ComboBox();
            this.ServicesOffered = new System.Windows.Forms.CheckedListBox();
            this.BankName = new System.Windows.Forms.TextBox();
            this.AccountNum = new System.Windows.Forms.NumericUpDown();
            this.RoutingNum = new System.Windows.Forms.NumericUpDown();
            this.Pin = new System.Windows.Forms.TextBox();
            this.Zip = new System.Windows.Forms.NumericUpDown();
            this.Submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoutingNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zip)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Services Offered";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Personnel Contact Info (??)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bank Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Account Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Routing Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "PIN Number";
            // 
            // CompanyName
            // 
            this.CompanyName.Location = new System.Drawing.Point(160, 28);
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new System.Drawing.Size(287, 22);
            this.CompanyName.TabIndex = 8;
            // 
            // Street
            // 
            this.Street.Location = new System.Drawing.Point(160, 263);
            this.Street.Name = "Street";
            this.Street.Size = new System.Drawing.Size(352, 22);
            this.Street.TabIndex = 9;
            this.Street.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // City
            // 
            this.City.Location = new System.Drawing.Point(160, 291);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(134, 22);
            this.City.TabIndex = 10;
            // 
            // State
            // 
            this.State.FormattingEnabled = true;
            this.State.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "DC",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.State.Location = new System.Drawing.Point(328, 289);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(42, 24);
            this.State.TabIndex = 11;
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
            this.ServicesOffered.Location = new System.Drawing.Point(49, 91);
            this.ServicesOffered.MultiColumn = true;
            this.ServicesOffered.Name = "ServicesOffered";
            this.ServicesOffered.Size = new System.Drawing.Size(463, 140);
            this.ServicesOffered.TabIndex = 12;
            // 
            // BankName
            // 
            this.BankName.Location = new System.Drawing.Point(160, 351);
            this.BankName.Name = "BankName";
            this.BankName.Size = new System.Drawing.Size(164, 22);
            this.BankName.TabIndex = 14;
            // 
            // AccountNum
            // 
            this.AccountNum.Location = new System.Drawing.Point(160, 381);
            this.AccountNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.AccountNum.Name = "AccountNum";
            this.AccountNum.Size = new System.Drawing.Size(120, 22);
            this.AccountNum.TabIndex = 17;
            // 
            // RoutingNum
            // 
            this.RoutingNum.Location = new System.Drawing.Point(403, 379);
            this.RoutingNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.RoutingNum.Name = "RoutingNum";
            this.RoutingNum.Size = new System.Drawing.Size(109, 22);
            this.RoutingNum.TabIndex = 18;
            // 
            // Pin
            // 
            this.Pin.Location = new System.Drawing.Point(160, 319);
            this.Pin.Name = "Pin";
            this.Pin.Size = new System.Drawing.Size(79, 22);
            this.Pin.TabIndex = 19;
            // 
            // Zip
            // 
            this.Zip.Location = new System.Drawing.Point(403, 292);
            this.Zip.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Zip.Name = "Zip";
            this.Zip.Size = new System.Drawing.Size(109, 22);
            this.Zip.TabIndex = 20;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(437, 410);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 21;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // HSPAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 445);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Zip);
            this.Controls.Add(this.Pin);
            this.Controls.Add(this.RoutingNum);
            this.Controls.Add(this.AccountNum);
            this.Controls.Add(this.BankName);
            this.Controls.Add(this.ServicesOffered);
            this.Controls.Add(this.State);
            this.Controls.Add(this.City);
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
            this.Name = "HSPAccount";
            this.Text = "HSPAccount";
            ((System.ComponentModel.ISupportInitialize)(this.AccountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoutingNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zip)).EndInit();
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
        private System.Windows.Forms.TextBox Street;
        private System.Windows.Forms.TextBox City;
        private System.Windows.Forms.ComboBox State;
        private System.Windows.Forms.CheckedListBox ServicesOffered;
        private System.Windows.Forms.TextBox BankName;
        private System.Windows.Forms.NumericUpDown AccountNum;
        private System.Windows.Forms.NumericUpDown RoutingNum;
        private System.Windows.Forms.TextBox Pin;
        private System.Windows.Forms.NumericUpDown Zip;
        private System.Windows.Forms.Button Submit;
    }
}