using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAndGuildsDesAndTest
{
    class FileIO
    {
        internal static void WriteToFile(string path, bool append, InitialCourse courseRecord)
        {
                // Create a file to write to.
                using (StreamWriter sw = new StreamWriter(path, append)) 
                {
                    sw.WriteLine(courseRecord.CourseName);
                    sw.WriteLine(courseRecord.Date);
                    sw.WriteLine(courseRecord.Price);
                    sw.WriteLine(courseRecord.Seats);
                }
        }

        internal static bool CreateFile(string path)
        {

            bool fileCreated = false;
            try
            {
                // Delete the file if it exists.
                if (!File.Exists(path))
                {
                    using (FileStream fs = File.Create(path));
                    fileCreated = true;
                }
            }

            catch (Exception ex)
            {
                fileCreated = false;
            }
            return fileCreated;
        }

        internal static List<Course> FileRead(string path)
        {
            List<Course> myCourseList = new List<Course>();
            // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(@path))
            {
                string myString = string.Empty;

                while (!sr.EndOfStream)
                {
                    //myCourse constructor requires three strings.  Each Readline() reads the next line in the file.
                    Course myCourse = new Course(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), myCourseList.Count());
                    if (myCourse.CourseName != string.Empty)
                    {
                        myCourse = Utilities.RemoveSpeechMarks(myCourse);
                        myCourseList.Add(myCourse);
                    }
                }
            }
            return myCourseList;
        }

    }
}
