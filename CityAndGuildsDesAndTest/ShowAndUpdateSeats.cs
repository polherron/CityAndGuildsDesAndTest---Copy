using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                int rows = GetRows();
                int pointX = 30;
                lblCourse.Text = this.course;

                //pnlSeats.Controls.Clear();

                pointX = 30;
                int pointY = 21;
                int i = 0;
                int ElementNumber = 0;

                CreateFormColumnHeaders(pointX, pointY);

                //Set up dynamically rendered text boxes
                foreach (var item in myCourses)
                {
                    if (item.CourseName.Equals(course))
                    {
                        pointX = 30;
                        pointY += 20 + i * 20;
                        i++;

                        for (int j = 0; j < 12; j++)
                        {

                            CustomTextBox a = new CustomTextBox();
                            a.Width = 20;
                            if (item.Seats[j] == 'B')
                            {
                                a.Text = "B";
                            }
                            else
                            {
                                a.Text = (j + 1).ToString();
                            }

                            a.Location = new Point(pointX, pointY);
                            a.Click += txtBox_Click;
                            a.Seat = j;
                            a.ElementNumber = ElementNumber;
                            pnlSeats.Controls.Add(a);
                            //myTextBoxes.Add(a);
                            pointX += 30;
                        }

                        AddDateAndCostLabels(pointX, pointY, item);

                    }
                    ElementNumber++;
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

        private int GetRows()
        {
            return (myCourses.Count(item => item.CourseName == this.course));

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
            foreach (var item in myCourses)
            {
                FileIO.WriteToFile(path, append, item);
                append = true;
            }

        }
    }
}
