using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManager.Transports
{
    /// <summary>
    /// Interface that defines a log transport.
    /// These transports will be used while logging.
    /// A transport may can log to the console or file or anything. 
    /// </summary>
    public interface ILogTransport
    {
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Log(string message);
        List<LogData> ReadAllLogsByDay(DateTime time);
    }
}
