using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityAndGuildsDesAndTest
{
    public partial class ShowAndUpdateSeats : Form
    {
        private List<Course> myCourses;
        //List<TextBox> myTextBoxes = new List<TextBox>();
        List<Label> myLabels = new List<Label>();
        string course = string.Empty;
        string path = string.Empty;



        /// <summary>
        /// constructor
        /// Called from initial form
        /// Accepts a list of courses and course name
        /// </summary>
        public ShowAndUpdateSeats(List<Course> myCourses, string course, string path)
        {
            InitializeComponent();
            this.myCourses = myCourses;
            this.course = course;
            this.path = path;
        }

        private void ShowAndUpdateSeats_Load(object sender, EventArgs e)
        {
            try
            {
                lblCourse.Text = this.course;

                //pnlSeats.Controls.Clear();

                int pointX = 30;
                int pointY = 21;
                int i = 0;

                CreateFormColumnHeaders(pointX, pointY);

                //Set up dynamically rendered text boxes
                foreach (var myCourse in myCourses)
                {
                    if (myCourse.CourseName.Equals(course))
                    {
                        pointX = 30;
                        pointY += 25;
                        i++;

                        for (int seatNumber = 0; seatNumber < 12; seatNumber++)
                        {

                            CustomTextBox myTextBox = new CustomTextBox();
                            myTextBox.Width = 20;
                            if (myCourse.Seats[seatNumber] == 'B')
                            {
                                myTextBox.Text = "B";
                                myTextBox.BackColor = Color.Blue;
                            }
                            else
                            {
                                myTextBox.Text = (seatNumber + 1).ToString();
                            }

                            myTextBox.Location = new Point(pointX, pointY);
                            myTextBox.Click += txtBox_Click;
                            myTextBox.Seat = seatNumber;
                            myTextBox.ElementNumber = myCourse.Element;
                            pnlSeats.Controls.Add(myTextBox);
                            //myTextBoxes.Add(a);
                            pointX += 30;
                        }

                        AddDateAndCostLabels(pointX, pointY, myCourse);

                    }
                }
                pnlSeats.Show();

            }
            catch (Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //Adds Date and Cost Labels after each set of seat booking boxes
        private void AddDateAndCostLabels(int pointX, int pointY, Course item)
        {
            Label lblDate = new Label();
            lblDate.Location = new Point(pointX + 20, pointY);
            lblDate.Width = 70;
            lblDate.Text = item.Date;
            pnlSeats.Controls.Add(lblDate);
            myLabels.Add(lblDate);

            Label lblCost = new Label();
            lblCost.Location = new Point(pointX + 100, pointY);
            lblCost.Width = 70;
            lblCost.Text = item.Price;
            pnlSeats.Controls.Add(lblCost);
            myLabels.Add(lblCost);
        }

        //Add Column Headers
        private void CreateFormColumnHeaders(int pointX, int pointY)
        {
            Label lblDateHeader = new Label();
            lblDateHeader.Location = new Point(pointX + 400, pointY - 10);
            lblDateHeader.Width = 70;
            lblDateHeader.Text = "Date";
            pnlSeats.Controls.Add(lblDateHeader);
            myLabels.Add(lblDateHeader);

            Label lblPriceHeader = new Label();
            lblPriceHeader.Location = new Point(pointX + 700, pointY - 10);
            lblPriceHeader.Width = 70;
            lblPriceHeader.Text = "Cost";
            pnlSeats.Controls.Add(lblPriceHeader);
            myLabels.Add(lblPriceHeader);
        }

        //Sets text box content on click event and updates list elements
        private void txtBox_Click(object sender, EventArgs e)
        {
            int pos = 0;

            //Get position in string to be udated
            int stringPosition = ((CustomTextBox)sender).Seat;

            //Get list element to be updated
            int elementNumber = ((CustomTextBox)sender).ElementNumber;

            if (((CustomTextBox)sender).BackColor == Color.Blue)
            {
                ((CustomTextBox)sender).BackColor = Color.White;
                pos = stringPosition + 1;
                ((CustomTextBox)sender).Text = pos.ToString();//Sets textbox text property
                StringBuilder myString = new StringBuilder(myCourses[elementNumber].Seats);

                //Insert new boking status
                myString[stringPosition] = 'F';

                //set string value for list element's seats string
                myCourses[elementNumber].Seats = myString.ToString();
            }
            else
            {
                ((CustomTextBox)sender).BackColor = Color.Blue;
                ((CustomTextBox)sender).Text = "B"; //Sets textbox text property
                int i = ((CustomTextBox)sender).Seat;

                //Get seat string with all seats for element
                StringBuilder myString = new StringBuilder(myCourses[elementNumber].Seats);

                //Insert new boking status
                myString[stringPosition] = 'B';

                //set string value for list element's seats string
                myCourses[elementNumber].Seats = myString.ToString();
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string myString = string.Empty;
            bool append = false;
            bool error = false;

            string output = string.Empty;
            foreach (var courseRecord in myCourses)
            {
                output += courseRecord.CourseName + "\n";
                output += courseRecord.Date + "\n";
                output += courseRecord.Price + "\n";
                output += courseRecord.Seats + "\n";
            }
            //FileIO.WriteToFile returns true if write successful
            //We need to change from overwrite to append after
            //the first record overwrites existing file.
            if (FileIO.WriteToFile(path, append, output))
            {
                MessageBox.Show("File Saved");
            }
            else
            {
                MessageBox.Show("001-Fuile write error");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            {
 
                PrintDocument p = new PrintDocument();
                p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
                {
                    int yPos = 0;
                    foreach (var course in myCourses)
                    {
                        e1.Graphics.DrawString(course.CourseName + "\n", new Font("Times New Roman", 18), new SolidBrush(Color.Black), new RectangleF(0, yPos, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                        e1.Graphics.DrawString(course.Date + "\n", new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, yPos = yPos + 30, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                        e1.Graphics.DrawString(course.Price + "\n", new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, yPos = yPos + 30, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                        e1.Graphics.DrawString(course.Seats + "\n", new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, yPos = yPos + 30, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
                    }
                };
                try
                {
                    p.Print();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured While Printing", ex);
                }
            }
        }
    }
}
