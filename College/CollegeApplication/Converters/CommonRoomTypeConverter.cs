using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using CollegeManager;

namespace CollegeApplication.Converters
{
    public class CommonRoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var roomType = (SocialRoom)value;
            switch(roomType)
            {
                case SocialRoom.KITCHEN:
                    return "Konyha";
                case SocialRoom.CLUB:
                    return "Klubszoba";
                case SocialRoom.STUDY:
                    return "Tanuló";
                default:
                    return "Közösségi";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
