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
    public partial class frmOpen : Form
    {
        string path = string.Empty;
        List<Course> myCourseList = new List<Course>();
        FileReadReturnType myDataRequest = new FileReadReturnType();


        public frmOpen()
        {
            InitializeComponent();
        }

        private void frmOpen_Load(object sender, EventArgs e)

        {

        }
        /// <summary>
        /// Gets a list of courses from a list of files
        /// </summary>
        /// <param name="openCall"></param>
        private void PopulateList(bool openCall)
        {
            //We need to clear the list if it is updated to prevent duplicate
            //entries
            myCourseList.Clear();
            myDataRequest = FileIO.FileRead(path);

            if (myDataRequest.Success)
            {
                cbCourses.Items.Clear();
                var distinctItems = myDataRequest.Courses.Select(o => o.CourseName).Distinct();
                foreach (var item in distinctItems)
                {
                    cbCourses.Items.Add(item);

                }
            }
            else
            {
                if (openCall)
                {
                    MessageBox.Show("002 - File open error or dialog cancelled");
                }
                else
                {
                    MessageBox.Show("001 - File incorrect format or missing or dialog cancelled");
                }
            }
        }

        /// <summary>
        /// Calls bookig form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBooking_Click(object sender, EventArgs e)
        {
            myDataRequest = FileIO.FileRead(path);
            ShowAndUpdateSeats ShowSeats = new ShowAndUpdateSeats(myDataRequest.Courses, cbCourses.Text, path);
            ShowSeats.Show();
        }

        /// <summary>
        /// Adds a new course to the course file
        /// Calls an append file method via SaveRecord method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            if (ValidInput())
            {
                SaveRecord();
            }
            else
            {
                MessageBox.Show("Invalid Course Inputs");
            }

        }
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Course Application";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                path = fdlg.FileName;
                PopulateList(true);
            }

        }

        /// <summary>
        /// Even handler for save option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidInput())
            {
                SaveRecord();
                PopulateList(false);
            }
            else
            {
                MessageBox.Show("Invalid Course Inputs");
            }

        }

        /// <summary>
        /// Calls validator methods
        /// </summary>
        /// <returns></returns>
        private bool ValidInput()
        {
            return (Utilities.ValidateCourse(txtCourseTitle.Text)
                && Utilities.ValidateDate(txtCourseDate.Text)
                && Utilities.ValidatePrice(txtPrice.Text));
        }

        /// <summary>
        /// Adds speach marks to inputs and saves to file
        /// </summary>
        private void SaveRecord()
        {

            string courseName = "\"" + txtCourseTitle.Text + "\"";
            string courseDate = "\"" + txtCourseDate.Text + "\"";
            string coursePrice = "\"" + txtPrice.Text + "\"";
            string seats = "\"" + "FFFFFFFFFFFF" + "\"";
            Course myCourse = new Course(courseName, courseDate, coursePrice, seats, myCourseList.Count());
            if (FileIO.WriteToFile(@path, true, myCourse))
            {
                PopulateList(false);
            }
            else
            {
                MessageBox.Show("File save error");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// calls create file method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fdlg = new SaveFileDialog();
            fdlg.Title = "Course Application";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                path = fdlg.FileName;
                if (FileIO.CreateFile(path))
                {
                    MessageBox.Show("File Created at " + path);
                }
                else
                {
                    MessageBox.Show("File Not Created  " + path);
                }
            }

        }
    }
}
