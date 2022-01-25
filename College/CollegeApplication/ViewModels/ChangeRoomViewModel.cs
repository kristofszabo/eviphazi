using CollegeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeApplication.ViewModels
{
    public class ChangeRoomViewModel
    {
        public bool IsAdd { get; private set; }
        public Room Room { get; set; }

        public ChangeRoomViewModel(Room room, bool isAdd)
        {
            Room = room;
            IsAdd = isAdd;
        }
    }
}
