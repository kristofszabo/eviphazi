using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CollegeApplication.Views;
using Windows.UI.Xaml.Media.Animation;
using CollegeApplication.Utils;
using CollegeManager;
using CollegeManager.Transports;

namespace CollegeApplication
{
    public sealed partial class MainPage : Page
    {
        private College college = new College();
        private NavigationTransitionInfo navTransition = new DrillInNavigationTransitionInfo();

        public MainPage()
        {
            this.InitializeComponent();
            Logger.Instance.AddTransport(new DailyRotateFileTransport());
            AddRandomDataToCollege();
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(FloorRoomView), new NavigationInfo(ContentFrame, college), navTransition);
        }

        private void Menu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            HandleNavigation(item);
        }

        private void HandleNavigation(NavigationViewItem item)
        {
            if (item is null) return;
            var navigationInfo = new NavigationInfo(ContentFrame, college);

            switch (item.Name)
            {
                case "floors":
                    ContentFrame.Navigate(typeof(FloorRoomView), navigationInfo, navTransition);
                    break;
                case "students":
                    ContentFrame.Navigate(typeof(StudentView), navigationInfo, navTransition);
                    break;
                case "circles":
                    ContentFrame.Navigate(typeof(CircleView), navigationInfo, navTransition);
                    break;
                case "warehouse":
                    ContentFrame.Navigate(typeof(WarehouseView), navigationInfo, navTransition);
                    break;
                case "lifts":
                    ContentFrame.Navigate(typeof(ElevatorView), navigationInfo, navTransition);
                    break;
                case "logs":
                    ContentFrame.Navigate(typeof(LoggerView), navigationInfo, navTransition);
                    break;
            }
        }

        private void AddRandomDataToCollege()
        {
            for (int i = 0; i < 5; i++) college.AddFloor();

            var random = new Random();
            
            var items = new Item[] { new Item("Sötétítő függöny", 4000), new Item("Asztal", 2000), new Item("Forgószék", 300) };
            foreach(var item in items) college.AddItem(item);

            foreach (var floor in college.Floors)
            {
                floor.AddRoom(new CommonRoom(floor, SocialRoom.KITCHEN));
                floor.AddRoom(new CommonRoom(floor, SocialRoom.CLUB));
                floor.AddRoom(new CommonRoom(floor, SocialRoom.STUDY));
                floor.AddRoom(new SpecialRoom(floor, SpecialRoomType.GYM));
                for (int i = 0; i < random.Next(10, 15); i++)
                {
                    var room = new DormRoom(floor);
                    if (random.Next(1, 3) == 2) room.AddComplaint(new Complainment("Teszt panasz"));
                    var itemToAdd = items[random.Next(0, 2)];
                    if (itemToAdd.HasAvailable(2)) room.AddItem(itemToAdd, random.Next(2, 10));
                    floor.AddRoom(room);
                }
            }

            var students = new Student[] { 
                new Student("Teszt Elek", "teszt@gmail.com", "ABCDEF"),
                new Student("Vicc Elek", "vicc@gmail.com", "AHJFGF"),
                new Student("Rekt Elek", "rekt@gmail.com", "KJFBUZ"),
                new Student("Rend Elek", "rend@gmail.com", "123456"),
                new Student("Felk Elek", "felk@gmail.com", "6543TZ"),
                new Student("Nyerg Elek", "nyerg@gmail.com", "876ZHG")
            };

            foreach (var student in students) college.RegisterStudent(student);
            for (int i = 0; i < 4; i++) college.AddElevator();
            college.AddCircle(new Circle("Elekek köre", students[2], "Elek nevű férfiemberek büszke köre."));
        }
    }
}
