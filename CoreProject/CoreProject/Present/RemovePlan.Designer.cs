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
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // planList
            // 
            this.planList.FormattingEnabled = true;
            this.planList.ItemHeight = 16;
            this.planList.Location = new System.Drawing.Point(133, 95);
            this.planList.Name = "planList";
            this.planList.Size = new System.Drawing.Size(181, 132);
            this.planList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the plan you wish to remove:";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(239, 286);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 2;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(130, 239);
            this.label2.MaximumSize = new System.Drawing.Size(220, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "WARNING: This action cannot be undone!";
            // 
            // RemovePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 347);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
    }
}