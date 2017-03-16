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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(785, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "HSP Portal";
            // 
            // create
            // 
            this.create.BackColor = System.Drawing.Color.Cornsilk;
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.create.Location = new System.Drawing.Point(796, 302);
            this.create.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(201, 50);
            this.create.TabIndex = 1;
            this.create.Text = "Create Account";
            this.create.UseVisualStyleBackColor = false;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cornsilk;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(795, 372);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit Bill";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HSPPortal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HSPPortal";
            this.Text = "HSP Portal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button button1;
    }
}