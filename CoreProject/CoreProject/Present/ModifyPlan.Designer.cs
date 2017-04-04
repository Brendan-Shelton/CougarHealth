namespace CoreProject.Present
{
    partial class ModifyPlan
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
            this.PlanType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PlanComparison = new System.Windows.Forms.DataGridView();
            this.PickPlan = new System.Windows.Forms.Button();
            this.CurrentServices = new System.Windows.Forms.Button();
            this.OtherServices = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlanComparison)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCoral;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(308, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modify Plan";
            // 
            // PlanType
            // 
            this.PlanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlanType.Font = new System.Drawing.Font("Arial", 12F);
            this.PlanType.FormattingEnabled = true;
            this.PlanType.Location = new System.Drawing.Point(128, 67);
            this.PlanType.Name = "PlanType";
            this.PlanType.Size = new System.Drawing.Size(161, 26);
            this.PlanType.TabIndex = 2;
            this.PlanType.SelectedIndexChanged += new System.EventHandler(this.PlanType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Compare:";
            // 
            // PlanComparison
            // 
            this.PlanComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlanComparison.Location = new System.Drawing.Point(73, 125);
            this.PlanComparison.Name = "PlanComparison";
            this.PlanComparison.ReadOnly = true;
            this.PlanComparison.Size = new System.Drawing.Size(611, 462);
            this.PlanComparison.TabIndex = 4;
            // 
            // PickPlan
            // 
            this.PickPlan.Font = new System.Drawing.Font("Arial", 12F);
            this.PickPlan.Location = new System.Drawing.Point(675, 636);
            this.PickPlan.Name = "PickPlan";
            this.PickPlan.Size = new System.Drawing.Size(75, 23);
            this.PickPlan.TabIndex = 5;
            this.PickPlan.Text = "select";
            this.PickPlan.UseVisualStyleBackColor = true;
            this.PickPlan.Click += new System.EventHandler(this.PickPlan_Click);
            // 
            // CurrentServices
            // 
            this.CurrentServices.Font = new System.Drawing.Font("Arial", 12F);
            this.CurrentServices.Location = new System.Drawing.Point(97, 636);
            this.CurrentServices.Name = "CurrentServices";
            this.CurrentServices.Size = new System.Drawing.Size(151, 23);
            this.CurrentServices.TabIndex = 6;
            this.CurrentServices.Text = "Current Services";
            this.CurrentServices.UseVisualStyleBackColor = true;
            this.CurrentServices.Click += new System.EventHandler(this.CurrentServices_Click);
            // 
            // OtherServices
            // 
            this.OtherServices.Font = new System.Drawing.Font("Arial", 12F);
            this.OtherServices.Location = new System.Drawing.Point(314, 636);
            this.OtherServices.Name = "OtherServices";
            this.OtherServices.Size = new System.Drawing.Size(151, 23);
            this.OtherServices.TabIndex = 7;
            this.OtherServices.Text = "Other Services";
            this.OtherServices.UseVisualStyleBackColor = true;
            this.OtherServices.Click += new System.EventHandler(this.OtherServices_Click);
            // 
            // ModifyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(771, 691);
            this.Controls.Add(this.OtherServices);
            this.Controls.Add(this.CurrentServices);
            this.Controls.Add(this.PickPlan);
            this.Controls.Add(this.PlanComparison);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlanType);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ModifyPlan";
            this.Text = "Modify Plan";
            this.Load += new System.EventHandler(this.ModifyPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlanComparison)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PlanType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView PlanComparison;
        private System.Windows.Forms.Button PickPlan;
        private System.Windows.Forms.Button CurrentServices;
        private System.Windows.Forms.Button OtherServices;
    }
}