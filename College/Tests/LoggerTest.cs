using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CollegeManager;
using CollegeManager.Transports;
using System.Threading.Tasks;

namespace Tests
{
    public class LoggerTest
    {
        class ListLogTransport : ILogTransport
        {
            public List<string> Logs { get; } = new List<string>();
            public void Log(string message)
            {
                Logs.Add(message);
            }

            public List<LogData> ReadAllLogsByDay(DateTime time)
            {
                throw new NotImplementedException();
            }
        }

        public class MockedLogger : Logger
        {         
            public MockedLogger() : base() { }
        }

        [Fact]
        public void TestLogging()
        {
            var logger = new MockedLogger();
            var transport = new ListLogTransport();
            var transport2 = new ListLogTransport();
            logger.AddTransport(transport);
            logger.AddTransport(transport2);
            logger.Info("This is an info log");
            logger.Error("This is an error log");
            logger.Warn("This is a warning log");
            TestMatches(transport);
            TestMatches(transport2);
        }

        private void TestMatches(ListLogTransport transport)
        {
            Assert.Equal(3, transport.Logs.Count);
            Assert.Matches(@"\[INFO\] .+ This is an info log", transport.Logs[0]);
            Assert.Matches(@"\[ERROR\] .+ This is an error log", transport.Logs[1]);
            Assert.Matches(@"\[WARN\] .+ This is a warning log", transport.Logs[2]);
        }
    }
}
