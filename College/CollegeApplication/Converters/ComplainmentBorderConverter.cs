using CollegeManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace CollegeApplication.Converters
{
    public class ComplainmentBorderConverter : IValueConverter
    {
        private Thickness danger = new Thickness(0, 0, 1, 0);
        private Thickness normal = new Thickness(0, 0, 0, 0);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var complainments = (ObservableCollection<Complainment>)value;
            return complainments.Where(comp => comp.Status != ComplainmentStatus.RESOLVED).Count() > 0 ? danger : normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
