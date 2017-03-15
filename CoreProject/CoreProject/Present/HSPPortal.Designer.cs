namespace CoreProject.Present
{
    partial class HSPPortal
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
            this.createAccount = new System.Windows.Forms.Button();
            this.submitBill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(309, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "HSP Portal";
            // 
            // createAccount
            // 
            this.createAccount.Location = new System.Drawing.Point(315, 137);
            this.createAccount.Name = "createAccount";
            this.createAccount.Size = new System.Drawing.Size(139, 52);
            this.createAccount.TabIndex = 1;
            this.createAccount.Text = "Create Account";
            this.createAccount.UseVisualStyleBackColor = true;
            this.createAccount.Click += new System.EventHandler(this.createAccount_Click);
            // 
            // submitBill
            // 
            this.submitBill.Location = new System.Drawing.Point(315, 207);
            this.submitBill.Name = "submitBill";
            this.submitBill.Size = new System.Drawing.Size(139, 49);
            this.submitBill.TabIndex = 2;
            this.submitBill.Text = "Submit Bill";
            this.submitBill.UseVisualStyleBackColor = true;
            this.submitBill.Click += new System.EventHandler(this.submitBill_Click);
            // 
            // HSPPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(810, 471);
            this.Controls.Add(this.submitBill);
            this.Controls.Add(this.createAccount);
            this.Controls.Add(this.label1);
            this.Name = "HSPPortal";
            this.Text = "HSPPortal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createAccount;
        private System.Windows.Forms.Button submitBill;
    }
}