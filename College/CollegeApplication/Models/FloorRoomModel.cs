using System.Collections.ObjectModel;
using System.ComponentModel;
using CollegeManager;

namespace CollegeApplication.Models
{
    public class FloorRoomModel : ObservableObject
    {
        private College college;

        public FloorRoomModel(College college)
        {
            this.college = college;
            college.PropertyChanged += Collage_PropertyChanged;
        }

        private void Collage_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FloorCount))
            {
                Notify(nameof(FloorCount));
                Notify(nameof(CanDeleteLastFloor));
            }
        }

        public ObservableCollection<Floor> Floors => college.Floors;

        public int FloorCount => college.FloorCount;

        public bool CanDeleteLastFloor => college.CanRemoveLastFloor();

        public void AddFloorToCollege()
        {
            college.AddFloor();
        }

        public void DeleteLastFloor()
        {
            college.RemoveLastFloor();
        }
    }
}
