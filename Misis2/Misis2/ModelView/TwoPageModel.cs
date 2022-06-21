using Misis2.Model;
using Misis2.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Misis2.ModelView
{
    public class TwoPageModel : INotifyPropertyChanged
    {
        public ICommand FLPCommand { protected set; get; }
        public TwoPageModel()
        {
            FLPCommand = new Command(GetTimeFull1);
            //GetTimeFullAsync();
        }

        private Discipline selectedDiscipline;
        public Discipline SelectedDiscipline
        {
            get { return selectedDiscipline;}
            set
            {
                if (selectedDiscipline != value)
                {
                    selectedDiscipline = value;
                    OnPropertyChanged("SelectedDiscipline");
                    GetTimeFullAsync();
                }
                
            }
        }
        /// <summary>
        public void NavigationThreePage()
        {
            var bindingContext = new ThreePageModel { SelectedTimeFull3 = SelectedTimeFull3, SelectedDiscipline = SelectedDiscipline };
            var page = new ThreePage() { BindingContext = bindingContext };
            App.Current.MainPage.Navigation.PushAsync(page);
        }
        private TimeFull3 selectedTimeFull3;
        public TimeFull3 SelectedTimeFull3
        {
            get { return selectedTimeFull3; }
            set
            {
                if (selectedTimeFull3 != value)
                {
                    selectedTimeFull3 = value;
                    OnPropertyChanged("SelectedTimeFull3");
                    NavigationThreePage();
                }
            }
        }
        /// </summary>

        private ObservableCollection<TimeFull3> timeFulls3;
        public ObservableCollection<TimeFull3> TimeFulls3
        {
            get { return timeFulls3; }
            set
            {
                timeFulls3 = value;
                 OnPropertyChanged("TimeFulls3");              
            }
        }
        /// 
       /* private TimeFull selectedTimeFull;
        public TimeFull SelectedTimeFull
        {
            get { return selectedTimeFull; }
            set{
                if (selectedTimeFull != value)
                {
                    selectedTimeFull = value;
                    OnPropertyChanged("SelectedTimeFull");
                    NavigationThreePage();
                }               
            }
        }
        /// </summary>

        private ObservableCollection<TimeFull> timeFulls;
        public ObservableCollection<TimeFull> TimeFulls
        {
            get { return timeFulls;}
            set
            { timeFulls = value;
               // OnPropertyChanged("TimeFulls");              
            }
        } */
        private void GetTimeFull1()
        {
          //  GetTimeFullAsync();
        }
        public string Url = "https://script.google.com/macros/s/AKfycbwzO83Rt1jnpm7RHV_bnl1qsArVwIFT_EG2JT9kgE9x8trXjGZC1rSiTYZ2gfuvdjv7/exec";
        private async Task<ObservableCollection<TimeFull3>> GetTimeFullAsync()
        {
            try
            {
                var client = new HttpClient();
                var uri = Url;//;
                List<Name> names = new List<Name>();
                names.Add(new Name() { id = selectedDiscipline.name, mark = null });
                var conf = new MaillRoot2() { idCode = "8", name = names };
                var jsonString = JsonConvert.SerializeObject(conf);
                var requestContent = new StringContent(jsonString);
                var result = await client.PostAsync(uri, requestContent);
                var resultContent = await result.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(resultContent);
                var str = o.SelectToken(@"$." + "user");
                List<TimeFull3> timeFullss = JsonConvert.DeserializeObject<List<TimeFull3>>(str.ToString());
                return TimeFulls3 = new ObservableCollection<TimeFull3>(timeFullss);
            }
            catch { return new ObservableCollection<TimeFull3>(); }



                /*
                var assembly = typeof(MainPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Misis2.Json.TwoPageJson.json");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    JObject o = JObject.Parse(json);
                    Console.WriteLine(@"$." + selectedDiscipline.Name + ".timeFull.groupName");
                    var str = o.SelectToken(@"$." + selectedDiscipline.Name + ".timeFull");                   
                    List<TimeFull> timeFullss = JsonConvert.DeserializeObject<List<TimeFull>>(str.ToString());
                    return TimeFulls = new ObservableCollection<TimeFull>(timeFullss);
                }
            }
            catch
            { return new ObservableCollection<TimeFull>(); } */

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
