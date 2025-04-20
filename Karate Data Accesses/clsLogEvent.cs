using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Data_Accesses
{
    public class clsLogEvent
    {
        private static string _SourceName = "Karate";
        ///<summary>
        ///This method for loging try catch exception from data access
        ///</summary>
        ///<param name="Message"></param>
        ///<param name="Type"></param>
        public static void LogExceptionToLogViwer(string Message,EventLogEntryType type)
        {
            if(!EventLog.SourceExists(_SourceName))
            {
                EventLog.CreateEventSource(_SourceName, "Application");
            }

            EventLog.WriteEntry(_SourceName, Message, type);
        }
    }
}
