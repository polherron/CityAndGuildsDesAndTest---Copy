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

        public frmOpen()
        {         
            InitializeComponent();
        }

        private void frmOpen_Load(object sender, EventArgs e)

        {

        }

        private void PopulateList()
        {
            try
            {
                //We need to clear the list if it is updated to prevent duplicate
                //entries
                myCourseList.Clear();
                myCourseList = FileIO.FileRead(path);

                cbCourses.Items.Clear();
                var distinctItems = myCourseList.Select(o => o.CourseName).Distinct();
                foreach (var item in distinctItems)
                {
                    cbCourses.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            ShowAndUpdateSeats ShowSeats = new ShowAndUpdateSeats(myCourseList,cbCourses.Text, path);
            ShowSeats.Show();
        }

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
                PopulateList();
            }

        }

        //private void PopulateDDL()
        //{
        //    cbCourses.Refresh();
        //    var distinctItems = myCourseList.Select(o => o.CourseName).Distinct();
        //    foreach (var item in distinctItems)
        //    {
        //        cbCourses.Items.Add(item);

        //    }
        //}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private bool ValidInput()
        {
            return (Utilities.ValidateCourse(txtCourseTitle.Text)
                && Utilities.ValidateDate(txtCourseDate.Text)
                && Utilities.ValidatePrice(txtPrice.Text));
        }

        private void SaveRecord()
        {

            string courseName = "\"" + txtCourseTitle.Text + "\"";
            string courseDate = "\"" + txtCourseDate.Text + "\"";
            string coursePrice = "\"" + txtPrice.Text + "\"";
            string seats = "\"" + "FFFFFFFFFFFF" + "\"";
            InitialCourse myCourse = new InitialCourse(courseName, courseDate, coursePrice, seats);
            FileIO.WriteToFile(path,true,myCourse);
            PopulateList();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
