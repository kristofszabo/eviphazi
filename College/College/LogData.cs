using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManager
{
    public class LogData
    {
        public DateTime Time { get; }
        public Logger.Level Level { get; }
        public string Message { get; }

        public LogData(DateTime time, Logger.Level level, string message)
        {
            Time = time;
            Level = level;
            Message = message;
        }
    }
}
