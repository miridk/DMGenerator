using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMGenerator
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string logPath = "C:/Temp/DMGlog.txt";

            using(StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }
}
