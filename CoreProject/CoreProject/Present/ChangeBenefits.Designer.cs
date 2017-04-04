namespace CoreProject.Present
{
    partial class ChangeBenefits
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
            this.removeSubmit = new System.Windows.Forms.Button();
            this.addSubmit = new System.Windows.Forms.Button();
            this.benefitName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.percent = new System.Windows.Forms.NumericUpDown();
            this.copay = new System.Windows.Forms.NumericUpDown();
            this.maxPay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.benefitList = new System.Windows.Forms.ListBox();
            this.planList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.catName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.percent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.copay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Benefit Name";
            // 
            // removeSubmit
            // 
            this.removeSubmit.Location = new System.Drawing.Point(16, 395);
            this.removeSubmit.Name = "removeSubmit";
            this.removeSubmit.Size = new System.Drawing.Size(75, 23);
            this.removeSubmit.TabIndex = 1;
            this.removeSubmit.Text = "Submit";
            this.removeSubmit.UseVisualStyleBackColor = true;
            this.removeSubmit.Click += new System.EventHandler(this.removeSubmit_Click);
            // 
            // addSubmit
            // 
            this.addSubmit.Location = new System.Drawing.Point(168, 206);
            this.addSubmit.Name = "addSubmit";
            this.addSubmit.Size = new System.Drawing.Size(75, 23);
            this.addSubmit.TabIndex = 2;
            this.addSubmit.Text = "Submit";
            this.addSubmit.UseVisualStyleBackColor = true;
            this.addSubmit.Click += new System.EventHandler(this.addSubmit_Click);
            // 
            // benefitName
            // 
            this.benefitName.Location = new System.Drawing.Point(145, 45);
            this.benefitName.Name = "benefitName";
            this.benefitName.Size = new System.Drawing.Size(128, 22);
            this.benefitName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Percent Paid:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Copayment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Payment:";
            // 
            // percent
            // 
            this.percent.Location = new System.Drawing.Point(145, 108);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(128, 22);
            this.percent.TabIndex = 7;
            // 
            // copay
            // 
            this.copay.Location = new System.Drawing.Point(145, 136);
            this.copay.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.copay.Name = "copay";
            this.copay.Size = new System.Drawing.Size(128, 22);
            this.copay.TabIndex = 8;
            // 
            // maxPay
            // 
            this.maxPay.Location = new System.Drawing.Point(145, 169);
            this.maxPay.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.maxPay.Name = "maxPay";
            this.maxPay.Size = new System.Drawing.Size(128, 22);
            this.maxPay.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Add Benefit";
            // 
            // benefitList
            // 
            this.benefitList.FormattingEnabled = true;
            this.benefitList.ItemHeight = 16;
            this.benefitList.Location = new System.Drawing.Point(12, 249);
            this.benefitList.Name = "benefitList";
            this.benefitList.Size = new System.Drawing.Size(120, 132);
            this.benefitList.TabIndex = 11;
            // 
            // planList
            // 
            this.planList.FormattingEnabled = true;
            this.planList.ItemHeight = 16;
            this.planList.Location = new System.Drawing.Point(153, 267);
            this.planList.Name = "planList";
            this.planList.Size = new System.Drawing.Size(120, 100);
            this.planList.TabIndex = 12;
            this.planList.SelectedIndexChanged += new System.EventHandler(this.planList_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Category:";
            // 
            // catName
            // 
            this.catName.Location = new System.Drawing.Point(145, 76);
            this.catName.Name = "catName";
            this.catName.Size = new System.Drawing.Size(128, 22);
            this.catName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Remove Benefit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(168, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Select Plan";
            // 
            // ChangeBenefits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 430);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.catName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.planList);
            this.Controls.Add(this.benefitList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maxPay);
            this.Controls.Add(this.copay);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.benefitName);
            this.Controls.Add(this.addSubmit);
            this.Controls.Add(this.removeSubmit);
            this.Controls.Add(this.label1);
            this.Name = "ChangeBenefits";
            this.Text = "ChangeBenefits";
            ((System.ComponentModel.ISupportInitialize)(this.percent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.copay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeSubmit;
        private System.Windows.Forms.Button addSubmit;
        private System.Windows.Forms.TextBox benefitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown percent;
        private System.Windows.Forms.NumericUpDown copay;
        private System.Windows.Forms.NumericUpDown maxPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox benefitList;
        private System.Windows.Forms.ListBox planList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox catName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}