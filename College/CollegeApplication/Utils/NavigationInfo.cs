using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Controls;
using CollegeManager;

namespace CollegeApplication.Utils
{
    public class NavigationInfo
    {
        public Frame ContentFrame { get; }
        public College College { get; }
        public object Parameter { get; set; }

        public NavigationInfo(Frame contentFrame, College college)
        {
            ContentFrame = contentFrame;
            College = college;
        }

        public NavigationInfo(Frame contentFrame, College college, object parameter) : this(contentFrame, college)
        {
            Parameter = parameter;
        }
    }
}
