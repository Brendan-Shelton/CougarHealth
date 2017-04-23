
namespace CoreProject.Present
{
    partial class Main
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
            this.hspForm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.searchHSPButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heading
            // 
            this.heading.AutoSize = true;
            this.heading.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heading.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.heading.Location = new System.Drawing.Point(671, 161);
            this.heading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(413, 67);
            this.heading.TabIndex = 0;
            this.heading.Text = "Cougar Health";
            // 
            // enroll
            // 
            this.enroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.enroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enroll.Location = new System.Drawing.Point(780, 331);
            this.enroll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enroll.Name = "enroll";
            this.enroll.Size = new System.Drawing.Size(216, 71);
            this.enroll.TabIndex = 2;
            this.enroll.Text = "Enrollee Portal";
            this.enroll.UseVisualStyleBackColor = true;
            this.enroll.Click += new System.EventHandler(this.enroll_Click);
            // 
            // hspForm
            // 
            this.hspForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.hspForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hspForm.Location = new System.Drawing.Point(708, 423);
            this.hspForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hspForm.Name = "hspForm";
            this.hspForm.Size = new System.Drawing.Size(369, 71);
            this.hspForm.TabIndex = 3;
            this.hspForm.Text = "Healthcare Provider Portal";
            this.hspForm.UseVisualStyleBackColor = true;
            this.hspForm.Click += new System.EventHandler(this.hspForm_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(780, 516);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(216, 71);
            this.button2.TabIndex = 4;
            this.button2.Text = "Employee";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchHSPButton
            // 
            this.searchHSPButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.searchHSPButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchHSPButton.Location = new System.Drawing.Point(754, 606);
            this.searchHSPButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchHSPButton.Name = "searchHSPButton";
            this.searchHSPButton.Size = new System.Drawing.Size(265, 71);
            this.searchHSPButton.TabIndex = 5;
            this.searchHSPButton.Text = "Search Healthcare Service Providers";
            this.searchHSPButton.UseVisualStyleBackColor = true;
            this.searchHSPButton.Click += new System.EventHandler(this.searchHSPButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.searchHSPButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.hspForm);
            this.Controls.Add(this.enroll);
            this.Controls.Add(this.heading);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "CougarHealth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label heading;
        private System.Windows.Forms.Button enroll;
        private System.Windows.Forms.Button hspForm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button searchHSPButton;
    }
}