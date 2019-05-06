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
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@path))
                {
                    string myString = string.Empty;

                    while (!sr.EndOfStream)
                    {
                        //myCourse constructor requires three strings.  Each Readline() reads the next line in the file.
                        Course myCourse = new Course(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(),myCourseList.Count());
                        myCourse = RemoveSpeechMarks(myCourse);
                        myCourseList.Add(myCourse);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private Course RemoveSpeechMarks(Course myCourse)
        {
            myCourse.CourseName = myCourse.CourseName.Replace("\"", string.Empty);
            myCourse.Date = myCourse.Date.Replace("\"", string.Empty);
            myCourse.Price = myCourse.Price.Replace("\"", string.Empty);
            myCourse.Seats= myCourse.Seats.Replace("\"", string.Empty);

            return myCourse;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAndUpdateSeats ShowSeats = new ShowAndUpdateSeats(myCourseList,cbCourses.Text);
            ShowSeats.Show();
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
                var distinctItems = myCourseList.Select(o => o.CourseName).Distinct();
                foreach (var item in distinctItems)
                {
                    cbCourses.Items.Add(item);

                }
            }

        }

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
            return (Validators.ValidateCourse(txtCourseTitle.Text)
                && Validators.ValidateDate(txtCourseDate.Text)
                && Validators.ValidatePrice(txtPrice.Text));
        }

        private void SaveRecord()
        {
            string path = string.Empty;
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Course Application";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                path = fdlg.FileName;

            }
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(txtCourseTitle.Text);
                    sw.WriteLine(txtCourseDate.Text);
                    sw.WriteLine(txtPrice.Text);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(txtCourseTitle.Text);
                    sw.WriteLine(txtCourseDate.Text);
                    sw.WriteLine(txtPrice.Text);
                    sw.WriteLine("FFFFFFFFFFFF");
                }
            }
        }
    }
}
