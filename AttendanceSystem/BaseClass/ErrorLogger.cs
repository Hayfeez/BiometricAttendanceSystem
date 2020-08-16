using System;
using System.IO;
using System.Windows.Forms;

namespace AttendanceSystem.BaseClass
{

    public static class ErrorLoggerBase
    {
        public static ErrorLogger logger = new ErrorLogger(Application.StartupPath + "\\BASErrorLogs");
    }
    public class ErrorLogger
    {
        private string _DestFolder;
        public ErrorLogger(string DestFolder)
        {
            _DestFolder = DestFolder;
            try
            {
                if (!Directory.Exists(DestFolder))
                    Directory.CreateDirectory(DestFolder);
            }
            catch (Exception ex)
            {
            }
        }
        public void WriteClientLog(string ex)
        {
            string file = Path.Combine(_DestFolder, DateTime.Now.Date.ToString("dd_MM_yyyy_") + "ClientErrorLog.txt");
            bool hasInnerException = false;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(string.Format("======================================={0}=======================================", DateTime.Now.ToString()));
                writer.WriteLine(ex);
            }
        }
        public void WriteLog(Exception ex)
        {
            if (ex.Message == "Thread was being aborted.")
                return;

            string file = Path.Combine(_DestFolder, DateTime.Now.Date.ToString("dd_MM_yyyy_") + "ErrorLog.txt");
            bool hasInnerException = false;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(string.Format("======================================={0}=======================================", DateTime.Now.ToString()));
                writer.WriteLine(ex.Message);
                writer.WriteLine(string.Format("---------------Stack Trace---------------"));
                writer.WriteLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    hasInnerException = true;
                    writer.WriteLine(string.Format("**********************Inner Exception**********************"));
                }
            }

            if (hasInnerException)
                WriteLog(ex.InnerException);
        }
        public void WriteActivity(string Activity)
        {
            string file = Path.Combine(_DestFolder, DateTime.Now.Date.ToString("dd_MM_yyyy_") + "ActivityLog.txt");
            bool hasInnerException = false;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(string.Format("======================================={0}=======================================", DateTime.Now.ToString()));
                writer.WriteLine(Activity);
            }
        }
    }

}
