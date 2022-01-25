using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CollegeManager.Transports
{
    /// <summary>
    /// Log transport that creates a new file for the logs every day.
    /// </summary>
    public class DailyRotateFileTransport : ILogTransport
    {
        private object _lock = new object();

        /// <summary>
        /// Logs the message to a file which name is bound to the current day.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void Log(string message)
        {
            lock(_lock)
            {
                var date = DateTime.Now;
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, $"{date.Year}-{date.Month}-{date.Day}.log");
                File.AppendAllText(path, $"{message}\n");
            }
        }

        public List<LogData> ReadAllLogsByDay(DateTime date)
        {
             lock (_lock)
             {
                var list = new List<LogData>();
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, $"{date.Year}-{date.Month}-{date.Day}.log");
                try
                {
                    var stream = File.OpenRead(path);
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            list.Add(ParseLogData(line));
                        }
                    }
                    return list;
                } 
                catch
                {
                    return null;
                }
             }
        }

        private LogData ParseLogData(string line)
        {
            var regex = new Regex(@"\[(.*)\]\s([0-9]{4}\/[0-9]{1,2}\/[0-9]{1,2}\s[0-9]{1,2}:[0-9]{1,2}:[0-9]{1,2}).*=>\s(.*)");
            var result = regex.Match(line);
            var logLevel = ParseLogLevel(result.Groups[1].Value);
            var date = DateTime.Parse(result.Groups[2].Value);
            var message = result.Groups[3].Value;
            return new LogData(date, logLevel, message);
        }

        private Logger.Level ParseLogLevel(string level)
        {
            if (level == "INFO") return Logger.Level.INFO;
            else if (level == "WARN") return Logger.Level.WARN;
            else return Logger.Level.ERROR;
        }
    }
}
