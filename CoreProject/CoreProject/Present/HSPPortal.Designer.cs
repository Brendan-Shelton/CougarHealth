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
            this.create = new System.Windows.Forms.Button();
            this.bill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(589, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "HSP Portal";
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.Cornsilk;
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.create.Location = new System.Drawing.Point(597, 245);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(151, 41);
            this.create.TabIndex = 1;
            this.create.Text = "Create Account";
            this.create.UseVisualStyleBackColor = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // bill
            // 
            this.bill.BackColor = System.Drawing.Color.Cornsilk;
            this.bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.bill.Location = new System.Drawing.Point(596, 302);
            this.bill.Name = "bill";
            this.bill.Size = new System.Drawing.Size(151, 41);
            this.bill.TabIndex = 2;
            this.bill.Text = "Submit Bill";
            this.bill.UseVisualStyleBackColor = false;
            this.bill.Click += new System.EventHandler(this.bill_Click);
            // 
            // HSPPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.bill);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label1);
            this.Name = "HSPPortal";
            this.Text = "HSP Portal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button bill;
    }
}