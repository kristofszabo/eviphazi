using System.Collections.ObjectModel;
using CollegeApplication.Models;
using CollegeManager;

namespace CollegeApplication.ViewModels
{
    public class ElevatorViewModel : ObservableObject
    {
        private ElevatorModel Model { get; }

        public ObservableCollection<Elevator> Elevators => Model.Elevators;

        public ElevatorViewModel(College college)
        {
            Model = new ElevatorModel(college);
        }

        public void StartSimulation()
        {
            Model.StartSimulation();
        }

        public void StopSimulation()
        {
            Model.StopSimulation();
        }
    }
}
