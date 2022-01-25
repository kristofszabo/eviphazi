using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using CollegeManager;

namespace CollegeApplication.Converters
{
    public class SpecialRoomTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var roomType = (SpecialRoomType)value;
            switch(roomType)
            {
                case SpecialRoomType.DENTIST:
                    return "Fogászat";
                case SpecialRoomType.GYM:
                    return "Edzőterem";
                case SpecialRoomType.JANITOR:
                    return "Porta";
                case SpecialRoomType.SAUNA:
                    return "Szauna";
                default:
                    return "Speciális";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
