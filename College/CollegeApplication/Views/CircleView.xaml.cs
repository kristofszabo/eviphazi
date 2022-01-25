using CollegeManager;
using CollegeApplication.Utils;
using CollegeApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CollegeApplication.Views
{
    public sealed partial class CircleView : Page
    {
        public CircleViewModel ViewModel;

        public CircleView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var info = e.Parameter as NavigationInfo;
            ViewModel = new CircleViewModel(info.College);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!circleName.Text.Equals("") && circleLeader.SelectedItem != null)
            {
                if (!ViewModel.Model.Circles.Any(circle => circle.Name == circleName.Text))
                {
                    var circle = new Circle(circleName.Text, (Student)circleLeader.SelectedItem, circleDescription.Text);
                    ViewModel.Model.AddCircleToCollege(circle);
                    Logger.Instance.Info($"{circleName.Text} nevű kör felvétele.");
                    circleName.Text = "";
                    circleLeader.SelectedIndex = -1;
                    circleDescription.Text = "";
                    return;
                }
                _ = new MessageDialog("Ilyen névvel már létezik kör!", "Hiba").ShowAsync();
                return;
            }
            _ = new MessageDialog("Nem adtál körnek nevet, vagy nem jelöltél ki vezetőt!", "Hiba").ShowAsync();
        }

        private void Member_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as ListView;
            var circle = (Circle)item.SelectedItem;
            ViewModel.SelectedCircle = circle;
        }

        private void AddMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)students.SelectedItem;
            var circle = (Circle)circles.SelectedItem;
            if (student != null && circle != null)
            {
                if (circle.Members.Contains(student))
                {
                    _ = new MessageDialog("Ez a diák már tagja ennek a körnek!", "Hiba").ShowAsync();
                }
                student.JoinCircle(circle);
                Logger.Instance.Info($"{student.Name} nevű és {student.Neptun} neptun kódú diák felvétele a(z) {circle.Name} nevű körhöz.");
                students.SelectedIndex = -1;
                circles.SelectedIndex = -1;
                return;
            }
            _ = new MessageDialog("Nem választottál ki diákot, és/vagy kört!", "Hiba").ShowAsync();
        }
    }
}
