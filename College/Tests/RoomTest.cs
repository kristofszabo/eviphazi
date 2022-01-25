using CollegeManager;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class RoomTest
    {
        [Fact]
        public void AddItemMultipleTimesTest()
        {
            var college = new College();
            var item = new Item("tej", 10);
            var floor = new Floor(0, college);
            var room = new DormRoom(floor);

            room.AddItem(item, 2);
            Assert.Equal(2, room.FindRoomItemByItem(item).Integer.Value);

            room.AddItem(item, 1);
            Assert.Equal(3, room.FindRoomItemByItem(item).Integer.Value);
        }

        [Fact]
        public void TryAddMoreItemThanHas()
        {
            var college = new College();
            var item = new Item("tej", 1);
            var floor = new Floor(0, college);
            var room = new DormRoom(floor);
            room.AddItem(item, 2);
            Assert.Empty(room.Inventory);
        }

        [Fact]
        public void RemoveItemFromInventory()
        {
            var college = new College();
            var item = new Item("tej", 2);
            var floor = new Floor(0, college);
            var room = new DormRoom(floor);
            room.AddItem(item, 2);
            room.RemoveItem(item);
            Assert.Empty(room.Inventory);
        }

        [Fact]
        public void AddComplainmentTest()
        {
            var college = new College();
            var floor = new Floor(0,college);
            var room = new DormRoom(floor);
            string description ="Valami probléma van";
            var complainment = new Complainment(description);
            room.AddComplaint(complainment);
            Assert.Contains(complainment, room.Complainments);
        }
    }
}
