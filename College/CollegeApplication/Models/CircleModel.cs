using CollegeManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplication.Models
{
    public class CircleModel : ObservableObject
    {
        public College college { get; set; }
        public ObservableCollection<Student> Students => college.Students;
        public ObservableCollection<Circle> Circles => college.Circles;

        public CircleModel(College college)
        {
            this.college = college;
        }

        public void AddCircleToCollege(Circle circle)
        {
            college.AddCircle(circle);
        }

        public void RemoveCircleFromCollege(Circle circle)
        {
            college.RemoveCircle(circle);
        }

        public void AddStudentToCircle(Student student, Circle circle)
        {
            student.JoinCircle(circle);
        }

        public void DeleteStudentFromCircle(Student student, Circle circle)
        {
            student.LeaveCircle(circle);
        }
    }
}
