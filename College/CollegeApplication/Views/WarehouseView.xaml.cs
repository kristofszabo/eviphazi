using CollegeManager;
using CollegeApplication.Utils;
using CollegeApplication.ViewModels;
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CollegeApplication.Views
{
    public sealed partial class WarehouseView : Page
    {
        public WarehouseViewModel ViewModel { get; private set; }

        public WarehouseView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var info = e.Parameter as NavigationInfo;
            ViewModel = new WarehouseViewModel(info.College);
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = ExtractItem(sender);
            ViewModel.RemoveItem(item);
            Logger.Instance.Info($"Tárgy: \"{item.Name}\" teljesen törölve!");
        }

        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            var item = ExtractItem(sender);
            if (item.HasAvailable(1))
            {
                item.Amount--;
                return;
            }
            Logger.Instance.Warn($"A(z) \"{item.Name}\" mennyiségét a megengedett alá próbálták csökkenteni!");
            _ = new MessageDialog("Nem lehet a mennyiséget ennél kevesebbre csökkenteni!", "Hiba").ShowAsync();
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            var item = ExtractItem(sender);
            item.Amount++;
        }

        private Item ExtractItem(object sender)
        {
            var itemName = ((Button)sender).Tag.ToString();
            foreach (var item in ViewModel.Items)
                if (item.Name == itemName) return item;
            return null;
        }

        private async void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ItemName.Trim() == "" || ViewModel.ItemAmount.Trim() == "") return;
            if(ViewModel.Items.Any(item => item.Name.ToLower() == ViewModel.ItemName.ToLower()))
            {
                Logger.Instance.Error($"A(z) \"{ViewModel.ItemName.Trim()}\" tárgy már fel van véve, a névnek egyedinek kell lennie!");
                await new MessageDialog("Már van ilyen nevű tárgy a raktárban!", "Hiba").ShowAsync();
                return;
            }
            var newItem = new Item(ViewModel.ItemName, int.Parse(ViewModel.ItemAmount));
            ViewModel.AddItem(newItem);
            Logger.Instance.Info($"Tárgy: \"{newItem.Name} ({newItem.Amount})\" felvéve a raktárba!");
        }
    }
}
