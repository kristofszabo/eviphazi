using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollegeManager
{
    public class DormRoom : Room {
        private static int MaxCapacity => 4;

        public DormRoom(Floor floor): base(floor) { }

        public DormRoom(Room room) : base(room) { }

        public ObservableCollection<Student> Students { get; } = new ObservableCollection<Student>();

        public void AddStudent(Student student) 
        {
            if(student is null)
                throw new NullReferenceException();

            if (!IsFull() && !Students.Contains(student))
                Students.Add(student);
        }

        public void RemoveStudent(Student student) 
        {
            if(Students.Contains(student))
            {
                Students.Remove(student);
                student.Room = null;
            }
        }

        public bool IsFull() 
        {
            return Students.Count >= DormRoom.MaxCapacity;
        }

        public override void Reset()
        {
            base.Reset();
            RemoveStudents();
        }

        public void RemoveStudents()
        {
            foreach (var student in Students)
                student.Room = null;
            Students.Clear();
        }
    }
}
