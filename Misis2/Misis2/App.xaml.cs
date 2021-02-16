using Misis2.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Misis2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OnePage();


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
