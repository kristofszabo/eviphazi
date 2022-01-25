using CollegeManager;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class DormRoomTest
    {
        [Fact]
        public void RemoveStudentTest()
        {
            var dormRoom = new DormRoom(new Floor(0, new College()));
            var student = new Student("valaki", "valaki@mail.com", "fsdaf");
            dormRoom.AddStudent(student);
            dormRoom.RemoveStudent(student);
            Assert.Empty(dormRoom.Students);
        }

        [Fact]
        public void RoomFullTest()
        {
            var dormRoom = new DormRoom(new Floor(0, new College()));
            var student = new Student("valaki", "valaki@mail.com", "fsdaf");
            var student1 = new Student("valaki", "valaki@mail.com", "fsdaf");
            var student2 = new Student("valaki", "valaki@mail.com", "fsdaf");
            var student3 = new Student("valaki", "valaki@mail.com", "fsdaf");
            dormRoom.AddStudent(student);
            dormRoom.AddStudent(student1);
            dormRoom.AddStudent(student2);
            dormRoom.AddStudent(student3);
            Assert.True(dormRoom.IsFull());
        }

        [Fact]
        public void ResetTest()
        {
            var dormRoom = new DormRoom(new Floor(0, new College()));
            var student = new Student("valaki", "valaki@mail.com", "fsdaf");
            var student1 = new Student("valaki", "valaki@mail.com", "fsdaf");
            var student2 = new Student("valaki", "valaki@mail.com", "fsdaf");
            var student3 = new Student("valaki", "valaki@mail.com", "fsdaf");
            dormRoom.AddStudent(student);
            dormRoom.AddStudent(student1);
            dormRoom.AddStudent(student2);
            dormRoom.AddStudent(student3);
            dormRoom.Reset();
            Assert.Empty(dormRoom.Students);
            Assert.Empty(dormRoom.Inventory);
            Assert.Empty(dormRoom.Complainments);
            
        }

        [Fact]
        public void RemoveStudentsTest()
        {
            var dormRoom = new DormRoom(new Floor(0, new College()));
            var student = new Student("valaki", "valaki@mail.com", "fsdaf");
            dormRoom.AddStudent(student);
            dormRoom.RemoveStudents();
            Assert.Empty(dormRoom.Students);
        }
    }
}
