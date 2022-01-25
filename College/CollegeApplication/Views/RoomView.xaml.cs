using CollegeManager;
using CollegeManager.Util;
using CollegeApplication.Utils;
using CollegeApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace CollegeApplication.Views
{
    public sealed partial class RoomView : Page
    {
        private NavigationInfo navInfo;

        public Room EditedRoom { get; set; }
        public Room Room { get; set; }
        public College College { get; set; }

        public static IEnumerable<SocialRoom> SocialRoomType = Enum.GetValues(typeof(SocialRoom)).Cast<SocialRoom>();
        public static IEnumerable<SpecialRoomType> SpecialRoomTypes = Enum.GetValues(typeof(SpecialRoomType)).Cast<SpecialRoomType>();
        public static IEnumerable<RoomType> RoomTypes = Enum.GetValues(typeof(RoomType)).Cast<RoomType>();

        public RoomView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var info = e.Parameter as NavigationInfo;
            var room = info.Parameter as ChangeRoomViewModel;
            Room = room.Room;
            EditedRoom = Room;
            navInfo = info;
            navInfo.Parameter = Room.Floor.FloorNumber;
        }

        private void AddNewItem_Button(object sender, RoutedEventArgs e)
        {
            var item = MyItemControl.SelectedItem;
            if (item is null) return;
            Room.AddItem(item, 1);
            Logger.Instance.Info("Tárgy szobához adása: (Név: " + item.Name + ", Szobaszám: " + Room.DoorNumber + ")");
        }

        private void DeleteItemFromRoom_Button(object sender, RoutedEventArgs e)
        {
            var item = MyRoomInventory.MySelectedItem;
            Room.RemoveItem(item);
            Logger.Instance.Info("Tárgy törlése szobából: (Név: " + item.Item.Name + ", Szobaszám: " + Room.DoorNumber + ")");
        }

        private void DeleteRoom_Button(object sender, RoutedEventArgs e)
        {
            var currentFloor = Room.Floor;
            currentFloor.DeleteRoom(Room);
            navInfo.ContentFrame.Navigate(typeof(FloorRoomView), navInfo);
            Logger.Instance.Info("Szoba törlése: " + Room.DoorNumber);
        }

        private void RoomTypeChanged_ComboBox(object sender, SelectionChangedEventArgs e)
        {
            var oldRoomTypeObject = e.RemovedItems.FirstOrDefault();
            if (oldRoomTypeObject is null) return;
            var oldRoomType = (RoomType)oldRoomTypeObject;
            var newRoomType = (RoomType) e.AddedItems.FirstOrDefault();
            if (oldRoomType == newRoomType) return;
            MyContentControl.Content = null;
            switch (newRoomType)
            {
                case RoomType.DORM:
                    EditedRoom = new DormRoom(Room);
                    break;
                case RoomType.SOCIAL:
                    EditedRoom = new CommonRoom(Room);
                    break;
                case RoomType.SPECIAL:
                    EditedRoom = new SpecialRoom(Room);
                    break;
            }
            if (Room is DormRoom)
                (Room as DormRoom).RemoveStudents();
            MyContentControl.Content = EditedRoom;
            Room.Floor.SaveRoom(Room, EditedRoom);
            Room = EditedRoom;
        }

        private void CloseWindow_Button(object sender, RoutedEventArgs e)
        {
            navInfo.ContentFrame.Navigate(typeof(FloorRoomView), navInfo);
        }
    }
}
