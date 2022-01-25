using CollegeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CollegeApplication.Converters
{
    class RoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = (RoomType)value;
            switch (val){
                case RoomType.DORM:
                    return "Lakó";
                case RoomType.SOCIAL:
                    return "Szociális";
                case RoomType.SPECIAL:
                    return "Speciális";
            }
            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
