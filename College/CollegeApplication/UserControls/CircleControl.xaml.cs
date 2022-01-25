using CollegeManager;
using CollegeApplication.ViewModels;
using CollegeApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CollegeApplication.UserControls
{
    public sealed partial class CircleControl : UserControl, INotifyPropertyChanged
    {
        public College College { get; set; }

        private Circle circle;
        public Circle Circle
        {
            get => circle;
            set
            {
                circle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Circle)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CircleControl()
        {
            this.InitializeComponent();
        }

        private void DeleteMember_Btn(object sender, RoutedEventArgs e)
        {
            var student = (Student)member.SelectedItem;
            if (student != null)
            {
                if(student == Circle.Leader)
                {
                    _ = new MessageDialog("A vezetőt nem lehet kitörölni!", "Hiba").ShowAsync();
                    return;
                }
                Logger.Instance.Info($"{student.Name} nevű és {student.Neptun} neptun kódú diák törlése a(z) {circle.Name} nevű körből.");
                student.LeaveCircle(Circle);
                member.SelectedIndex = -1;
                return;
            }
            _ = new MessageDialog("Nem választottál ki tagot!", "Hiba").ShowAsync();
        }

        private void ChangeLeaderBtn_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)member.SelectedItem;
            if (student != null)
            {
                if (student == Circle.Leader)
                {
                    _ = new MessageDialog("Ez a tag már a vezető", "Hiba").ShowAsync();
                    return;   
                }
                Logger.Instance.Info($"{student.Name} nevű és {student.Neptun} neptun kódú diák a(z) {circle.Name} nevű kör új veztője.");
                Circle.Leader = student;
                member.SelectedIndex = -1;
                return;
            }
            _ = new MessageDialog("Nem választottál ki tagot!", "Hiba").ShowAsync();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Logger.Instance.Info($"{Circle.Name} nevű kör törlése.");
            College.RemoveCircle(Circle);
        }
    }
}
