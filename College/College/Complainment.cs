using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeManager
{
    public class Complainment : ObservableObject
    {
        public string Description { get; }
        private ComplainmentStatus status  = ComplainmentStatus.WAITING;
        public ComplainmentStatus Status
        {
            get => status;
            set {
                status = value;
            }
        }

        public Complainment(string description) 
        {
            Description = description;
            Status = ComplainmentStatus.WAITING;
        }
    }
}