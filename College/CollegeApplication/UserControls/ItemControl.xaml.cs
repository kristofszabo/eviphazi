using CollegeManager;
using CollegeManager.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CollegeApplication.UserControls
{
    public sealed partial class ItemControl : UserControl
    {
        public ObservableCollection<Item> Items { get; set; }
        public Item SelectedItem { get; set; }

        public ItemControl()
        {
            this.InitializeComponent();
        }
    }
}
