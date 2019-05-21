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
        /// <summary>
        /// Uses streamwriter to write to a file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="append"></param>
        /// <param name="courseRecord"></param>
        /// <returns></returns>
        internal static bool WriteToFile(string path, bool append, string courseRecord)
        {
            try
            {
                // Create a file to write to.
                using (StreamWriter sw = new StreamWriter(path, append))
                {
                    sw.Write(courseRecord);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        
        /// <summary>
        /// Creates a new file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Reads the course file four lines at a time and 
        /// returns a list of courses ordered by date
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
                        Course myCourse = new Course(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine());
                        if (myCourse.CourseName != string.Empty)
                        {
                            myCourse = Utilities.RemoveSpeechMarks(myCourse);
                            myCourseList.Add(myCourse);
                        }
                    }

                    //Order list using bubble sort
                    SortByDate(myCourseList);

                    //Order list by date using LINQ expression (faster than bubble sort on average)
                    //myCourseList = myCourseList.OrderBy(x => Convert.ToDateTime(x.Date)).ToList();

                    //Add list element number to each course
                    for (int i = 0; i < myCourseList.Count; i++)
                    {
                        myCourseList[i].Element = i;
                    }

                }
                myReturnType.Courses = myCourseList;
                myReturnType.Success = true;
                myReturnType.Ex = null;
                return myReturnType;
            }
            catch (Exception ex)
            {
                myReturnType.Courses = null;
                myReturnType.Success = false;
                myReturnType.Ex = ex;
                return myReturnType;
            }
        }

        /// <summary>
        /// Bubble sort example
        /// </summary>
        /// <param name="myCourseList"></param>
        private static void SortByDate(List<Course> myCourseList)
        {
            bool swapped = false;
            Course temp;
            int count = myCourseList.Count;
            do 
            {
                //We can decrement the counter becse after each iteration 
                //in bubble sort the last element updated will have the latest date.
                count--;
                swapped = false;
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToDateTime(myCourseList[i].Date) > Convert.ToDateTime(myCourseList[i + 1].Date))
                    {
                        temp = myCourseList[i];
                        myCourseList[i] = myCourseList[i + 1];
                        myCourseList[i + 1] = temp;
                        swapped = true;
                    }
                }
            }while (swapped);
        }
    }
}
