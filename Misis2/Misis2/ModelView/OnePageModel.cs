using Misis2.Model;
using Misis2.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Misis2.ModelView
{
    public class OnePageModel : INotifyPropertyChanged
    {
        public ICommand CabinetPageCommand { protected set; get; }
        public OnePageModel()
        {
            GetDisciplinesAsync();
            CabinetPageCommand = new Command(async() =>
            {               
                var cabinetPage = new CabinetPage();
                await Application.Current.MainPage.Navigation.PushAsync(cabinetPage);
            });
        }
        public void NavigationTwoPage()
        {           
            var bindingContext = new TwoPageModel { SelectedDiscipline = SelectedDiscipline };
            var page = new TwoPage() { BindingContext = bindingContext };
            App.Current.MainPage.Navigation.PushAsync(page);
        }

        private Discipline selectedDiscipline;
        public Discipline SelectedDiscipline
        {
            get { return selectedDiscipline; }
            set { selectedDiscipline = value;
                OnPropertyChanged("SelectedDiscipline");
            }
        }
        private ObservableCollection<Discipline> disciplines;
        public ObservableCollection<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; OnPropertyChanged("Disciplines"); }
        }
        public string Url = "https://script.google.com/macros/s/AKfycbwcVZUNWsrKaXji5z2u5_nesKI9C7vRruaPMBdoadExeOi44nNDi2ev1nr_pJbZvZ6X/exec";
        private async Task<ObservableCollection<Discipline>> GetDisciplinesAsync()
        {
            try
            {
                var client = new HttpClient();
                var uri = Url;//;
                //List<Name> names = new List<Name>();
               // names.Add(new Name() { id = "Математика", mark = "+" });
                var conf = new MaillRoot2() { idCode = "9", name = null };
                var jsonString = JsonConvert.SerializeObject(conf);
                var requestContent = new StringContent(jsonString);
                var result = await client.PostAsync(uri, requestContent);
                var resultContent = await result.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(resultContent);
                var str = o.SelectToken(@"$." + "user");
                List<Discipline> timeFullss = JsonConvert.DeserializeObject<List<Discipline>>(str.ToString());
                return Disciplines = new ObservableCollection<Discipline>(timeFullss);
            }
            catch { return new ObservableCollection<Discipline>(); }

            /*var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            List<Discipline> mylist = new List<Discipline>();
            Stream stream = assembly.GetManifestResourceStream("Misis2.Json.OnePageJson.json");
            string json = ""; 
            using (var reader = new System.IO.StreamReader(stream))
            {
                  json = reader.ReadToEnd();
            }
            mylist = JsonConvert.DeserializeObject<List<Discipline>>(json);           
            return disciplines = new ObservableCollection<Discipline>(mylist);*/
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
