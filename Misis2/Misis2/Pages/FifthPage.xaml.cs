using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Misis2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FifthPage : ContentPage
    {
        public FifthPage()
        {
            InitializeComponent();
        }
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var vm = BindingContext as ModelView.FifthPageModel;
            var schedule = e.Item as Model.Schedule;
            vm.HideOrShowSchedule(schedule);
        }
    }
}