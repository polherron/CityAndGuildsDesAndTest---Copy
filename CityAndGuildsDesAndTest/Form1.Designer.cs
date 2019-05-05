namespace CityAndGuildsDesAndTest
{
    partial class frmOpen
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
            this.cbCourses = new System.Windows.Forms.ComboBox();
            this.btnBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCourses
            // 
            this.cbCourses.FormattingEnabled = true;
            this.cbCourses.Location = new System.Drawing.Point(93, 84);
            this.cbCourses.Name = "cbCourses";
            this.cbCourses.Size = new System.Drawing.Size(273, 24);
            this.cbCourses.TabIndex = 0;
            // 
            // btnBooking
            // 
            this.btnBooking.Location = new System.Drawing.Point(399, 85);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(75, 23);
            this.btnBooking.TabIndex = 1;
            this.btnBooking.Text = "Booking";
            this.btnBooking.UseVisualStyleBackColor = true;
            this.btnBooking.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 253);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.cbCourses);
            this.Name = "frmOpen";
            this.Text = "Open";
            this.Load += new System.EventHandler(this.frmOpen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCourses;
        private System.Windows.Forms.Button btnBooking;
    }
}

