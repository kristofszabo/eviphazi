using CollegeManager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeManager
{
    public class Item : ObservableObject
    {
        private Dictionary<Room, Integer> locations = new Dictionary<Room, Integer>();

        private int amount;
        public int Amount {
            get => amount;
            set 
            {
                if (value >= NumberOfItemsInRooms)
                    amount = value;
                NotifyByName();
            }
        }
        
        public string Name { get; private set; }

        public void ChangeLocationRoom(Room oldRoom, Room newRoom)
        {
            if (!locations.ContainsKey(oldRoom)) return;
            var oldInteger = locations[oldRoom];
            locations.Remove(oldRoom);
            locations.Add(newRoom, oldInteger);
        }

        public IEnumerable<KeyValuePair<Room,Integer>> GetAllLocationsWithAmounts() => locations.AsEnumerable();
        
        public Item(string name, int amount) 
        {
            Name = name;
            Amount = amount;
        }

        private int NumberOfItemsInRooms => locations.Values.Aggregate(0, (accumulator, currentValue) => accumulator + currentValue.Value);
            
        public bool HasAvailable(int amount) => Amount - amount >= NumberOfItemsInRooms;

        public bool HasLocation(Room room) => locations.ContainsKey(room);

        public void AddLocation(Room room, int amount)
        {
            if (amount <= 0) return;

            if(!HasLocation(room) && HasAvailable(amount))
                locations.Add(room, new Integer() { Value = amount });
        }

        public Integer GetAmountByLocation(Room room) => locations[room];
        
        public void AddToLocation(Room room, int amount)
        {
            if (amount <= 0) return;

            if (HasLocation(room) && HasAvailable(amount))
                locations[room].Value += amount;
        }

        public void RemoveFromLocation(Room room, int amount)
        {
            if (amount <= 0) return;

            var roomAmount = locations[room];
            if (HasLocation(room))
                roomAmount.Value -= amount;
            if (roomAmount.Value <= 0)
                locations.Remove(room);
        }

        public void RemoveLocation(Room room) => locations.Remove(room);
    }
}
