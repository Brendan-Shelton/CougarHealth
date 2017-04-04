namespace CoreProject.Present
{
    partial class EnrolleeCosts
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
            this.BillsListView = new System.Windows.Forms.DataGridView();
            this.chargesLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalChargesLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PYMBLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OPMILabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OPMFLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.APDLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PYMBRlabel = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.OPMRemainingLabel = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.APDRemLabel = new System.Windows.Forms.Label();
            this.HospitalListBox = new System.Windows.Forms.ListBox();
            this.PhysicianListBox = new System.Windows.Forms.ListBox();
            this.OtherListBox = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountBilled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalBillAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BillsListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCoral;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(38, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enrollee Plan and Costs";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BillsListView
            // 
            this.BillsListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillsListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.HSP,
            this.Service,
            this.AmountBilled,
            this.TotalBillAmount});
            this.BillsListView.Location = new System.Drawing.Point(498, 107);
            this.BillsListView.Name = "BillsListView";
            this.BillsListView.Size = new System.Drawing.Size(578, 593);
            this.BillsListView.TabIndex = 1;
            this.BillsListView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // chargesLabel
            // 
            this.chargesLabel.AutoSize = true;
            this.chargesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.chargesLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.chargesLabel.Location = new System.Drawing.Point(40, 85);
            this.chargesLabel.Name = "chargesLabel";
            this.chargesLabel.Size = new System.Drawing.Size(126, 20);
            this.chargesLabel.TabIndex = 2;
            this.chargesLabel.Text = "Total Charges:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 3;
            // 
            // totalChargesLabel
            // 
            this.totalChargesLabel.AutoSize = true;
            this.totalChargesLabel.Location = new System.Drawing.Point(432, 90);
            this.totalChargesLabel.Name = "totalChargesLabel";
            this.totalChargesLabel.Size = new System.Drawing.Size(29, 13);
            this.totalChargesLabel.TabIndex = 4;
            this.totalChargesLabel.Text = "label";
            this.totalChargesLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(41, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Plan Year Maximum Benefit Remaining:";
            // 
            // PYMBLabel
            // 
            this.PYMBLabel.AutoSize = true;
            this.PYMBLabel.Location = new System.Drawing.Point(432, 135);
            this.PYMBLabel.Name = "PYMBLabel";
            this.PYMBLabel.Size = new System.Drawing.Size(29, 13);
            this.PYMBLabel.TabIndex = 6;
            this.PYMBLabel.Text = "label";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(41, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Out of Pocket Maximum:";
            // 
            // OPMILabel
            // 
            this.OPMILabel.AutoSize = true;
            this.OPMILabel.Location = new System.Drawing.Point(432, 188);
            this.OPMILabel.Name = "OPMILabel";
            this.OPMILabel.Size = new System.Drawing.Size(29, 13);
            this.OPMILabel.TabIndex = 8;
            this.OPMILabel.Text = "label";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(73, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "- Per Individual";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(73, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "- Per Family";
            // 
            // OPMFLabel
            // 
            this.OPMFLabel.AutoSize = true;
            this.OPMFLabel.Location = new System.Drawing.Point(432, 205);
            this.OPMFLabel.Name = "OPMFLabel";
            this.OPMFLabel.Size = new System.Drawing.Size(29, 13);
            this.OPMFLabel.TabIndex = 11;
            this.OPMFLabel.Text = "label";
            this.OPMFLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(41, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Annual Plan Deductible";
            // 
            // APDLabel
            // 
            this.APDLabel.AutoSize = true;
            this.APDLabel.Location = new System.Drawing.Point(432, 254);
            this.APDLabel.Name = "APDLabel";
            this.APDLabel.Size = new System.Drawing.Size(29, 13);
            this.APDLabel.TabIndex = 13;
            this.APDLabel.Text = "label";
            this.APDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(41, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Hospital Services";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(398, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "/";
            // 
            // PYMBRlabel
            // 
            this.PYMBRlabel.AutoSize = true;
            this.PYMBRlabel.Location = new System.Drawing.Point(304, 135);
            this.PYMBRlabel.Name = "PYMBRlabel";
            this.PYMBRlabel.Size = new System.Drawing.Size(35, 13);
            this.PYMBRlabel.TabIndex = 16;
            this.PYMBRlabel.Text = "label9";
            this.PYMBRlabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label25.Location = new System.Drawing.Point(41, 473);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(144, 17);
            this.label25.TabIndex = 40;
            this.label25.Text = "Physician Services";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label34.Location = new System.Drawing.Point(44, 623);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(116, 17);
            this.label34.TabIndex = 53;
            this.label34.Text = "Other Services";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(81, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "Remaining";
            // 
            // OPMRemainingLabel
            // 
            this.OPMRemainingLabel.AutoSize = true;
            this.OPMRemainingLabel.Location = new System.Drawing.Point(432, 227);
            this.OPMRemainingLabel.Name = "OPMRemainingLabel";
            this.OPMRemainingLabel.Size = new System.Drawing.Size(29, 13);
            this.OPMRemainingLabel.TabIndex = 64;
            this.OPMRemainingLabel.Text = "label";
            this.OPMRemainingLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label40.Location = new System.Drawing.Point(84, 270);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(66, 13);
            this.label40.TabIndex = 65;
            this.label40.Text = "Remaining";
            // 
            // APDRemLabel
            // 
            this.APDRemLabel.AutoSize = true;
            this.APDRemLabel.Location = new System.Drawing.Point(432, 270);
            this.APDRemLabel.Name = "APDRemLabel";
            this.APDRemLabel.Size = new System.Drawing.Size(29, 13);
            this.APDRemLabel.TabIndex = 66;
            this.APDRemLabel.Text = "label";
            this.APDRemLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // HospitalListBox
            // 
            this.HospitalListBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HospitalListBox.FormattingEnabled = true;
            this.HospitalListBox.Location = new System.Drawing.Point(47, 341);
            this.HospitalListBox.Name = "HospitalListBox";
            this.HospitalListBox.Size = new System.Drawing.Size(414, 108);
            this.HospitalListBox.TabIndex = 67;
            // 
            // PhysicianListBox
            // 
            this.PhysicianListBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhysicianListBox.FormattingEnabled = true;
            this.PhysicianListBox.Location = new System.Drawing.Point(47, 507);
            this.PhysicianListBox.Name = "PhysicianListBox";
            this.PhysicianListBox.Size = new System.Drawing.Size(414, 95);
            this.PhysicianListBox.TabIndex = 68;
            // 
            // OtherListBox
            // 
            this.OtherListBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherListBox.FormattingEnabled = true;
            this.OtherListBox.Location = new System.Drawing.Point(47, 659);
            this.OtherListBox.Name = "OtherListBox";
            this.OtherListBox.Size = new System.Drawing.Size(414, 95);
            this.OtherListBox.TabIndex = 69;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(44, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "Policy Number: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(140, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 71;
            this.label12.Text = "label12";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // HSP
            // 
            this.HSP.DataPropertyName = "HSP";
            this.HSP.HeaderText = "HSP";
            this.HSP.Name = "HSP";
            // 
            // Service
            // 
            this.Service.HeaderText = "Service";
            this.Service.Name = "Service";
            // 
            // AmountBilled
            // 
            this.AmountBilled.HeaderText = "Amount Billed";
            this.AmountBilled.Name = "AmountBilled";
            // 
            // TotalBillAmount
            // 
            this.TotalBillAmount.HeaderText = "Total Bill Amount";
            this.TotalBillAmount.Name = "TotalBillAmount";
            // 
            // EnrolleeCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(1108, 790);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.OtherListBox);
            this.Controls.Add(this.PhysicianListBox);
            this.Controls.Add(this.HospitalListBox);
            this.Controls.Add(this.APDRemLabel);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.OPMRemainingLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.PYMBRlabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.APDLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OPMFLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OPMILabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PYMBLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalChargesLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chargesLabel);
            this.Controls.Add(this.BillsListView);
            this.Controls.Add(this.label1);
            this.Name = "EnrolleeCosts";
            this.Text = "EnrolleeCosts";
            ((System.ComponentModel.ISupportInitialize)(this.BillsListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView BillsListView;
        private System.Windows.Forms.Label chargesLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalChargesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PYMBLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label OPMILabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label OPMFLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label APDLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label PYMBRlabel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label OPMRemainingLabel;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label APDRemLabel;
        private System.Windows.Forms.ListBox HospitalListBox;
        private System.Windows.Forms.ListBox PhysicianListBox;
        private System.Windows.Forms.ListBox OtherListBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountBilled;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBillAmount;
    }
}