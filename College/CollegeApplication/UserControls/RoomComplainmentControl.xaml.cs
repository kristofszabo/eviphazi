using CollegeManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CollegeApplication.UserControls
{
    public sealed partial class RoomComplainmentControl : UserControl
    {
        public ObservableCollection<Complainment> Complainments { get; set; }

        public static IEnumerable<ComplainmentStatus> ComplainmentStatuses = 
            Enum.GetValues(typeof(ComplainmentStatus)).Cast<ComplainmentStatus>(); 

        public RoomComplainmentControl()
        {
            this.InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var text = TbDescription.Text;
            if (text != "")
            {
                Complainments.Add(new Complainment(text));
                TbDescription.Text = "";
                Logger.Instance.Info("Panasz hozzáadva: " + text);
            }
            else
            {
                _ = new MessageDialog("Nem lehet üres leírással hibát felvenni!", "Hiba").ShowAsync();
            }

        }
    }
}
