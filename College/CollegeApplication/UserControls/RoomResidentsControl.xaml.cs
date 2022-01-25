using CollegeManager;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CollegeApplication.UserControls
{
    public sealed partial class RoomResidentsControl : UserControl
    {
        public DormRoom DormRoom { get; set; }

        public RoomResidentsControl()
        {
            this.InitializeComponent();
        }

        private void AddResident_Button(object sender, RoutedEventArgs e)
        {
            var student = MyResidentsControl.SelectedStudent;
            if (student is null) return;
            DormRoom.Floor.College.AssignStudentToRoom(student, DormRoom);
            Logger.Instance.Info("Diák szobához rendelése: (Diák: " + student.Neptun + " Szobaszám: " + DormRoom.DoorNumber + ")");
        }

        private void RemoveResident_Button(object sender, RoutedEventArgs e)
        {
            var student = ResidentList.SelectedItem as Student;
            if (student is null) return;
            DormRoom.RemoveStudent(student);
            Logger.Instance.Info("Diák szobából eltávolítása: (Diák: " + student.Neptun + " Szobaszám: " + DormRoom.DoorNumber + ")");
        }
    }
}
