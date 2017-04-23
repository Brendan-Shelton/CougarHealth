namespace CoreProject.Present
{
    partial class SearchHSP
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dentalCheck = new System.Windows.Forms.CheckBox();
            this.benefitListBox = new System.Windows.Forms.CheckedListBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HSP});
            this.dataGridView1.Location = new System.Drawing.Point(621, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(500, 444);
            this.dataGridView1.TabIndex = 0;
            // 
            // HSP
            // 
            this.HSP.HeaderText = "Service Provider";
            this.HSP.Name = "HSP";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(177, 32);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Search Form";
            this.titleLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.Location = new System.Drawing.Point(15, 41);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(440, 20);
            this.subtitleLabel.TabIndex = 2;
            this.subtitleLabel.Text = "Check boxes to select the benefits you wish to search for.";
            this.subtitleLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 4;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dentalCheck
            // 
            this.dentalCheck.AutoSize = true;
            this.dentalCheck.Location = new System.Drawing.Point(19, 75);
            this.dentalCheck.Name = "dentalCheck";
            this.dentalCheck.Size = new System.Drawing.Size(112, 21);
            this.dentalCheck.TabIndex = 5;
            this.dentalCheck.Text = "- Dental Plan";
            this.dentalCheck.UseVisualStyleBackColor = true;
            this.dentalCheck.CheckedChanged += new System.EventHandler(this.dentalPlan_CheckedChanged);
            // 
            // benefitListBox
            // 
            this.benefitListBox.CheckOnClick = true;
            this.benefitListBox.FormattingEnabled = true;
            this.benefitListBox.Items.AddRange(new object[] {
            "benefit 1",
            "benefit 2",
            "benefit 3"});
            this.benefitListBox.Location = new System.Drawing.Point(19, 102);
            this.benefitListBox.Name = "benefitListBox";
            this.benefitListBox.Size = new System.Drawing.Size(395, 395);
            this.benefitListBox.TabIndex = 6;
            this.benefitListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(431, 442);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(149, 55);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search Healthcare Service Providers";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // SearchHSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 503);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.benefitListBox);
            this.Controls.Add(this.dentalCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SearchHSP";
            this.Text = "Search Healthcare Service Providers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSP;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox dentalCheck;
        private System.Windows.Forms.CheckedListBox benefitListBox;
        private System.Windows.Forms.Button searchButton;
    }
}