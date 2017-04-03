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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label11 = new System.Windows.Forms.Label();
            this.InpatientPercentLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.InpatientCopayLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.InpatientBHPercentLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.InpatientBHCopayLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.EmergencyPercentLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.EmergencyCopayLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.OutpatientPercentLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.OutpatientCopayLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.DLXPercentLabel = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.PhysicianPercentLabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.SpecialistPercentLabel = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.PreventivePercentLabel = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.BabyCarePercentLabel = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.DMEPercentLabel = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.NursingPercentLabel = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.PhysicalTherapyPercentLabel = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.OPMRemainingLabel = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.APDRemLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.HSP,
            this.Service,
            this.Amount});
            this.dataGridView1.Location = new System.Drawing.Point(633, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 593);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
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
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
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
            this.totalChargesLabel.Location = new System.Drawing.Point(409, 90);
            this.totalChargesLabel.Name = "totalChargesLabel";
            this.totalChargesLabel.Size = new System.Drawing.Size(35, 13);
            this.totalChargesLabel.TabIndex = 4;
            this.totalChargesLabel.Text = "label3";
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
            this.PYMBLabel.Location = new System.Drawing.Point(381, 135);
            this.PYMBLabel.Name = "PYMBLabel";
            this.PYMBLabel.Size = new System.Drawing.Size(63, 13);
            this.PYMBLabel.TabIndex = 6;
            this.PYMBLabel.Text = "PYMBLabel";
            this.PYMBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.OPMILabel.Location = new System.Drawing.Point(409, 188);
            this.OPMILabel.Name = "OPMILabel";
            this.OPMILabel.Size = new System.Drawing.Size(35, 13);
            this.OPMILabel.TabIndex = 8;
            this.OPMILabel.Text = "label6";
            this.OPMILabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.OPMFLabel.Location = new System.Drawing.Point(409, 205);
            this.OPMFLabel.Name = "OPMFLabel";
            this.OPMFLabel.Size = new System.Drawing.Size(35, 13);
            this.OPMFLabel.TabIndex = 11;
            this.OPMFLabel.Text = "label7";
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
            this.APDLabel.Location = new System.Drawing.Point(409, 254);
            this.APDLabel.Name = "APDLabel";
            this.APDLabel.Size = new System.Drawing.Size(35, 13);
            this.APDLabel.TabIndex = 13;
            this.APDLabel.Text = "label7";
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
            this.label9.Location = new System.Drawing.Point(353, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "/";
            // 
            // PYMBRlabel
            // 
            this.PYMBRlabel.AutoSize = true;
            this.PYMBRlabel.Location = new System.Drawing.Point(312, 135);
            this.PYMBRlabel.Name = "PYMBRlabel";
            this.PYMBRlabel.Size = new System.Drawing.Size(35, 13);
            this.PYMBRlabel.TabIndex = 16;
            this.PYMBRlabel.Text = "label9";
            this.PYMBRlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(73, 339);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Inpatient";
            // 
            // InpatientPercentLabel
            // 
            this.InpatientPercentLabel.AutoSize = true;
            this.InpatientPercentLabel.Location = new System.Drawing.Point(274, 339);
            this.InpatientPercentLabel.Name = "InpatientPercentLabel";
            this.InpatientPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.InpatientPercentLabel.TabIndex = 18;
            this.InpatientPercentLabel.Text = "label12";
            this.InpatientPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(312, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "%  after";
            // 
            // InpatientCopayLabel
            // 
            this.InpatientCopayLabel.AutoSize = true;
            this.InpatientCopayLabel.Location = new System.Drawing.Point(353, 339);
            this.InpatientCopayLabel.Name = "InpatientCopayLabel";
            this.InpatientCopayLabel.Size = new System.Drawing.Size(41, 13);
            this.InpatientCopayLabel.TabIndex = 20;
            this.InpatientCopayLabel.Text = "label13";
            this.InpatientCopayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(407, 339);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Copay";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(73, 362);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Inpatient (Behavioral Health)";
            // 
            // InpatientBHPercentLabel
            // 
            this.InpatientBHPercentLabel.AutoSize = true;
            this.InpatientBHPercentLabel.Location = new System.Drawing.Point(274, 362);
            this.InpatientBHPercentLabel.Name = "InpatientBHPercentLabel";
            this.InpatientBHPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.InpatientBHPercentLabel.TabIndex = 23;
            this.InpatientBHPercentLabel.Text = "label15";
            this.InpatientBHPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(312, 362);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "%  after";
            // 
            // InpatientBHCopayLabel
            // 
            this.InpatientBHCopayLabel.AutoSize = true;
            this.InpatientBHCopayLabel.Location = new System.Drawing.Point(353, 362);
            this.InpatientBHCopayLabel.Name = "InpatientBHCopayLabel";
            this.InpatientBHCopayLabel.Size = new System.Drawing.Size(41, 13);
            this.InpatientBHCopayLabel.TabIndex = 25;
            this.InpatientBHCopayLabel.Text = "label16";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(409, 362);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 26;
            this.label16.Text = "Copay";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(73, 384);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Emergency Room";
            // 
            // EmergencyPercentLabel
            // 
            this.EmergencyPercentLabel.AutoSize = true;
            this.EmergencyPercentLabel.Location = new System.Drawing.Point(274, 384);
            this.EmergencyPercentLabel.Name = "EmergencyPercentLabel";
            this.EmergencyPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.EmergencyPercentLabel.TabIndex = 28;
            this.EmergencyPercentLabel.Text = "label18";
            this.EmergencyPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(312, 384);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "%  after";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(409, 384);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Copay";
            // 
            // EmergencyCopayLabel
            // 
            this.EmergencyCopayLabel.AutoSize = true;
            this.EmergencyCopayLabel.Location = new System.Drawing.Point(353, 384);
            this.EmergencyCopayLabel.Name = "EmergencyCopayLabel";
            this.EmergencyCopayLabel.Size = new System.Drawing.Size(41, 13);
            this.EmergencyCopayLabel.TabIndex = 31;
            this.EmergencyCopayLabel.Text = "label20";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(73, 406);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(113, 13);
            this.label20.TabIndex = 32;
            this.label20.Text = "Outpatient Surgery";
            // 
            // OutpatientPercentLabel
            // 
            this.OutpatientPercentLabel.AutoSize = true;
            this.OutpatientPercentLabel.Location = new System.Drawing.Point(274, 406);
            this.OutpatientPercentLabel.Name = "OutpatientPercentLabel";
            this.OutpatientPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.OutpatientPercentLabel.TabIndex = 33;
            this.OutpatientPercentLabel.Text = "label21";
            this.OutpatientPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(310, 406);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 13);
            this.label21.TabIndex = 34;
            this.label21.Text = "%  after";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(409, 406);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 13);
            this.label22.TabIndex = 35;
            this.label22.Text = "Copay";
            // 
            // OutpatientCopayLabel
            // 
            this.OutpatientCopayLabel.AutoSize = true;
            this.OutpatientCopayLabel.Location = new System.Drawing.Point(353, 406);
            this.OutpatientCopayLabel.Name = "OutpatientCopayLabel";
            this.OutpatientCopayLabel.Size = new System.Drawing.Size(41, 13);
            this.OutpatientCopayLabel.TabIndex = 36;
            this.OutpatientCopayLabel.Text = "label23";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(73, 429);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(155, 13);
            this.label23.TabIndex = 37;
            this.label23.Text = "Diagnostic Lab and X-Ray";
            // 
            // DLXPercentLabel
            // 
            this.DLXPercentLabel.AutoSize = true;
            this.DLXPercentLabel.Location = new System.Drawing.Point(392, 429);
            this.DLXPercentLabel.Name = "DLXPercentLabel";
            this.DLXPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.DLXPercentLabel.TabIndex = 38;
            this.DLXPercentLabel.Text = "label24";
            this.DLXPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(429, 429);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 39;
            this.label24.Text = "%";
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
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(73, 502);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(133, 13);
            this.label26.TabIndex = 41;
            this.label26.Text = "Physician Office Visits";
            // 
            // PhysicianPercentLabel
            // 
            this.PhysicianPercentLabel.AutoSize = true;
            this.PhysicianPercentLabel.Location = new System.Drawing.Point(392, 502);
            this.PhysicianPercentLabel.Name = "PhysicianPercentLabel";
            this.PhysicianPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.PhysicianPercentLabel.TabIndex = 42;
            this.PhysicianPercentLabel.Text = "label27";
            this.PhysicianPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(429, 502);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(15, 13);
            this.label27.TabIndex = 43;
            this.label27.Text = "%";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(73, 526);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(134, 13);
            this.label28.TabIndex = 44;
            this.label28.Text = "Specialist Office Visits";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(429, 526);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 13);
            this.label29.TabIndex = 45;
            this.label29.Text = "%";
            // 
            // SpecialistPercentLabel
            // 
            this.SpecialistPercentLabel.AutoSize = true;
            this.SpecialistPercentLabel.Location = new System.Drawing.Point(392, 526);
            this.SpecialistPercentLabel.Name = "SpecialistPercentLabel";
            this.SpecialistPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.SpecialistPercentLabel.TabIndex = 46;
            this.SpecialistPercentLabel.Text = "label30";
            this.SpecialistPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label30.Location = new System.Drawing.Point(73, 550);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(121, 13);
            this.label30.TabIndex = 47;
            this.label30.Text = "Preventive Services";
            // 
            // PreventivePercentLabel
            // 
            this.PreventivePercentLabel.AutoSize = true;
            this.PreventivePercentLabel.Location = new System.Drawing.Point(392, 550);
            this.PreventivePercentLabel.Name = "PreventivePercentLabel";
            this.PreventivePercentLabel.Size = new System.Drawing.Size(41, 13);
            this.PreventivePercentLabel.TabIndex = 48;
            this.PreventivePercentLabel.Text = "label31";
            this.PreventivePercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(429, 550);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(15, 13);
            this.label32.TabIndex = 49;
            this.label32.Text = "%";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label31.Location = new System.Drawing.Point(73, 573);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 13);
            this.label31.TabIndex = 50;
            this.label31.Text = "Baby Care";
            // 
            // BabyCarePercentLabel
            // 
            this.BabyCarePercentLabel.AutoSize = true;
            this.BabyCarePercentLabel.Location = new System.Drawing.Point(392, 573);
            this.BabyCarePercentLabel.Name = "BabyCarePercentLabel";
            this.BabyCarePercentLabel.Size = new System.Drawing.Size(41, 13);
            this.BabyCarePercentLabel.TabIndex = 51;
            this.BabyCarePercentLabel.Text = "label33";
            this.BabyCarePercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(429, 573);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(15, 13);
            this.label33.TabIndex = 52;
            this.label33.Text = "%";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label34.Location = new System.Drawing.Point(44, 613);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(116, 17);
            this.label34.TabIndex = 53;
            this.label34.Text = "Other Services";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label35.Location = new System.Drawing.Point(73, 643);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(162, 13);
            this.label35.TabIndex = 54;
            this.label35.Text = "Durable Medical Equipment";
            // 
            // DMEPercentLabel
            // 
            this.DMEPercentLabel.AutoSize = true;
            this.DMEPercentLabel.Location = new System.Drawing.Point(392, 643);
            this.DMEPercentLabel.Name = "DMEPercentLabel";
            this.DMEPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.DMEPercentLabel.TabIndex = 55;
            this.DMEPercentLabel.Text = "label36";
            this.DMEPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(429, 643);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(15, 13);
            this.label37.TabIndex = 56;
            this.label37.Text = "%";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label36.Location = new System.Drawing.Point(73, 665);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(94, 13);
            this.label36.TabIndex = 57;
            this.label36.Text = "Nursing Facility";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(429, 665);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(15, 13);
            this.label38.TabIndex = 58;
            this.label38.Text = "%";
            // 
            // NursingPercentLabel
            // 
            this.NursingPercentLabel.AutoSize = true;
            this.NursingPercentLabel.Location = new System.Drawing.Point(392, 665);
            this.NursingPercentLabel.Name = "NursingPercentLabel";
            this.NursingPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.NursingPercentLabel.TabIndex = 59;
            this.NursingPercentLabel.Text = "label39";
            this.NursingPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label39.Location = new System.Drawing.Point(73, 687);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(104, 13);
            this.label39.TabIndex = 60;
            this.label39.Text = "Physical Therapy";
            // 
            // PhysicalTherapyPercentLabel
            // 
            this.PhysicalTherapyPercentLabel.AutoSize = true;
            this.PhysicalTherapyPercentLabel.Location = new System.Drawing.Point(392, 687);
            this.PhysicalTherapyPercentLabel.Name = "PhysicalTherapyPercentLabel";
            this.PhysicalTherapyPercentLabel.Size = new System.Drawing.Size(41, 13);
            this.PhysicalTherapyPercentLabel.TabIndex = 61;
            this.PhysicalTherapyPercentLabel.Text = "label40";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(429, 687);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(15, 13);
            this.label41.TabIndex = 62;
            this.label41.Text = "%";
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
            this.OPMRemainingLabel.Location = new System.Drawing.Point(402, 227);
            this.OPMRemainingLabel.Name = "OPMRemainingLabel";
            this.OPMRemainingLabel.Size = new System.Drawing.Size(41, 13);
            this.OPMRemainingLabel.TabIndex = 64;
            this.OPMRemainingLabel.Text = "label40";
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
            this.APDRemLabel.Location = new System.Drawing.Point(403, 270);
            this.APDRemLabel.Name = "APDRemLabel";
            this.APDRemLabel.Size = new System.Drawing.Size(41, 13);
            this.APDRemLabel.TabIndex = 66;
            this.APDRemLabel.Text = "label42";
            // 
            // EnrolleeCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(1108, 733);
            this.Controls.Add(this.APDRemLabel);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.OPMRemainingLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.PhysicalTherapyPercentLabel);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.NursingPercentLabel);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.DMEPercentLabel);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.BabyCarePercentLabel);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.PreventivePercentLabel);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.SpecialistPercentLabel);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.PhysicianPercentLabel);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.DLXPercentLabel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.OutpatientCopayLabel);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.OutpatientPercentLabel);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.EmergencyCopayLabel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.EmergencyPercentLabel);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.InpatientBHCopayLabel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.InpatientBHPercentLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.InpatientCopayLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.InpatientPercentLabel);
            this.Controls.Add(this.label11);
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "EnrolleeCosts";
            this.Text = "EnrolleeCosts";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label InpatientPercentLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label InpatientCopayLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label InpatientBHPercentLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label InpatientBHCopayLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label EmergencyPercentLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label EmergencyCopayLabel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label OutpatientPercentLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label OutpatientCopayLabel;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label DLXPercentLabel;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label PhysicianPercentLabel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label SpecialistPercentLabel;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label PreventivePercentLabel;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label BabyCarePercentLabel;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label DMEPercentLabel;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label NursingPercentLabel;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label PhysicalTherapyPercentLabel;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label OPMRemainingLabel;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label APDRemLabel;
    }
}