namespace CoreProject.Present
{
    partial class ExpenseReport
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
            this.RangeReportTitle = new System.Windows.Forms.Label();
            this.BeginningDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.BeginningDateLabel = new System.Windows.Forms.Label();
            this.EndingDateLabel = new System.Windows.Forms.Label();
            this.DateSelectSubmitButton = new System.Windows.Forms.Button();
            this.BeginningDateDisplayLabel = new System.Windows.Forms.Label();
            this.dashLineDontChange = new System.Windows.Forms.Label();
            this.EndingDateDisplayLabel = new System.Windows.Forms.Label();
            this.CostsLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BasicPlanLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BasicTotalCostsLabel = new System.Windows.Forms.Label();
            this.ExtendedTotalCostsLabel = new System.Windows.Forms.Label();
            this.BasicPercentLabel = new System.Windows.Forms.Label();
            this.BasicPercNumLabel = new System.Windows.Forms.Label();
            this.ExtendedPercentLabel = new System.Windows.Forms.Label();
            this.ExtendedPercNumLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RangeReportTitle
            // 
            this.RangeReportTitle.AutoSize = true;
            this.RangeReportTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeReportTitle.ForeColor = System.Drawing.Color.White;
            this.RangeReportTitle.Location = new System.Drawing.Point(239, 23);
            this.RangeReportTitle.Name = "RangeReportTitle";
            this.RangeReportTitle.Size = new System.Drawing.Size(180, 25);
            this.RangeReportTitle.TabIndex = 0;
            this.RangeReportTitle.Text = "Expense Report";
            this.RangeReportTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RangeReportTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // BeginningDatePicker
            // 
            this.BeginningDatePicker.Location = new System.Drawing.Point(131, 95);
            this.BeginningDatePicker.Name = "BeginningDatePicker";
            this.BeginningDatePicker.Size = new System.Drawing.Size(182, 20);
            this.BeginningDatePicker.TabIndex = 1;
            this.BeginningDatePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // EndingDatePicker
            // 
            this.EndingDatePicker.Location = new System.Drawing.Point(339, 95);
            this.EndingDatePicker.Name = "EndingDatePicker";
            this.EndingDatePicker.Size = new System.Drawing.Size(179, 20);
            this.EndingDatePicker.TabIndex = 2;
            // 
            // BeginningDateLabel
            // 
            this.BeginningDateLabel.AutoSize = true;
            this.BeginningDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeginningDateLabel.ForeColor = System.Drawing.Color.White;
            this.BeginningDateLabel.Location = new System.Drawing.Point(167, 67);
            this.BeginningDateLabel.Name = "BeginningDateLabel";
            this.BeginningDateLabel.Size = new System.Drawing.Size(94, 13);
            this.BeginningDateLabel.TabIndex = 3;
            this.BeginningDateLabel.Text = "Beginning Date";
            // 
            // EndingDateLabel
            // 
            this.EndingDateLabel.AutoSize = true;
            this.EndingDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndingDateLabel.ForeColor = System.Drawing.Color.White;
            this.EndingDateLabel.Location = new System.Drawing.Point(388, 67);
            this.EndingDateLabel.Name = "EndingDateLabel";
            this.EndingDateLabel.Size = new System.Drawing.Size(77, 13);
            this.EndingDateLabel.TabIndex = 4;
            this.EndingDateLabel.Text = "Ending Date";
            // 
            // DateSelectSubmitButton
            // 
            this.DateSelectSubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DateSelectSubmitButton.Location = new System.Drawing.Point(462, 130);
            this.DateSelectSubmitButton.Name = "DateSelectSubmitButton";
            this.DateSelectSubmitButton.Size = new System.Drawing.Size(56, 20);
            this.DateSelectSubmitButton.TabIndex = 5;
            this.DateSelectSubmitButton.Text = "Submit";
            this.DateSelectSubmitButton.UseVisualStyleBackColor = true;
            this.DateSelectSubmitButton.Click += new System.EventHandler(this.DateSelectSubmitButton_Click);
            // 
            // BeginningDateDisplayLabel
            // 
            this.BeginningDateDisplayLabel.AutoSize = true;
            this.BeginningDateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeginningDateDisplayLabel.ForeColor = System.Drawing.Color.White;
            this.BeginningDateDisplayLabel.Location = new System.Drawing.Point(226, 176);
            this.BeginningDateDisplayLabel.Name = "BeginningDateDisplayLabel";
            this.BeginningDateDisplayLabel.Size = new System.Drawing.Size(45, 13);
            this.BeginningDateDisplayLabel.TabIndex = 6;
            this.BeginningDateDisplayLabel.Text = "Date 1";
            this.BeginningDateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dashLineDontChange
            // 
            this.dashLineDontChange.AutoSize = true;
            this.dashLineDontChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashLineDontChange.Location = new System.Drawing.Point(324, 174);
            this.dashLineDontChange.Name = "dashLineDontChange";
            this.dashLineDontChange.Size = new System.Drawing.Size(13, 16);
            this.dashLineDontChange.TabIndex = 7;
            this.dashLineDontChange.Text = "-";
            // 
            // EndingDateDisplayLabel
            // 
            this.EndingDateDisplayLabel.AutoSize = true;
            this.EndingDateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndingDateDisplayLabel.ForeColor = System.Drawing.Color.White;
            this.EndingDateDisplayLabel.Location = new System.Drawing.Point(374, 176);
            this.EndingDateDisplayLabel.Name = "EndingDateDisplayLabel";
            this.EndingDateDisplayLabel.Size = new System.Drawing.Size(45, 13);
            this.EndingDateDisplayLabel.TabIndex = 8;
            this.EndingDateDisplayLabel.Text = "Date 2";
            this.EndingDateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CostsLabel
            // 
            this.CostsLabel.AutoSize = true;
            this.CostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostsLabel.ForeColor = System.Drawing.Color.White;
            this.CostsLabel.Location = new System.Drawing.Point(131, 192);
            this.CostsLabel.Name = "CostsLabel";
            this.CostsLabel.Size = new System.Drawing.Size(37, 15);
            this.CostsLabel.TabIndex = 9;
            this.CostsLabel.Text = "Costs";
            this.CostsLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(131, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(391, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "________________________________________________________________\r\n";
            // 
            // BasicPlanLabel
            // 
            this.BasicPlanLabel.AutoSize = true;
            this.BasicPlanLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasicPlanLabel.ForeColor = System.Drawing.Color.White;
            this.BasicPlanLabel.Location = new System.Drawing.Point(167, 239);
            this.BasicPlanLabel.Name = "BasicPlanLabel";
            this.BasicPlanLabel.Size = new System.Drawing.Size(261, 13);
            this.BasicPlanLabel.TabIndex = 12;
            this.BasicPlanLabel.Text = "Basic Plan . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
            this.BasicPlanLabel.Click += new System.EventHandler(this.BasicPlanLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(166, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Extended Plan . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
            // 
            // BasicTotalCostsLabel
            // 
            this.BasicTotalCostsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BasicTotalCostsLabel.ForeColor = System.Drawing.Color.White;
            this.BasicTotalCostsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BasicTotalCostsLabel.Location = new System.Drawing.Point(433, 234);
            this.BasicTotalCostsLabel.Name = "BasicTotalCostsLabel";
            this.BasicTotalCostsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BasicTotalCostsLabel.Size = new System.Drawing.Size(88, 23);
            this.BasicTotalCostsLabel.TabIndex = 14;
            this.BasicTotalCostsLabel.Text = "$0.00";
            this.BasicTotalCostsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtendedTotalCostsLabel
            // 
            this.ExtendedTotalCostsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtendedTotalCostsLabel.ForeColor = System.Drawing.Color.White;
            this.ExtendedTotalCostsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExtendedTotalCostsLabel.Location = new System.Drawing.Point(434, 297);
            this.ExtendedTotalCostsLabel.Name = "ExtendedTotalCostsLabel";
            this.ExtendedTotalCostsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ExtendedTotalCostsLabel.Size = new System.Drawing.Size(87, 23);
            this.ExtendedTotalCostsLabel.TabIndex = 15;
            this.ExtendedTotalCostsLabel.Text = "$0.00";
            this.ExtendedTotalCostsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BasicPercentLabel
            // 
            this.BasicPercentLabel.AutoSize = true;
            this.BasicPercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasicPercentLabel.ForeColor = System.Drawing.Color.White;
            this.BasicPercentLabel.Location = new System.Drawing.Point(181, 266);
            this.BasicPercentLabel.Name = "BasicPercentLabel";
            this.BasicPercentLabel.Size = new System.Drawing.Size(246, 13);
            this.BasicPercentLabel.TabIndex = 16;
            this.BasicPercentLabel.Text = "Percent of All Billable Amounts . . . . . . . . . . . . . . . .";
            // 
            // BasicPercNumLabel
            // 
            this.BasicPercNumLabel.ForeColor = System.Drawing.Color.White;
            this.BasicPercNumLabel.Location = new System.Drawing.Point(433, 261);
            this.BasicPercNumLabel.Name = "BasicPercNumLabel";
            this.BasicPercNumLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BasicPercNumLabel.Size = new System.Drawing.Size(88, 23);
            this.BasicPercNumLabel.TabIndex = 17;
            this.BasicPercNumLabel.Text = "0.00";
            this.BasicPercNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtendedPercentLabel
            // 
            this.ExtendedPercentLabel.AutoSize = true;
            this.ExtendedPercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtendedPercentLabel.ForeColor = System.Drawing.Color.White;
            this.ExtendedPercentLabel.Location = new System.Drawing.Point(181, 328);
            this.ExtendedPercentLabel.Name = "ExtendedPercentLabel";
            this.ExtendedPercentLabel.Size = new System.Drawing.Size(246, 13);
            this.ExtendedPercentLabel.TabIndex = 18;
            this.ExtendedPercentLabel.Text = "Percent of All Billable Amounts . . . . . . . . . . . . . . . .";
            // 
            // ExtendedPercNumLabel
            // 
            this.ExtendedPercNumLabel.ForeColor = System.Drawing.Color.White;
            this.ExtendedPercNumLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExtendedPercNumLabel.Location = new System.Drawing.Point(433, 323);
            this.ExtendedPercNumLabel.Name = "ExtendedPercNumLabel";
            this.ExtendedPercNumLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ExtendedPercNumLabel.Size = new System.Drawing.Size(88, 23);
            this.ExtendedPercNumLabel.TabIndex = 19;
            this.ExtendedPercNumLabel.Text = "0.00";
            this.ExtendedPercNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(659, 416);
            this.Controls.Add(this.ExtendedPercNumLabel);
            this.Controls.Add(this.ExtendedPercentLabel);
            this.Controls.Add(this.BasicPercNumLabel);
            this.Controls.Add(this.BasicPercentLabel);
            this.Controls.Add(this.ExtendedTotalCostsLabel);
            this.Controls.Add(this.BasicTotalCostsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BasicPlanLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CostsLabel);
            this.Controls.Add(this.EndingDateDisplayLabel);
            this.Controls.Add(this.dashLineDontChange);
            this.Controls.Add(this.BeginningDateDisplayLabel);
            this.Controls.Add(this.DateSelectSubmitButton);
            this.Controls.Add(this.EndingDateLabel);
            this.Controls.Add(this.BeginningDateLabel);
            this.Controls.Add(this.EndingDatePicker);
            this.Controls.Add(this.BeginningDatePicker);
            this.Controls.Add(this.RangeReportTitle);
            this.Name = "ExpenseReport";
            this.Text = "Expense Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RangeReportTitle;
        private System.Windows.Forms.DateTimePicker BeginningDatePicker;
        private System.Windows.Forms.DateTimePicker EndingDatePicker;
        private System.Windows.Forms.Label BeginningDateLabel;
        private System.Windows.Forms.Label EndingDateLabel;
        private System.Windows.Forms.Button DateSelectSubmitButton;
        private System.Windows.Forms.Label BeginningDateDisplayLabel;
        private System.Windows.Forms.Label dashLineDontChange;
        private System.Windows.Forms.Label EndingDateDisplayLabel;
        private System.Windows.Forms.Label CostsLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label BasicPlanLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BasicTotalCostsLabel;
        private System.Windows.Forms.Label ExtendedTotalCostsLabel;
        private System.Windows.Forms.Label BasicPercentLabel;
        private System.Windows.Forms.Label BasicPercNumLabel;
        private System.Windows.Forms.Label ExtendedPercentLabel;
        private System.Windows.Forms.Label ExtendedPercNumLabel;
    }
}