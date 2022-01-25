using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CollegeManager.Util;

namespace CollegeManager
{
    public class Student : ObservableObject
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyByName();
            }
        }

        private string email;
        public string Email 
        {
            get => email;
            set
            {
               if (Regex.IsMatch(value, @"([\w.]+)@(\w+(?:.\w+)*)"))
                {
                    email = value;
                    NotifyByName();
                }
            }
        }
        public string Neptun { get; set; }

        public Student(string name, string email, string neptun) 
        {
            Name = name;
            Email = email;
            Neptun = neptun;
        }

        private DormRoom room;
        public DormRoom Room 
        {
            get => room;
            set
            {
                room = value;
                NotifyByName();
            }
        }

        public ObservableCollection<Circle> Circles { get; } = new ObservableCollection<Circle>();

        public void JoinCircle(Circle circle)
        {
            if (!Circles.Contains(circle))
            {
                Circles.Add(circle);
                circle.AddMember(this);
            }
        }

        public void LeaveCircle(Circle circle)
        {
            if (Circles.Contains(circle))
            {
                Circles.Remove(circle);
                circle.RemoveMember(this);
            }
        }
    }
}