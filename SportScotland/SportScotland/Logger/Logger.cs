using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SportScotland
{
    public class Logger
    {
        /// <summary>
        /// To write error logs
        /// </summary>
        /// <param name="action">Action name</param>
        /// <param name="controller">Error Name</param>
        /// <param name="ex">exception</param>
        public static void WriteLog(string action, string controller, Exception ex)
        {
            using (StreamWriter file = new StreamWriter(HttpContext.Current.Server.MapPath("~/ExceptionLogs/Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt"), true))
            {
                file.WriteLine("Time: {0}, Action: {1}, Controller: {2}, Exception message: {3}, Exception stack: {4}",
                  DateTime.Now.ToString(), action, controller, ex.Message, ex.StackTrace); // Write the file.
            }
        }
    }
}