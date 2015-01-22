using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Pirates
{
    enum LogMode { DEBUG, WARNING, ERROR, WTF, INFO, VERBOSE }
    class Log
    {
        
        private static bool isInitialized = false;
        private static LogCat logCat;
        private static void initialize()
        {    
            logCat = new LogCat();
            logCat.Show();
            isInitialized = true;
        }

        public static void d(String tag, String message)
        {
            writeLog(LogMode.DEBUG, tag, message);
        }

        public static void e(String tag, String message)
        {
            writeLog(LogMode.ERROR, tag, message);
        }
        
        public static void v(String tag, String message)
        {
            writeLog(LogMode.VERBOSE, tag, message);
        }

        public static void i(String tag, String message)
        {
            writeLog(LogMode.INFO, tag, message);
        }

        public static void w(String tag, String message)
        {
            writeLog(LogMode.WARNING, tag, message);
        }

        public static void wtf(String tag, String message)
        {
            writeLog(LogMode.WTF, tag, message);
        }


        private static void writeLog(LogMode mode, String tag, String message)
        {
            if (logCat == null || !isInitialized)
            {
                initialize();
            }
            logCat.append(mode, DateTime.Now, Thread.CurrentThread.Name, tag, message);
        }
    }
}
