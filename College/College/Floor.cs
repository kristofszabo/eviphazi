using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollegeManager
{
    public class Floor 
    {
        public int RoomCount { get; private set; } = 0;
        public College College { get; private set; }
        public Floor(int floorNumber, College college)
        {
            FloorNumber = floorNumber;
            College = college;
        }

        public Floor(int floorNumber, College college, params Room[] rooms) : this(floorNumber, college)
        {
            Rooms = new ObservableCollection<Room>(rooms);
        }

        public ObservableCollection<Room> Rooms { get; private set; } = new ObservableCollection<Room>();
        public int FloorNumber { get; private set; }

        public void AddRoom(Room room) 
        {
            RoomCount++;
            room.Number = RoomCount;
            Rooms.Add(room);
        }

        public void DeleteRoom(Room room)
        {
            var index = Rooms.IndexOf(room);
            if (index == -1) return;
            room.Reset();
            Rooms.RemoveAt(index);
            for (int i = index; i < Rooms.Count; i++)
                Rooms[i].Number--;
            RoomCount--;
        }

        public void SaveRoom(Room oldRoom, Room newRoom)
        {
            var index = Rooms.IndexOf(oldRoom);
            College.ChangeRoomItemLocation(oldRoom, newRoom);
            newRoom.Number = oldRoom.Number;
            Rooms[index] = newRoom;
        }

        public void DeleteAllRoom()
        {
            foreach (var room in Rooms)
                room.Reset();
            Rooms.Clear();
            RoomCount = 0;
        }
    }
}