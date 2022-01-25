using System;
using System.Collections.Generic;
using System.Linq;
using CollegeManager.Transports;

namespace CollegeManager
{
    /// <summary>
    /// Singleton class to log anything, anywhere.
    /// It features logging by the level of importance.
    /// This includes info, warn and error logs.
    /// </summary>
    public class Logger 
    {
        /// <summary>
        /// Represents the possible importance levels of logging.
        /// </summary>
        public enum Level
        {
            INFO,
            WARN,
            ERROR
        }

        /// <summary>
        /// Single instance of the logger.
        /// </summary>
        public static Logger Instance { get; } = new Logger();

        /// <summary>
        /// Transport methods handles the actual logging.
        /// </summary>
        private List<ILogTransport> transports = new List<ILogTransport>();

        // Protected default constructor to prevent instance creation from the outside.
        // Needs to be protected for unit testing;
        protected Logger() { }

        /// <summary>
        /// Saves the message to the logs with info level.
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Info(string message) 
        {
            Log(Level.INFO, message);
        }

        /// <summary>
        /// Saves the message to the logs with error level.
        /// </summary>
        /// <param name="message">Error message to log</param>
        public void Error(string message) 
        {
            Log(Level.ERROR, message);
        }

        /// <summary>
        /// Saves the message to the logs with warn level.
        /// </summary>
        /// <param name="message">Warn message to log</param>
        public void Warn(string message) 
        {
            Log(Level.WARN, message);
        }

        /// <summary>
        /// Adds a transport to the logger.
        /// </summary>
        /// <param name="transport">New transport to add.</param>
        public void AddTransport(ILogTransport transport)
        {
            lock(transport)
            {
                transports.Add(transport);
            }
        }

        /// <summary>
        /// Removes a transport from the transports list.
        /// </summary>
        /// <param name="transport">Transport to remove.</param>
        public void RemoveTransport(ILogTransport transport)
        {
            lock(transports)
            {
                transports.Remove(transport);
            }
        }

        /// <summary>
        /// Clears all of the transports from the logger.
        /// </summary>
        public void ClearTransports()
        {
            lock(transports)
            {
                transports.Clear();
            }
        }

        public List<LogData> ReadAllLogsByDay(DateTime dateTime)
        {
            if (!transports.Any()) return null;
            return transports[0].ReadAllLogsByDay(dateTime);
        }
 
        private void Log(Level level, string message)
        {
            lock (transports)
            {
                transports.ForEach(transport => transport.Log($"[{level}] {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} => {message}"));
            }
        }
    }
}