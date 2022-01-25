using CollegeManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollegeApplication.Models
{
    public class WarehouseModel
    {
        private College college;

        public ObservableCollection<Item> Items => college.Items;

        public WarehouseModel(College college)
        {
            this.college = college;
        }

        public void RemoveItem(Item item)
        {
            college.RemoveItem(item);
        }

        public void AddItem(Item item)
        {
            college.AddItem(item);
        }
    }
}
