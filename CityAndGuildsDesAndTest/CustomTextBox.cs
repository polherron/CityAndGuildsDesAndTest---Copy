using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//System.ComponentModel allows us add an 
//extended forms class to the toolbox
using System.ComponentModel;

namespace CityAndGuildsDesAndTest
{
    [Description("Used to link text box control to list element")]
    [Category("CustomTextBox")]
    [DefaultValue(0)]
    public class CustomTextBox : System.Windows.Forms.TextBox
    {
        private int seat;
        private int elementNumber;

        ///Position in String
        public int Seat
        {
            get { return seat; }
            set { seat = value; }
        }

        //Position in List
        public int ElementNumber
        {
            get { return elementNumber; }
            set { elementNumber = value; }
        }

    }
}
