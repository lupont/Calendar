using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndividualDayPage : ContentPage
    {
        private Label _label;

        public IndividualDayPage()
        {
            InitializeComponent();
            _label = this.FindByName<Label>("LblDateAndTime");
        }

        public IndividualDayPage(DateTime date, TimeSpan time) : this()
        {
            var d = date.Date.ToString("yyyy-MM-dd");
            var t = time.ToString(@"hh\:mm");
            var dateAndTime = $"{d}: {t}";

            _label.Text = dateAndTime;
        }
    }
}