using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CollegeManager;

namespace CollegeApplication.Utils
{
    public class RoomDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DormRoom { get; set; }
        public DataTemplate CommonRoom { get; set; }
        public DataTemplate SpecialRoom { get; set; }
        public DataTemplate Room { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return SelectCustomTemplate(item);
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectCustomTemplate(item);
        }

        private DataTemplate SelectCustomTemplate(object item)
        {
            if (item is DormRoom)
            {
                return DormRoom;
            }
            else if (item is CommonRoom)
            {
                return CommonRoom;
            }
            else if (item is SpecialRoom)
            {
                return SpecialRoom;
            }
            return Room;
        }
    }
}
