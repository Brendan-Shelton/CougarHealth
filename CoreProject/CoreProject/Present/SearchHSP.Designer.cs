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
            this.searchHSPResult = new System.Windows.Forms.DataGridView();
            this.HSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.benefitListBox = new System.Windows.Forms.CheckedListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.planList = new System.Windows.Forms.ListBox();
            this.planSelectTitle = new System.Windows.Forms.Label();
            this.benefitsTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.searchHSPResult)).BeginInit();
            this.SuspendLayout();
            // 
            // searchHSPResult
            // 
            this.searchHSPResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchHSPResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.searchHSPResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchHSPResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HSP,
            this.Address});
            this.searchHSPResult.Location = new System.Drawing.Point(461, 50);
            this.searchHSPResult.Name = "searchHSPResult";
            this.searchHSPResult.RowTemplate.Height = 24;
            this.searchHSPResult.Size = new System.Drawing.Size(656, 444);
            this.searchHSPResult.TabIndex = 0;
            // 
            // HSP
            // 
            this.HSP.HeaderText = "Service Provider";
            this.HSP.Name = "HSP";
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 4;
            // 
            // benefitListBox
            // 
            this.benefitListBox.CheckOnClick = true;
            this.benefitListBox.FormattingEnabled = true;
            this.benefitListBox.Items.AddRange(new object[] {
            "benefit 1",
            "benefit 2",
            "benefit 3"});
            this.benefitListBox.Location = new System.Drawing.Point(22, 218);
            this.benefitListBox.Name = "benefitListBox";
            this.benefitListBox.Size = new System.Drawing.Size(395, 276);
            this.benefitListBox.TabIndex = 6;
            this.benefitListBox.Visible = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(268, 157);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(149, 55);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search Healthcare Service Providers";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // planList
            // 
            this.planList.FormattingEnabled = true;
            this.planList.ItemHeight = 16;
            this.planList.Location = new System.Drawing.Point(22, 100);
            this.planList.Name = "planList";
            this.planList.Size = new System.Drawing.Size(237, 84);
            this.planList.TabIndex = 8;
            this.planList.SelectedIndexChanged += new System.EventHandler(this.planList_SelectedIndexChanged);
            // 
            // planSelectTitle
            // 
            this.planSelectTitle.AutoSize = true;
            this.planSelectTitle.Location = new System.Drawing.Point(22, 77);
            this.planSelectTitle.Name = "planSelectTitle";
            this.planSelectTitle.Size = new System.Drawing.Size(91, 17);
            this.planSelectTitle.TabIndex = 9;
            this.planSelectTitle.Text = "Select a Plan";
            // 
            // benefitsTitle
            // 
            this.benefitsTitle.AutoSize = true;
            this.benefitsTitle.Location = new System.Drawing.Point(22, 198);
            this.benefitsTitle.Name = "benefitsTitle";
            this.benefitsTitle.Size = new System.Drawing.Size(102, 17);
            this.benefitsTitle.TabIndex = 10;
            this.benefitsTitle.Text = "Select Benefits";
            // 
            // SearchHSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1129, 503);
            this.Controls.Add(this.benefitsTitle);
            this.Controls.Add(this.planSelectTitle);
            this.Controls.Add(this.planList);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.benefitListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.searchHSPResult);
            this.Name = "SearchHSP";
            this.Text = "Search Healthcare Service Providers";
            ((System.ComponentModel.ISupportInitialize)(this.searchHSPResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView searchHSPResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSP;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox benefitListBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox planList;
        private System.Windows.Forms.Label planSelectTitle;
        private System.Windows.Forms.Label benefitsTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}