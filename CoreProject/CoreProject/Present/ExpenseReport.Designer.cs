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
            this.RangeDataTitle = new System.Windows.Forms.Label();
            this.BeginningDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.BeginningDateLabel = new System.Windows.Forms.Label();
            this.EndingDateLabel = new System.Windows.Forms.Label();
            this.DateSelectSubmitButton = new System.Windows.Forms.Button();
            this.BeginningDateDisplayLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EndingDateDisplayLabel = new System.Windows.Forms.Label();
            this.CostsLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BasicCostsView = new System.Windows.Forms.DataGridView();
            this.Basic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BasicCostsView)).BeginInit();
            this.SuspendLayout();
            // 
            // RangeDataTitle
            // 
            this.RangeDataTitle.AutoSize = true;
            this.RangeDataTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeDataTitle.Location = new System.Drawing.Point(224, 25);
            this.RangeDataTitle.Name = "RangeDataTitle";
            this.RangeDataTitle.Size = new System.Drawing.Size(180, 25);
            this.RangeDataTitle.TabIndex = 0;
            this.RangeDataTitle.Text = "Expense Report";
            this.RangeDataTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RangeDataTitle.Click += new System.EventHandler(this.label1_Click);
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
            this.EndingDateLabel.Location = new System.Drawing.Point(388, 67);
            this.EndingDateLabel.Name = "EndingDateLabel";
            this.EndingDateLabel.Size = new System.Drawing.Size(77, 13);
            this.EndingDateLabel.TabIndex = 4;
            this.EndingDateLabel.Text = "Ending Date";
            // 
            // DateSelectSubmitButton
            // 
            this.DateSelectSubmitButton.Location = new System.Drawing.Point(462, 130);
            this.DateSelectSubmitButton.Name = "DateSelectSubmitButton";
            this.DateSelectSubmitButton.Size = new System.Drawing.Size(56, 20);
            this.DateSelectSubmitButton.TabIndex = 5;
            this.DateSelectSubmitButton.Text = "Submit";
            this.DateSelectSubmitButton.UseVisualStyleBackColor = true;
            // 
            // BeginningDateDisplayLabel
            // 
            this.BeginningDateDisplayLabel.AutoSize = true;
            this.BeginningDateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeginningDateDisplayLabel.Location = new System.Drawing.Point(248, 154);
            this.BeginningDateDisplayLabel.Name = "BeginningDateDisplayLabel";
            this.BeginningDateDisplayLabel.Size = new System.Drawing.Size(45, 13);
            this.BeginningDateDisplayLabel.TabIndex = 6;
            this.BeginningDateDisplayLabel.Text = "Date 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "-";
            // 
            // EndingDateDisplayLabel
            // 
            this.EndingDateDisplayLabel.AutoSize = true;
            this.EndingDateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndingDateDisplayLabel.Location = new System.Drawing.Point(369, 154);
            this.EndingDateDisplayLabel.Name = "EndingDateDisplayLabel";
            this.EndingDateDisplayLabel.Size = new System.Drawing.Size(45, 13);
            this.EndingDateDisplayLabel.TabIndex = 8;
            this.EndingDateDisplayLabel.Text = "Date 2";
            // 
            // CostsLabel
            // 
            this.CostsLabel.AutoSize = true;
            this.CostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label8.Location = new System.Drawing.Point(131, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(391, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "________________________________________________________________\r\n";
            // 
            // BasicCostsView
            // 
            this.BasicCostsView.AllowUserToAddRows = false;
            this.BasicCostsView.AllowUserToDeleteRows = false;
            this.BasicCostsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BasicCostsView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.BasicCostsView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BasicCostsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BasicCostsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Basic});
            this.BasicCostsView.Location = new System.Drawing.Point(304, 223);
            this.BasicCostsView.Name = "BasicCostsView";
            this.BasicCostsView.ReadOnly = true;
            this.BasicCostsView.Size = new System.Drawing.Size(218, 150);
            this.BasicCostsView.TabIndex = 11;
            this.BasicCostsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BasicCostsView_CellContentClick);
            // 
            // Basic
            // 
            this.Basic.HeaderText = "";
            this.Basic.Name = "Basic";
            this.Basic.ReadOnly = true;
            // 
            // ExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 497);
            this.Controls.Add(this.BasicCostsView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CostsLabel);
            this.Controls.Add(this.EndingDateDisplayLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BeginningDateDisplayLabel);
            this.Controls.Add(this.DateSelectSubmitButton);
            this.Controls.Add(this.EndingDateLabel);
            this.Controls.Add(this.BeginningDateLabel);
            this.Controls.Add(this.EndingDatePicker);
            this.Controls.Add(this.BeginningDatePicker);
            this.Controls.Add(this.RangeDataTitle);
            this.Name = "ExpenseReport";
            this.Text = "ExpenseReport";
            ((System.ComponentModel.ISupportInitialize)(this.BasicCostsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RangeDataTitle;
        private System.Windows.Forms.DateTimePicker BeginningDatePicker;
        private System.Windows.Forms.DateTimePicker EndingDatePicker;
        private System.Windows.Forms.Label BeginningDateLabel;
        private System.Windows.Forms.Label EndingDateLabel;
        private System.Windows.Forms.Button DateSelectSubmitButton;
        private System.Windows.Forms.Label BeginningDateDisplayLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label EndingDateDisplayLabel;
        private System.Windows.Forms.Label CostsLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView BasicCostsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Basic;
    }
}