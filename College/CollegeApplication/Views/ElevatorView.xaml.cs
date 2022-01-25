using CollegeApplication.Utils;
using CollegeApplication.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CollegeApplication.Views
{
    public sealed partial class ElevatorView : Page
    {
        public ElevatorViewModel ViewModel { get; private set; }

        public ElevatorView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var college = (e.Parameter as NavigationInfo).College;
            ViewModel = new ElevatorViewModel(college);
            ViewModel.StartSimulation();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            ViewModel.StopSimulation();
        }
    }
}
