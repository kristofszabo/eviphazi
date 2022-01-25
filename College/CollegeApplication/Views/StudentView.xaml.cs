using CollegeManager;
using CollegeApplication.Utils;
using CollegeApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public sealed partial class StudentView : Page
    {
        public StudentViewModel ViewModel { get; private set; }

        public StudentView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var info = e.Parameter as NavigationInfo;
            ViewModel = new StudentViewModel(info.College);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!studentName.Text.Equals("") && Regex.IsMatch(studentEmail.Text, @"([\w.]+)@(\w+(?:.\w+)*)") && Regex.IsMatch(studentNeptun.Text, @"^[A-Z,0-9]{6}$"))
            {
                if (!ViewModel.Model.Students.Any(student => student.Neptun == studentNeptun.Text))
                {
                    var student = new Student(studentName.Text, studentEmail.Text, studentNeptun.Text);
                    ViewModel.Model.AddStudentToCollege(student);
                    Logger.Instance.Info($"{studentName.Text} nevű és {studentNeptun.Text} neptun kódú diák felvétele.");
                    studentName.Text = "";
                    studentEmail.Text = "";
                    studentNeptun.Text = "";
                    return;
                }
                _ = new MessageDialog("Ilyen neptunnal már létezik diák!", "Hiba").ShowAsync();
                return;
            }
            _ = new MessageDialog("Hibás adatok lettek megadva!", "Hiba").ShowAsync();
        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            var neptunCode = item.Tag.ToString();
            foreach (var student in ViewModel.Model.Students)
            {
                if (student.Neptun.Equals(neptunCode))
                {
                    Logger.Instance.Info($"{student.Name} nevű és {student.Neptun} neptun kódú diák törlése.");
                    ViewModel.Model.RemoveStudentFromCollege(student);
                    return;
                }
            }
        }
    }
}
