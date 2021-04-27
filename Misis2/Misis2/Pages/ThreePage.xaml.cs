using Misis2.ModelView;
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
    public partial class ThreePage : ContentPage
    {
        public ThreePage()
        {
            
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var A = e;
        }


        //void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        //{
        //    vm.MarkOn(sender, e);
        //}



        //private void Switch_Toggled(object sender, ToggledEventArgs e)
        //{
        //    var A = e;

        //    //ViewCell cell = (sender as Switch).Parent.Parent as ViewCell;
        //    //int Id = ((M.PeriodicNotifications_M)cell.BindingContext).ID;

        //}

        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    var A = e;
        //}
    }
}