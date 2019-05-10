namespace CityAndGuildsDesAndTest
{
    partial class ShowAndUpdateSeats
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
            this.pnlSeats = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblBookingForm = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlSeats
            // 
            this.pnlSeats.Location = new System.Drawing.Point(88, 220);
            this.pnlSeats.Name = "pnlSeats";
            this.pnlSeats.Size = new System.Drawing.Size(772, 398);
            this.pnlSeats.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(776, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblBookingForm
            // 
            this.lblBookingForm.AutoSize = true;
            this.lblBookingForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingForm.Location = new System.Drawing.Point(73, 23);
            this.lblBookingForm.Name = "lblBookingForm";
            this.lblBookingForm.Size = new System.Drawing.Size(125, 36);
            this.lblBookingForm.TabIndex = 2;
            this.lblBookingForm.Text = "Booking";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.Location = new System.Drawing.Point(325, 23);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(0, 36);
            this.lblCourse.TabIndex = 3;
            // 
            // ShowAndUpdateSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 923);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblBookingForm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlSeats);
            this.Name = "ShowAndUpdateSeats";
            this.Text = "ShowAndUpdateSeats";
            this.Load += new System.EventHandler(this.ShowAndUpdateSeats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSeats;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBookingForm;
        private System.Windows.Forms.Label lblCourse;
    }
}