using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructuredServices
{
    public class LoggerService
    {

        public void logInfo(DateTime dateTime, string log)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\work\NorthwindErrorLog.txt", true))
            {
                sw.WriteLine(dateTime.ToString() + log);
            }
        }


        public void logError(DateTime dateTime, string log)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\work\NorthwindErrorLog.txt", true))
            {
                sw.WriteLine(dateTime.ToString() + log);
            }
        }
    }
}
