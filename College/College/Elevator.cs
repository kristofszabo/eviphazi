using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeManager
{
    public class Elevator : ObservableObject
    {
        private College college;

        public Elevator(College college)
        {
            this.college = college;
        }

        public string Id { get; set; }

        private int _currentFloor;
        public int CurrentFloor
        {
            get => _currentFloor;
            private set
            {
                _currentFloor = value;
                NotifyByName();
            }
        }

        private int _newFloor;
        public int NewFloor
        {
            get => _newFloor;
            private set
            {
                _newFloor = value;
                NotifyByName();
            }
        }

        private bool _isWorking = true;
        public bool IsWorking
        {
            get => _isWorking;
            private set
            {
                if (_isWorking == value) return;
                _isWorking = value;
                NotifyByName();
            }
        }

        public void RandomSimulationCall()
        {
            var random = new Random();
            int chanceToBroke = random.Next(0, 20);
            IsWorking = chanceToBroke > 1;
            if (!IsWorking) return;
            CurrentFloor = NewFloor;
            NewFloor = random.Next(0, college.FloorCount - 1);     
        }
    }
}