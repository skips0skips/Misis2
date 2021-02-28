using Misis2.Model;
using Misis2.ModelView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Misis2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CabinetPage : ContentPage
    {
        //private ObservableCollection<TestModel> myrootobject;

        public CabinetPage()
        {
            InitializeComponent();


            // установка контекста данных

            //var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream("Misis2.Json.json1.json");
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    var json = reader.ReadToEnd();
            //    List<TestModel> mylist = JsonConvert.DeserializeObject<List<TestModel>>(json);
            //    myrootobject = new ObservableCollection<TestModel>(mylist);
            //    MyListView.ItemsSource = myrootobject;
            //}
        }
    }
}