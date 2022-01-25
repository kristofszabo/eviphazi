using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollegeManager 
{
    public class Circle : ObservableObject
    {
        public string Name { get; private set; }
        
        private Student leader;
        public Student Leader
        {
            get => leader;
            set
            {
                leader = value;
                NotifyByName();
            }
        }

        public string Description { get; set; }

        public Circle(string name, Student leader, string description)
        {
            Name = name;
            Leader = leader;
            Description = description;
            leader.JoinCircle(this);
        }

        public ObservableCollection<Student> Members { get; private set; } = new ObservableCollection<Student>();

        public void AddMember(Student member)
        {
            if (!Members.Contains(member))
            {
                Members.Add(member);
            }
        }

        public void RemoveMember(Student member)
        {
            if (Members.Contains(member))
            {
                Members.Remove(member);
            }
        }
        public void RemoveAllMembers()
        {
            foreach (var member in Members.ToList())
            {
                member.LeaveCircle(this);
            }
        }
    }
}