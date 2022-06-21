using Misis2.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("The Northern Block Ltd - Webnar Light.otf", Alias = "WebnarLight")]
[assembly: ExportFont("The Northern Block Ltd - Webnar Medium_1.otf", Alias = "WebnarMedium")]
[assembly: ExportFont("The Northern Block Ltd - Webnar Thin.otf", Alias = "WebnarThin")]

namespace Misis2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MainOnePage())
            {
                BarBackgroundColor = Color.FromHex("#5EC6F2"),
                BarTextColor = Color.White,              
            };
            NavigationPage.SetHasNavigationBar(this, false);
            // MainPage = new OnePage();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
