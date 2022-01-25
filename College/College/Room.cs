using CollegeManager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CollegeManager
{
    public enum RoomType
    {
        SPECIAL,
        SOCIAL,
        DORM
    }
    public abstract class Room : ObservableObject
    {
        public int Number { get; set; }
        public Floor Floor { get; }
        public string DoorNumber => Floor.FloorNumber == 0 ? $"F{Number}" : $"{Floor.FloorNumber * (Math.Pow(10, Math.Max(Floor.RoomCount.ToString().Length, 2))) + Number}";

        public Room(Floor floor) 
        {
            Floor = floor;
        }

        public Room(Room room) : this(room.Floor)
        {
            Complainments = room.Complainments;
            Inventory = room.Inventory;
        }

        public ObservableCollection<Complainment> Complainments { get; private set; } = new ObservableCollection<Complainment>();
        public ObservableCollection<RoomItem> Inventory{ get; private set; } = new ObservableCollection<RoomItem>();

        public void AddItem(Item item, int amount)
        {
            if (item.HasAvailable(amount))
            {
                if (item.HasLocation(this))
                    item.AddToLocation(this, amount);
                else
                    item.AddLocation(this, amount);

                var actualRoomItem= FindRoomItemByItem(item);
                if(!(actualRoomItem is null))
                    actualRoomItem.Integer.Value += amount;
                else
                    Inventory.Add(new RoomItem(item, new Integer() { Value = amount }));
            }
        }
        
        public RoomItem FindRoomItemByItem(Item item)
        {
            return Inventory.Where((roomItem) => roomItem.Item == item).SingleOrDefault();
        }
        public void RemoveItem(RoomItem roomItem)
        {
            if (roomItem is null) return;
            Inventory.Remove(roomItem);
            roomItem.Item.RemoveLocation(this);
        }

        public void RemoveItem(Item item)
        {
            Inventory.Remove(FindRoomItemByItem(item));
            item.RemoveLocation(this);
        }

        public void AddComplaint(Complainment complaint) 
        {
            Complainments.Add(complaint);
        }

        public virtual void Reset()
        {
            Complainments.Clear();
            foreach(var item in Inventory)
                item.Item.RemoveLocation(this);
            Inventory.Clear();
        }
    }
}