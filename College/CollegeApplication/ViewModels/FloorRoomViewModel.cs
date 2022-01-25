using System.Linq;
using System.ComponentModel;
using CollegeManager;
using CollegeApplication.Models;
using System.Collections.ObjectModel;

namespace CollegeApplication.ViewModels
{
    public class FloorRoomViewModel : ObservableObject
    {
        public FloorRoomModel Model { get; }

        public int FloorCount => Model.FloorCount;

        private int _selectedFloorIndex;
        public int SelectedFloorIndex
        {
            get => _selectedFloorIndex;
            set
            {
                _selectedFloorIndex = value;
                NotifyByName();
                Notify(nameof(SelectedFloor));
                Notify(nameof(ComplainmentsInFloor));
                Notify(nameof(RoomCountInSelectedFloor));
                Notify(nameof(SelectedFloorRooms));
            }
        }

        public Floor SelectedFloor => Model.Floors[_selectedFloorIndex];
        public ObservableCollection<Room> SelectedFloorRooms =>  HasFloor ? SelectedFloor.Rooms : null;
        public ObservableCollection<Floor> Floors => Model.Floors;
        public int ComplainmentsInFloor => HasFloor ? SelectedFloor.Rooms.Aggregate(0, (acc, curr) => acc + curr.Complainments.Count) : 0;
        public int RoomCountInSelectedFloor => HasFloor ? SelectedFloor.RoomCount : 0;
        public bool CanDeleteLastFloor => Model.CanDeleteLastFloor;
        public bool HasFloor => Floors.Count > 0;

        public FloorRoomViewModel(College college)
        {
            Model = new FloorRoomModel(college);
            Model.PropertyChanged += Model_PropertyChanged;
            SelectedFloorIndex = HasFloor ? 0 : -1;
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FloorCount))
                Notify(nameof(FloorCount));
        }

        public void DeleteLastFloor()
        {
            var lastIndex = Floors.Count - 1;
            if (SelectedFloorIndex == lastIndex && lastIndex > 0)
                SelectedFloorIndex--;
            Floors[lastIndex].DeleteAllRoom();
            Model.DeleteLastFloor();
            if (lastIndex == 0) SelectedFloorIndex = -1; 
        }
    }
}
