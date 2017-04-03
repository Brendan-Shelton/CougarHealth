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
            this.EnrolleeCostsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heading
            // 
            this.heading.AutoSize = true;
            this.heading.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heading.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.heading.Location = new System.Drawing.Point(464, 103);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(338, 55);
            this.heading.TabIndex = 1;
            this.heading.Text = "Enrollee Portal";
            // 
            // enroll
            // 
            this.enroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.enroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enroll.Location = new System.Drawing.Point(549, 219);
            this.enroll.Name = "enroll";
            this.enroll.Size = new System.Drawing.Size(162, 58);
            this.enroll.TabIndex = 3;
            this.enroll.Text = "New Insurance Plan";
            this.enroll.UseVisualStyleBackColor = true;
            this.enroll.Click += new System.EventHandler(this.enroll_Click);
            // 
            // dependent
            // 
            this.dependent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.dependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dependent.Location = new System.Drawing.Point(551, 311);
            this.dependent.Name = "dependent";
            this.dependent.Size = new System.Drawing.Size(162, 58);
            this.dependent.TabIndex = 4;
            this.dependent.Text = "Add Dependent";
            this.dependent.UseVisualStyleBackColor = true;
            this.dependent.Click += new System.EventHandler(this.dependent_Click);
            // 
            // EnrolleeCostsButton
            // 
            this.EnrolleeCostsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.EnrolleeCostsButton.Location = new System.Drawing.Point(551, 407);
            this.EnrolleeCostsButton.Name = "EnrolleeCostsButton";
            this.EnrolleeCostsButton.Size = new System.Drawing.Size(162, 54);
            this.EnrolleeCostsButton.TabIndex = 5;
            this.EnrolleeCostsButton.Text = "View Costs";
            this.EnrolleeCostsButton.UseVisualStyleBackColor = true;
            this.EnrolleeCostsButton.Click += new System.EventHandler(this.EnrolleeCostsButton_Click);
            // 
            // EnrolleePortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.EnrolleeCostsButton);
            this.Controls.Add(this.dependent);
            this.Controls.Add(this.enroll);
            this.Controls.Add(this.heading);
            this.Name = "EnrolleePortal";
            this.Text = "Enrollee Portal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label heading;
        private System.Windows.Forms.Button enroll;
        private System.Windows.Forms.Button dependent;
        private System.Windows.Forms.Button EnrolleeCostsButton;
    }
}