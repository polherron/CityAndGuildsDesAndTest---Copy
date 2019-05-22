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
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlSeats
            // 
            this.pnlSeats.Location = new System.Drawing.Point(66, 179);
            this.pnlSeats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSeats.Name = "pnlSeats";
            this.pnlSeats.Size = new System.Drawing.Size(579, 323);
            this.pnlSeats.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(582, 39);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 19);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblBookingForm
            // 
            this.lblBookingForm.AutoSize = true;
            this.lblBookingForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingForm.Location = new System.Drawing.Point(55, 19);
            this.lblBookingForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookingForm.Name = "lblBookingForm";
            this.lblBookingForm.Size = new System.Drawing.Size(102, 29);
            this.lblBookingForm.TabIndex = 2;
            this.lblBookingForm.Text = "Booking";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.Location = new System.Drawing.Point(244, 19);
            this.lblCourse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(0, 29);
            this.lblCourse.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(526, 550);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ShowAndUpdateSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 750);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblBookingForm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlSeats);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btnPrint;
    }
}