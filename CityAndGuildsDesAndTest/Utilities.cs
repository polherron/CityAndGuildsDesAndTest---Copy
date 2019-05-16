using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CityAndGuildsDesAndTest
{
    class Utilities
    {
        /// <summary>
        /// Date validator
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool ValidateDate(string date)
        {
            DateTime temp;
            return (DateTime.TryParse(date, out temp));
        }

        /// <summary>
        /// Price validator
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static bool ValidatePrice(string price)
        {
            var regex = @"^((([1-9]\d{0,2},(\d{3},)*\d{3}|[1-9]\d*)(.\d{1,4})?)|(0\.\d{1,4}))$";
            return(Regex.IsMatch(price, regex));
            
        }

        /// <summary>
        /// Validates course name
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public static bool ValidateCourse(string courseName)
        {
            return (courseName.Length > 0 && courseName.Length < 20);
        }

        /// <summary>
        /// Removes speach marks from strings in the mycourse object
        /// </summary>
        /// <param name="myCourse"></param>
        /// <returns></returns>
        public static Course RemoveSpeechMarks(Course myCourse)
        {
            myCourse.CourseName = myCourse.CourseName.Replace("\"", string.Empty);
            myCourse.Date = myCourse.Date.Replace("\"", string.Empty);
            myCourse.Price = myCourse.Price.Replace("\"", string.Empty);
            myCourse.Seats = myCourse.Seats.Replace("\"", string.Empty);

            return myCourse;
        }
    }
}
