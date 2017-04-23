namespace CoreProject.Present
{
    partial class ViewServices
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
            this.ServicesDisplayed = new System.Windows.Forms.DataGridView();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentCoverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredCopayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InNetMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDisplayed)).BeginInit();
            this.SuspendLayout();
            // 
            // ServicesDisplayed
            // 
            this.ServicesDisplayed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicesDisplayed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceName,
            this.Category,
            this.PercentCoverage,
            this.RequiredCopayment,
            this.InNetMax});
            this.ServicesDisplayed.Location = new System.Drawing.Point(89, 58);
            this.ServicesDisplayed.Margin = new System.Windows.Forms.Padding(4);
            this.ServicesDisplayed.Name = "ServicesDisplayed";
            this.ServicesDisplayed.Size = new System.Drawing.Size(545, 462);
            this.ServicesDisplayed.TabIndex = 2;
            // 
            // ServiceName
            // 
            this.ServiceName.HeaderText = "Name";
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // PercentCoverage
            // 
            this.PercentCoverage.HeaderText = "Percent Coverage";
            this.PercentCoverage.Name = "PercentCoverage";
            this.PercentCoverage.ReadOnly = true;
            // 
            // RequiredCopayment
            // 
            this.RequiredCopayment.HeaderText = "Required Copayment";
            this.RequiredCopayment.Name = "RequiredCopayment";
            this.RequiredCopayment.ReadOnly = true;
            // 
            // InNetMax
            // 
            this.InNetMax.HeaderText = "In network max";
            this.InNetMax.Name = "InNetMax";
            // 
            // ViewServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(771, 691);
            this.Controls.Add(this.ServicesDisplayed);
            this.Font = new System.Drawing.Font("Arial", 12F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ViewServices";
            this.Text = "View Services";
            this.Load += new System.EventHandler(this.ViewServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDisplayed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ServicesDisplayed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentCoverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredCopayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn InNetMax;
    }
}