﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Misis2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwoPage : ContentPage
    {
        public TwoPage()
        {
            InitializeComponent();
        }

        private void TimeFullSelected(object sender, SelectionChangedEventArgs e)
        {
           // vm.NavigationThreePage();
        }
    }
}