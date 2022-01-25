using CollegeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplication.ViewModels
{
    public class LoggerViewModel : ObservableObject
    {
        private List<LogData> logs;
        public List<LogData> Logs
        {
            get => logs;
            set
            {
                logs = value;
                NotifyByName();
            }
        }

        public async Task<List<LogData>> ReadLogs(DateTime dateTime)
        {
            return await Task.Run(() => Logger.Instance.ReadAllLogsByDay(dateTime));
        }
    }
}
