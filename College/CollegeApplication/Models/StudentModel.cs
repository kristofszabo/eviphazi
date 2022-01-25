using CollegeManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApplication.Models
{
    public class StudentModel : ObservableObject
    {
        private College college;

        public ObservableCollection<Student> Students => college.Students;

        public StudentModel(College college)
        {
            this.college = college;
        }

        public void AddStudentToCollege(Student student)
        {
            college.RegisterStudent(student);
        }

        public void RemoveStudentFromCollege(Student student)
        {
            college.CheckOutStudent(student);
        }

        public void JoinToCircle(Student student, Circle circle)
        {
            student.JoinCircle(circle);
        }

        public void LeaveFromCircle(Student student, Circle circle)
        {
            student.LeaveCircle(circle);
        }
    }
}
