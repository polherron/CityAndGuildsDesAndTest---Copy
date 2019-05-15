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
        internal static bool WriteToFile(string path, bool append, Course courseRecord)
        {
            try
            {
                // Create a file to write to.
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    sw.WriteLine(courseRecord.CourseName);
                    sw.WriteLine(courseRecord.Date);
                    sw.WriteLine(courseRecord.Price);
                    sw.WriteLine(courseRecord.Seats);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        internal static bool WriteToFile(string path, bool append, List<Course> courseRecords)
        {

            string output = string.Empty;

            foreach (var courseRecord in courseRecords)
            {
                output += courseRecord.CourseName + "\n";
                output += courseRecord.Date + "\n";
                output += courseRecord.Price + "\n";
                output += courseRecord.Seats + "\n";
            }
            try
            {
                // Create a file to write to.
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    sw.WriteLine(output);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
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
                    using (FileStream fs = File.Create(path))
                    {
                        fileCreated = true;
                    }
                }
            }

            catch (Exception ex)
            {
                fileCreated = false;
            }
            return fileCreated;
        }

        internal static FileReadReturnType FileRead(string path)
        {
            List<Course> myCourseList = new List<Course>();

            FileReadReturnType myReturnType = new FileReadReturnType();
            // Open the text file using a stream reader.
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string myString = string.Empty;
                    int count = 0;
                    while (!sr.EndOfStream)
                    {

                        //myCourse constructor requires three strings.  Each Readline() reads the next line in the file.
                        Course myCourse = new Course(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), count++);
                        if (myCourse.CourseName != string.Empty)
                        {
                            myCourse = Utilities.RemoveSpeechMarks(myCourse);
                            myCourseList.Add(myCourse);
                        }
                    }
                }
                myReturnType.Courses = myCourseList;
                myReturnType.Success = true;
                myReturnType.Ex = null;
                return myReturnType;
            }
            catch(Exception ex)
            {
                myReturnType.Courses = null;
                myReturnType.Success = false;
                myReturnType.Ex = ex;
                return myReturnType;
            }
        }

    }
}
