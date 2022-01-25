using CollegeManager.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManager
{
   public class RoomItem : ObservableObject
    {
        public RoomItem(Item item, Integer integer) : base()
        {
            this.item = item;
            this.integer = integer;
        }

        private Item item;
        public Item Item
        {
            get => item; 
            set 
            {
                item = value;
                NotifyByName();
            }
        }

        private Integer integer;
        public Integer Integer
        {
            get => integer;
            set {
                integer = value;
                NotifyByName();
            }
        }
    }
}
