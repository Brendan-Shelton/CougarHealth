namespace CoreProject.Present
{
    partial class ChangeCosts
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
            this.PlanQueries = new System.Windows.Forms.ListBox();
            this.Submit = new System.Windows.Forms.Button();
            this.PlanList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cost = new System.Windows.Forms.NumericUpDown();
            this.PercentLabel = new System.Windows.Forms.Label();
            this.DollarLabel = new System.Windows.Forms.Label();
            this.Percent = new System.Windows.Forms.RadioButton();
            this.MaxPay = new System.Windows.Forms.RadioButton();
            this.Copay = new System.Windows.Forms.RadioButton();
            this.Error = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Cost)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanQueries
            // 
            this.PlanQueries.FormattingEnabled = true;
            this.PlanQueries.ItemHeight = 16;
            this.PlanQueries.Location = new System.Drawing.Point(57, 94);
            this.PlanQueries.Name = "PlanQueries";
            this.PlanQueries.Size = new System.Drawing.Size(227, 116);
            this.PlanQueries.TabIndex = 0;
            this.PlanQueries.SelectedIndexChanged += new System.EventHandler(this.PlanQueries_SelectedIndexChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(57, 319);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 24);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // PlanList
            // 
            this.PlanList.FormattingEnabled = true;
            this.PlanList.ItemHeight = 16;
            this.PlanList.Location = new System.Drawing.Point(290, 94);
            this.PlanList.Name = "PlanList";
            this.PlanList.Size = new System.Drawing.Size(120, 116);
            this.PlanList.TabIndex = 3;
            this.PlanList.SelectedIndexChanged += new System.EventHandler(this.PlanList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "View and Change Costs";
            // 
            // Cost
            // 
            this.Cost.Location = new System.Drawing.Point(57, 216);
            this.Cost.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.Cost.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(120, 22);
            this.Cost.TabIndex = 7;
            // 
            // PercentLabel
            // 
            this.PercentLabel.AutoSize = true;
            this.PercentLabel.Location = new System.Drawing.Point(183, 218);
            this.PercentLabel.Name = "PercentLabel";
            this.PercentLabel.Size = new System.Drawing.Size(20, 17);
            this.PercentLabel.TabIndex = 8;
            this.PercentLabel.Text = "%";
            // 
            // DollarLabel
            // 
            this.DollarLabel.AutoSize = true;
            this.DollarLabel.Location = new System.Drawing.Point(35, 218);
            this.DollarLabel.Name = "DollarLabel";
            this.DollarLabel.Size = new System.Drawing.Size(16, 17);
            this.DollarLabel.TabIndex = 9;
            this.DollarLabel.Text = "$";
            // 
            // Percent
            // 
            this.Percent.AutoSize = true;
            this.Percent.Location = new System.Drawing.Point(57, 244);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(78, 21);
            this.Percent.TabIndex = 10;
            this.Percent.TabStop = true;
            this.Percent.Text = "Percent";
            this.Percent.UseVisualStyleBackColor = true;
            this.Percent.CheckedChanged += new System.EventHandler(this.Percent_CheckedChanged);
            // 
            // MaxPay
            // 
            this.MaxPay.AutoSize = true;
            this.MaxPay.Location = new System.Drawing.Point(57, 268);
            this.MaxPay.Name = "MaxPay";
            this.MaxPay.Size = new System.Drawing.Size(146, 21);
            this.MaxPay.TabIndex = 11;
            this.MaxPay.TabStop = true;
            this.MaxPay.Text = "Maximum Payment";
            this.MaxPay.UseVisualStyleBackColor = true;
            this.MaxPay.CheckedChanged += new System.EventHandler(this.MaxPay_CheckedChanged);
            // 
            // Copay
            // 
            this.Copay.AutoSize = true;
            this.Copay.Location = new System.Drawing.Point(57, 292);
            this.Copay.Name = "Copay";
            this.Copay.Size = new System.Drawing.Size(136, 21);
            this.Copay.TabIndex = 12;
            this.Copay.TabStop = true;
            this.Copay.Text = "Copayment / Fee";
            this.Copay.UseVisualStyleBackColor = true;
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.Location = new System.Drawing.Point(220, 216);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(40, 17);
            this.Error.TabIndex = 13;
            this.Error.Text = "Error";
            // 
            // ChangeCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 357);
            this.Controls.Add(this.Error);
            this.Controls.Add(this.Copay);
            this.Controls.Add(this.MaxPay);
            this.Controls.Add(this.Percent);
            this.Controls.Add(this.DollarLabel);
            this.Controls.Add(this.PercentLabel);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlanList);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.PlanQueries);
            this.Name = "ChangeCosts";
            this.Text = "ChangeCosts";
            ((System.ComponentModel.ISupportInitialize)(this.Cost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PlanQueries;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.ListBox PlanList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Cost;
        private System.Windows.Forms.Label PercentLabel;
        private System.Windows.Forms.Label DollarLabel;
        private System.Windows.Forms.RadioButton Percent;
        private System.Windows.Forms.RadioButton MaxPay;
        private System.Windows.Forms.RadioButton Copay;
        private System.Windows.Forms.Label Error;
    }
}