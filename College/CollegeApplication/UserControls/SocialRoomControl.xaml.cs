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
    public sealed partial class SocialRoomControl : UserControl
    {
        public CommonRoom CommonRoom { get; set; }

        public SocialRoomControl()
        {
            this.InitializeComponent();
        }

        private void SocialRoomTypeSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            CommonRoom.Type = (SocialRoom)(sender as ComboBox).SelectedItem;
        }
    }
}
