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
    public partial class OnePage : ContentPage
    {
        public OnePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);//уберает верхний бар
            InitializeComponent();          
        }
    }
}