namespace CoreProject.Present
{
    partial class EnrolleePortal
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
            this.heading = new System.Windows.Forms.Label();
            this.enroll = new System.Windows.Forms.Button();
            this.dependent = new System.Windows.Forms.Button();
            this.searchHSPButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heading
            // 
            this.heading.AutoSize = true;
            this.heading.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heading.ForeColor = System.Drawing.Color.White;
            this.heading.Location = new System.Drawing.Point(619, 127);
            this.heading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(420, 67);
            this.heading.TabIndex = 1;
            this.heading.Text = "Enrollee Portal";
            // 
            // enroll
            // 
            this.enroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.enroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enroll.Location = new System.Drawing.Point(732, 270);
            this.enroll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enroll.Name = "enroll";
            this.enroll.Size = new System.Drawing.Size(216, 71);
            this.enroll.TabIndex = 3;
            this.enroll.Text = "New Insurance Plan";
            this.enroll.UseVisualStyleBackColor = true;
            this.enroll.Click += new System.EventHandler(this.enroll_Click);
            // 
            // dependent
            // 
            this.dependent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.dependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dependent.Location = new System.Drawing.Point(735, 383);
            this.dependent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dependent.Name = "dependent";
            this.dependent.Size = new System.Drawing.Size(216, 71);
            this.dependent.TabIndex = 4;
            this.dependent.Text = "Enrollee Login";
            this.dependent.UseVisualStyleBackColor = true;
            this.dependent.Click += new System.EventHandler(this.dependent_Click);
            // 
            // searchHSPButton
            // 
            this.searchHSPButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.searchHSPButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchHSPButton.Location = new System.Drawing.Point(714, 489);
            this.searchHSPButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchHSPButton.Name = "searchHSPButton";
            this.searchHSPButton.Size = new System.Drawing.Size(265, 71);
            this.searchHSPButton.TabIndex = 6;
            this.searchHSPButton.Text = "Search Healthcare Service Providers";
            this.searchHSPButton.UseVisualStyleBackColor = true;
            this.searchHSPButton.Click += new System.EventHandler(this.searchHSPButton_Click);
            // 
            // EnrolleePortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.searchHSPButton);
            this.Controls.Add(this.dependent);
            this.Controls.Add(this.enroll);
            this.Controls.Add(this.heading);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EnrolleePortal";
            this.Text = "Enrollee Portal";
            this.Load += new System.EventHandler(this.EnrolleePortal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label heading;
        private System.Windows.Forms.Button enroll;
        private System.Windows.Forms.Button dependent;
        private System.Windows.Forms.Button searchHSPButton;
    }
}