using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeManager
{
    public class CommonRoom : Room 
    {
        public CommonRoom(Floor floor, SocialRoom type) : base(floor)
        {
            this.type = type;
        }

        public CommonRoom(Room room) : base(room)
        {
            type = SocialRoom.STUDY;
        }

        private SocialRoom type;
        public SocialRoom Type
        {
            get => type;
            set {
                type = value;
                Notify(nameof(Type));
            }
        }
    }
}
