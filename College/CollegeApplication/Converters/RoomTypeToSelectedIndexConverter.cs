using CollegeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CollegeApplication.Converters
{
    public class RoomTypeToSelectedIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is CommonRoom)
                return (int)RoomType.SOCIAL;
            else if (value is DormRoom)
                return (int)RoomType.DORM;
            else if (value is SpecialRoom)
                return (int)RoomType.SPECIAL;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
