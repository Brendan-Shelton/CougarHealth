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
            this.PlanQueries.Location = new System.Drawing.Point(43, 76);
            this.PlanQueries.Margin = new System.Windows.Forms.Padding(2);
            this.PlanQueries.Name = "PlanQueries";
            this.PlanQueries.Size = new System.Drawing.Size(171, 95);
            this.PlanQueries.TabIndex = 0;
            this.PlanQueries.SelectedIndexChanged += new System.EventHandler(this.PlanQueries_SelectedIndexChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(43, 259);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(56, 20);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // PlanList
            // 
            this.PlanList.FormattingEnabled = true;
            this.PlanList.Location = new System.Drawing.Point(218, 76);
            this.PlanList.Margin = new System.Windows.Forms.Padding(2);
            this.PlanList.Name = "PlanList";
            this.PlanList.Size = new System.Drawing.Size(91, 95);
            this.PlanList.TabIndex = 3;
            this.PlanList.SelectedIndexChanged += new System.EventHandler(this.PlanList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "View and Change Costs";
            // 
            // Cost
            // 
            this.Cost.Location = new System.Drawing.Point(43, 176);
            this.Cost.Margin = new System.Windows.Forms.Padding(2);
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
            this.Cost.Size = new System.Drawing.Size(90, 20);
            this.Cost.TabIndex = 7;
            // 
            // PercentLabel
            // 
            this.PercentLabel.AutoSize = true;
            this.PercentLabel.ForeColor = System.Drawing.Color.White;
            this.PercentLabel.Location = new System.Drawing.Point(137, 177);
            this.PercentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PercentLabel.Name = "PercentLabel";
            this.PercentLabel.Size = new System.Drawing.Size(15, 13);
            this.PercentLabel.TabIndex = 8;
            this.PercentLabel.Text = "%";
            // 
            // DollarLabel
            // 
            this.DollarLabel.AutoSize = true;
            this.DollarLabel.ForeColor = System.Drawing.Color.White;
            this.DollarLabel.Location = new System.Drawing.Point(26, 177);
            this.DollarLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DollarLabel.Name = "DollarLabel";
            this.DollarLabel.Size = new System.Drawing.Size(13, 13);
            this.DollarLabel.TabIndex = 9;
            this.DollarLabel.Text = "$";
            // 
            // Percent
            // 
            this.Percent.AutoSize = true;
            this.Percent.ForeColor = System.Drawing.Color.White;
            this.Percent.Location = new System.Drawing.Point(43, 198);
            this.Percent.Margin = new System.Windows.Forms.Padding(2);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(62, 17);
            this.Percent.TabIndex = 10;
            this.Percent.TabStop = true;
            this.Percent.Text = "Percent";
            this.Percent.UseVisualStyleBackColor = true;
            this.Percent.CheckedChanged += new System.EventHandler(this.Percent_CheckedChanged);
            // 
            // MaxPay
            // 
            this.MaxPay.AutoSize = true;
            this.MaxPay.ForeColor = System.Drawing.Color.White;
            this.MaxPay.Location = new System.Drawing.Point(43, 218);
            this.MaxPay.Margin = new System.Windows.Forms.Padding(2);
            this.MaxPay.Name = "MaxPay";
            this.MaxPay.Size = new System.Drawing.Size(113, 17);
            this.MaxPay.TabIndex = 11;
            this.MaxPay.TabStop = true;
            this.MaxPay.Text = "Maximum Payment";
            this.MaxPay.UseVisualStyleBackColor = true;
            this.MaxPay.CheckedChanged += new System.EventHandler(this.MaxPay_CheckedChanged);
            // 
            // Copay
            // 
            this.Copay.AutoSize = true;
            this.Copay.ForeColor = System.Drawing.Color.White;
            this.Copay.Location = new System.Drawing.Point(43, 237);
            this.Copay.Margin = new System.Windows.Forms.Padding(2);
            this.Copay.Name = "Copay";
            this.Copay.Size = new System.Drawing.Size(107, 17);
            this.Copay.TabIndex = 12;
            this.Copay.TabStop = true;
            this.Copay.Text = "Copayment / Fee";
            this.Copay.UseVisualStyleBackColor = true;
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.ForeColor = System.Drawing.Color.White;
            this.Error.Location = new System.Drawing.Point(165, 176);
            this.Error.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(29, 13);
            this.Error.TabIndex = 13;
            this.Error.Text = "Error";
            // 
            // ChangeCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(356, 290);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChangeCosts";
            this.Text = "Change Costs";
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