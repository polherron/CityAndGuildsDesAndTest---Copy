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
        List<Course> myCourseList = new List<Course>();

        public frmOpen()
        {         
            InitializeComponent();
        }

        private void frmOpen_Load(object sender, EventArgs e)

        {
            PopulateList();
            var distinctItems = myCourseList.Select(o => o.CourseName).Distinct();
            foreach (var item in distinctItems)
            {
                cbCourses.Items.Add(item);

            }
        }

        private void PopulateList()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"C:\PAUL\cProjectFiles\DevDesTest.txt"))
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
    }
}
