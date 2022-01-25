using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeManager
{
    public class SpecialRoom : Room 
    {
        public SpecialRoom(Floor floor, SpecialRoomType type) : base(floor) 
        {
            RoomType = type;
        }

        public SpecialRoom(Room room) : base(room) {
            RoomType = SpecialRoomType.NORMAL;
        }

        private SpecialRoomType roomType;
        public SpecialRoomType RoomType
        {
            get => roomType;
            set {
                roomType = value;
                Notify(nameof(RoomType));
            }
        }

        public string Description { get; set; }
    }
}
