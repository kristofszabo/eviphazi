using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CollegeApplication.UserControls
{
    public sealed partial class NumberBox : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(string),
            typeof(NumberBox),
            new PropertyMetadata(null)
        );

        public string Value 
        { 
            get => (string)GetValue(ValueProperty);
            set
            {
                SetValue(ValueProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            } 
        } 

        public string PlaceholderText { get; set; }

        public NumberBox()
        {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = sender as TextBox;
            if (box.Text == "") return;
            int value;
            if (int.TryParse(box.Text, out value))
            {
                string oldValue = Value;
                Value = value.ToString();
                if (oldValue.StartsWith('0'))
                {
                    box.SelectionStart = box.Text.Length;
                    box.SelectionLength = 0;
                }
            }
            else
            {
                box.Text = Value;
            }
        }
    }
}
