using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using CollegeManager;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace CollegeApplication.Models
{
    public class ElevatorModel
    {
        public ObservableCollection<Elevator> Elevators { get; }

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public ElevatorModel(College college)
        {
            Elevators = college.Elevators;
        }

        public void StartSimulation()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (_tokenSource.Token.IsCancellationRequested) return;
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        foreach (var elevator in Elevators)
                            elevator.RandomSimulationCall();
                    });
                    await Task.Delay(2000);
                }
            }, _tokenSource.Token);
        }

        public void StopSimulation()
        {
            _tokenSource.Cancel();
            _tokenSource.Dispose();
        }
    }
}
