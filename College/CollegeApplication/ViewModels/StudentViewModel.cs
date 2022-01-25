using System.Collections.ObjectModel;
using System.ComponentModel;
using CollegeManager;
using CollegeApplication.Models;

namespace CollegeApplication.ViewModels
{
    public class StudentViewModel : ObservableObject
    {
        public StudentModel Model { get; }
        public ObservableCollection<Student> Students => Model.Students;

        public StudentViewModel(College college)
        {
            Model = new StudentModel(college);
        }
    }
}
