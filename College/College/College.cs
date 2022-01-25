using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace CollegeManager
{
    public class College : ObservableObject 
    {
        public ObservableCollection<Floor> Floors { get; private set; } = new ObservableCollection<Floor>();
        public ObservableCollection<Student> Students { get; private set; } = new ObservableCollection<Student>();
        public ObservableCollection<Elevator> Elevators { get; private set; } = new ObservableCollection<Elevator>();
        public ObservableCollection<Circle> Circles { get; private set; } = new ObservableCollection<Circle>();
        public ObservableCollection<Item> Items { get; private set; } = new ObservableCollection<Item>();

        private int _floorCount = 0;
        public int FloorCount 
        {
            get => _floorCount;
            private set
            {
                _floorCount = value;
                NotifyByName();
            }
        }

        public void RegisterStudent(Student student) 
        {
            if (Students.Any(student1 => student1.Neptun.Equals(student.Neptun))) return;
            Students.Add(student);
        }

        public void AddElevator() 
        {
            Elevators.Add(new Elevator(this) { Id = $"{(char)(65 + Elevators.Count)}" });
        }

        public void AddFloor()
        {
            Floors.Add(new Floor(FloorCount, this));
            FloorCount++;
        }

        public void RemoveLastFloor()
        {
            if(CanRemoveLastFloor())
            {
                Floors.RemoveAt(Floors.Count - 1);
                FloorCount--;
            }
        }

        public bool CanRemoveLastFloor()
        {
            return Floors.Any() && Floors[Floors.Count - 1].RoomCount == 0;
        }

        public void RemoveCircle(Circle circle)
        {
            circle.RemoveAllMembers();
            Circles.Remove(circle);
        }

        public void AddCircle(Circle circle)
        {
            if (Circles.Any(circle1 => circle1.Name.Equals(circle.Name))) return;
            Circles.Add(circle);
        }

        public void AddItem(Item item) 
        {
            if (Items.Any(item1 => item1.Name.ToLower() == item.Name.ToLower())) return;
            Items.Add(item);
        }

        public void AddItem(Item item, int amount)
        {
            if (amount < 0) return;
            foreach (var item1 in Items)
                if (item1.Name == item.Name) item1.Amount += amount;
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
            foreach (var floor in Floors)
                foreach (var room in floor.Rooms)
                    room.RemoveItem(item);
        }

        public void ChangeRoomItemLocation(Room oldRoom, Room newRoom)
        {
            foreach (var item in newRoom.Inventory)
            {
                item.Item.ChangeLocationRoom(oldRoom, newRoom);
            }
            
        }

        public void CheckOutStudent(Student student) 
        {
            RemoveStudentFromRoom(student);
            foreach(var circle in student.Circles)
            {
                circle.RemoveMember(student);
                if (circle.Leader == student) circle.Leader = null;
            }
            Students.Remove(student);
        }

        public void AssignStudentToRoom(Student student, DormRoom room)
        {
            RemoveStudentFromRoom(student);
            room.AddStudent(student);
            student.Room = room;
        }

        public void RemoveStudentFromRoom(Student student) 
        {
            if (!(student.Room is null))
            {
                student.Room.RemoveStudent(student);
            }
            student.Room = null;
        }
    }
}