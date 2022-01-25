using CollegeManager;
using CollegeManager.Util;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace CollegeApplication.UserControls
{
    public sealed partial class RoomInventoryControl : UserControl
    {
        public ObservableCollection<RoomItem> RoomInventory { get; set; }

        public RoomItem MySelectedItem { get; set; }

        public RoomInventoryControl()
        { 
            this.InitializeComponent();   
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var roomItem =(sender as ListView).SelectedItem;
            if (roomItem is null) return;
            MySelectedItem = roomItem as RoomItem;
        }
    }
}
