using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    public class HelperClass
    {
        public void writeResponse(string response)
        {
            string pathForResponse = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForResponse.txt";
            StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
            sw.WriteLine(response);
            sw.Flush();
            sw.Close();
        }

        public void writeExceptionMessage(string message)
        {
            StreamWriter sw = new StreamWriter(new FileStream("C:\\DDDDemo\\ExceptionsFromService.db", FileMode.Append, FileAccess.Write));
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
        }
    }
}
