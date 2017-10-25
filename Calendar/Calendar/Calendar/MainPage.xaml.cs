using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;

namespace Calendar
{
    public partial class MainPage : ContentPage
    {
        #region Private fields
        private DatePicker _datePicker;
        private Label _labelDate, _labelTime;
        private StackLayout _stackLayoutHours;
        #endregion

        #region Constructors
        public MainPage()
        {
            InitializeComponent();
            _datePicker       = this.FindByName<DatePicker>("DprDate");
            _labelDate        = this.FindByName<Label>("LblDate");
            _labelTime        = this.FindByName<Label>("LblTime");
            _stackLayoutHours = this.FindByName<StackLayout>("StlHours");

            AddHourButtons();
        }
        #endregion

        #region Methods
        private void AddDays(int amountOfDaysToAdd)
        {
            _datePicker.Date += TimeSpan.FromDays(amountOfDaysToAdd);
        }

        private void AddHourButtons()
        {
            if (_stackLayoutHours.Children.Any(child => child is Button))
                return;

            for (int i = 0; i < 24; i++)
            {
                var button = new Button()
                {
                    Text = TimeSpan.FromHours(i).ToString(@"hh\:mm"),
                }; 
                button.Clicked += SwitchToIndividualDay;
                _stackLayoutHours.Children.Add(button);
            }
        }
        #endregion

        #region Event handlers
        private void BtnPreviousDay_Clicked(object sender, EventArgs e)
        {
            AddDays(-1);
        }

        private void BtnNextDay_Clicked(object sender, EventArgs e)
        {
            AddDays(1);
        }

        private void HandleDateChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != DatePicker.DateProperty.PropertyName)
                return;

            AddHourButtons();
        }

        private async void SwitchToIndividualDay(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            await Navigation.PushAsync(new IndividualDayPage(_datePicker.Date, TimeSpan.Parse(button.Text)));
        }
        #endregion
    }
}
