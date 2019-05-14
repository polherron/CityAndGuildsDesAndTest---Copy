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
        internal static void WriteToFile(string path, bool append, string courseRecord)
        {
                // Create a file to write to.
                using (StreamWriter sw = new StreamWriter(path, append)) 
                {
                    sw.WriteLine(courseRecord);
                }
        }
    }
}
