using CollegeManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ResidentsControl : UserControl
    {
        public ObservableCollection<Student> Students { get; set; }

        public Student SelectedStudent { get; set; }

        public ResidentsControl()
        {
            this.InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView= sender as ListView;
            var student = listView.SelectedItem as Student;
            SelectedStudent = student;
        }
    }
}
