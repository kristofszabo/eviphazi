using CollegeApplication.ViewModels;
using CollegeApplication.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System;
using CollegeManager;

namespace CollegeApplication.Views
{
    public sealed partial class FloorRoomView : Page
    {
        public FloorRoomViewModel ViewModel { get; private set; }
        private Frame ContentFrame;
        private NavigationInfo navInfo;

        public FloorRoomView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var info = e.Parameter as NavigationInfo;
            var floorIndexToDisplay = info.Parameter is int ? (int)info.Parameter : -1; 
            ViewModel = new FloorRoomViewModel(info.College);
            if(floorIndexToDisplay >= 0 && floorIndexToDisplay < ViewModel.FloorCount)
            {
                ViewModel.SelectedFloorIndex = floorIndexToDisplay;
            }
            ContentFrame = info.ContentFrame;
            navInfo = info;
        }

        private void RoomButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var number = int.Parse(button.Tag.ToString());
            var room = ViewModel.SelectedFloor.Rooms[number-1];
            navInfo.Parameter = new ChangeRoomViewModel(room, false);
            ContentFrame.Navigate(typeof(RoomView), navInfo);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.HasFloor) return;
            if(ViewModel.SelectedFloorIndex <= 0)
            {
                ViewModel.SelectedFloorIndex = ViewModel.FloorCount - 1;
                return;
            }
            ViewModel.SelectedFloorIndex--;
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.HasFloor) return;
            if (ViewModel.SelectedFloorIndex >= ViewModel.FloorCount - 1)
            {
                ViewModel.SelectedFloorIndex = 0;
                return;
            }
            ViewModel.SelectedFloorIndex++;
        }

        private void FloorAdd_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Model.AddFloorToCollege();
            var index = ViewModel.FloorCount - 1;
            ViewModel.SelectedFloorIndex = index;
            Logger.Instance.Info($"Új emelet ({index}) hozzáadva a kollégiumhoz!");
        }

        private void RoomAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.HasFloor)
            {
                _ = new MessageDialog("Nincs emelet, amihez hozzá lehetne adni a szobát!", "Hiba").ShowAsync();
                Logger.Instance.Warn("Valaki szobát próbált felvenni, miközben nincsenek még emeletek se!");
                return;
            }
            var room = new DormRoom(ViewModel.SelectedFloor);
            ViewModel.SelectedFloor.AddRoom(room);
            Logger.Instance.Info($"Új szoba hozzáadva a(z) {ViewModel.SelectedFloorIndex}. emelethez!");
            navInfo.Parameter = new ChangeRoomViewModel(room, true);
            ContentFrame.Navigate(typeof(RoomView), navInfo);
        }

        private async void LastFloorDelete_Click(object sender, RoutedEventArgs e)
        {
            if(!ViewModel.HasFloor)
            {
                await new MessageDialog("Még nincs egy hozzáadott emelet se!", "Hiba").ShowAsync();
                Logger.Instance.Error($"Az utolsó emelet törlése nem lehetséges, ha nem létezik egy emelet se!");
                return;
            }

            if(!ViewModel.CanDeleteLastFloor)
            {
                DeleteLastFloorWithPopup();
                return;
            }

            ViewModel.DeleteLastFloor();
            Logger.Instance.Info($"Utolsó emelet ({ViewModel.FloorCount}) ki lett törölve.");
        }

        private async void DeleteLastFloorWithPopup()
        {
            var dialog = new MessageDialog("Az utolsó emelet törlése maga után vonja, az emeleten található összes szoba törlését, és minden ezen szobákhoz tartozó adat törlését! Biztosan folytatja?");
            dialog.Commands.Add(new UICommand("Igen", new UICommandInvokedHandler(CommandInvokedHandler)));
            dialog.Commands.Add(new UICommand("Nem", new UICommandInvokedHandler(CommandInvokedHandler)));
            await dialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Igen")
            {
                ViewModel.DeleteLastFloor();
                Logger.Instance.Info($"Utolsó emelet ({ViewModel.FloorCount}) ki lett törölve.");
            }
        }
    }
}
