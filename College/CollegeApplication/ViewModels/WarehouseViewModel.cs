using CollegeManager;
using CollegeApplication.Models;
using System.Collections.ObjectModel;

namespace CollegeApplication.ViewModels
{
    public class WarehouseViewModel : ObservableObject
    {
        private WarehouseModel _model;
        public ObservableCollection<Item> Items => _model.Items;

        public WarehouseViewModel(College college)
        {
            _model = new WarehouseModel(college);
        }

        private string _itemName = "";
        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                NotifyByName();
            }
        }

        private string _itemAmount = "";
        public string ItemAmount
        {
            get => _itemAmount;
            set
            {
                _itemAmount = value;
                NotifyByName();
            }
        }

        public void RemoveItem(Item item)
        {
            _model.RemoveItem(item);
        }

        public void AddItem(Item item)
        {
            _model.AddItem(item);
            ItemAmount = "";
            ItemName = "";
        }
    }
}
