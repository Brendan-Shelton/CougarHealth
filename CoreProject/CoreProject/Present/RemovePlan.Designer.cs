namespace CoreProject.Present
{
    partial class RemovePlan
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
            this.planList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // planList
            // 
            this.planList.FormattingEnabled = true;
            this.planList.ItemHeight = 16;
            this.planList.Location = new System.Drawing.Point(18, 107);
            this.planList.Name = "planList";
            this.planList.Size = new System.Drawing.Size(181, 132);
            this.planList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the plan you wish to remove:";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(124, 259);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 2;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // RemovePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 490);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.planList);
            this.Name = "RemovePlan";
            this.Text = "RemovePlan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox planList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submit;
    }
}