using CollegeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CollegeApplication.UserControls
{
    public sealed partial class SpecialRoomControl : UserControl
    {
        public SpecialRoom SpecialRoom{ get; set; }

        public SpecialRoomControl()
        {
            this.InitializeComponent();
        }

        private void SpecialRoomTypeSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            SpecialRoom.RoomType = (SpecialRoomType)(sender as ComboBox).SelectedItem;
        }
    }
}
