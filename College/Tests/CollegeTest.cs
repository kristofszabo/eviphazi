using CollegeManager;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Tests
{
    public class CollegeTest
    {
        [Fact]
        public void CanAddStudentToRoomTest()
        {
            College college = new College();
            Student student = new Student("Béla","bela@mail.com","RASZTA");
            college.RegisterStudent(student);
            college.AddFloor();
            var floor = college.Floors[0];
            var room = new DormRoom(floor);
            floor.AddRoom(room);
            college.AssignStudentToRoom(student, room);
            Assert.Equal(room, student.Room);
        }

        [Fact]
        public void CheckOutStudentTest()
        {
            College college = new College();
            Student student = new Student("Béla","bela@mail.com","RASZTA");
            college.RegisterStudent(student);
            college.AddFloor();
            var floor = college.Floors[0];
            var room = new DormRoom(floor);
            college.CheckOutStudent(student);
            Assert.DoesNotContain(student, college.Students);
            Assert.DoesNotContain(student, room.Students);
            Assert.Null(student.Room);
        }
        [Fact]
        public void RemoveStudentFromRoomTest()
        {
            College college = new College();
            Student student = new Student("Béla","bela@mail.com","RASZTA");
            college.RegisterStudent(student);
            college.AddFloor();
            var floor = college.Floors[0];
            var room = new DormRoom(floor);
            room.AddStudent(student);
            college.RemoveStudentFromRoom(student);
            Assert.Null(student.Room);
        }

        [Fact]
        public void CheckAddMoreItem()
        {
            College college = new College();
            var item = new Item("valami", 10);

            college.AddItem(item);
            college.AddItem(item);
            Assert.Equal(10, college.Items[0].Amount);
            college.AddItem(item, 5);
            Assert.Equal(15, college.Items[0].Amount);
            college.AddFloor();
            var floor = college.Floors[0];
            var room = new DormRoom(floor);
            room.AddItem(item, 5);
            college.RemoveItem(item);
            Assert.Empty(college.Items);
        }

        [Fact]
        public void AddElevatorTest()
        {
            College college = new College();
            college.AddElevator();
            Assert.Equal(college.Elevators.Count, 1);
        }

        [Fact]
        public void RemoveLastFloorTest()
        {
            College college = new College();
            college.AddFloor();
            var floor = college.Floors[0];
            Assert.True(college.CanRemoveLastFloor());
            college.RemoveLastFloor();
            Assert.DoesNotContain(floor, college.Floors);
        }

        [Fact]
        public void CheckFloorNumberTest()
        {
            College college = new College();
            college.AddFloor();
            college.AddFloor();
            college.AddFloor();
            college.AddFloor();
            Assert.Equal(4, college.FloorCount);
        }

        [Fact]
        public void AddAndRemoveCircleTest()
        {
            College college = new College();

            Student student = new Student("Béla","bela@mail.com","RASZTA");
            college.RegisterStudent(student);
            var circle = new Circle("Semmi", student, "Nincsen");
            college.AddCircle(circle);
            Assert.Equal(student, college.Circles[0].Leader);
            college.RemoveCircle(circle);
            Assert.DoesNotContain(circle, college.Circles);
        }

        [Fact]
        public void ChangeItemsRoom()
        {
            College college = new College();
            college.AddFloor();
            var floor = college.Floors[0];
            var room = new DormRoom(floor);
            floor.AddRoom(room);
            var room2 = new SpecialRoom(room);
            var item = new Item("valami", 10);
            room.AddItem(item, 5);
            college.ChangeRoomItemLocation(room, room2);
            Assert.True(item.HasLocation(room2));
        }
    }
}
