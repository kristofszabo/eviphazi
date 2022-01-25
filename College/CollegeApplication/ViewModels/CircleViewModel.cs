using CollegeManager;
using CollegeApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollegeApplication.ViewModels
{
    public class CircleViewModel : ObservableObject
    {
        public CircleModel Model { get; }
        
        private Circle selectedCircle;
        public Circle SelectedCircle
        {
            get => selectedCircle;
            set
            {
                selectedCircle = value;
                NotifyByName();
            }
        }

        public ObservableCollection<Student> Students => Model.Students;
        public ObservableCollection<Circle> Circles => Model.Circles;

        public CircleViewModel(College college)
        {
            Model = new CircleModel(college);
        }
    }
}
