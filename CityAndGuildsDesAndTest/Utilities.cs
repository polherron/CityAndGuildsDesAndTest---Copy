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
        public static bool ValidateDate(string date)
        {
            DateTime temp;
            return (DateTime.TryParse(date, out temp));
        }

        public static bool ValidatePrice(string price)
        {
            var regex = @"^((([1-9]\d{0,2},(\d{3},)*\d{3}|[1-9]\d*)(.\d{1,4})?)|(0\.\d{1,4}))$";
            return(Regex.IsMatch(price, regex));
            
        }

        public static bool ValidateCourse(string courseName)
        {
            return (courseName.Length > 0 && courseName.Length < 20);
        }

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
