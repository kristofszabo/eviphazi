using CollegeApplication.ViewModels;
using CollegeManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CollegeApplication.Views
{
    public sealed partial class LoggerView : Page
    {
        public LoggerViewModel ViewModel;
        public LoggerView()
        {
            this.InitializeComponent();
            ViewModel = new LoggerViewModel();
            Datepicker.SelectedDate = DateTime.Now;
            SetupLogs(DateTime.Now);
        }

        private async void SetupLogs(DateTime date)
        {
            ViewModel.Logs = await ViewModel.ReadLogs(date);
        }

        private void Datepicker_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            var date = ((DateTimeOffset)sender.SelectedDate).DateTime;
            SetupLogs(date);
        }
    }
}
