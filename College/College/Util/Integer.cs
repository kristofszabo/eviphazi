using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManager.Util {
    public class Integer : ObservableObject {
        private int value;
        public int Value
        {
            get => value;
            set {
                this.value = value;
                Notify(nameof(Value));
            }
        }
    }
}
