using Misis2.Model;
using Misis2.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
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
            TimeFulls = GetTimeFull();
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
                    TimeFulls = GetTimeFull();
                }
                
            }
        }
        /// <summary>
        public void NavigationThreePage()
        {
            var bindingContext = new ThreePageModel { SelectedTimeFull = SelectedTimeFull, SelectedDiscipline = SelectedDiscipline };
            var page = new ThreePage() { BindingContext = bindingContext };
            App.Current.MainPage.Navigation.PushAsync(page);
        }
        /// 
        private TimeFull selectedTimeFull;
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
        }
        private void GetTimeFull1()
        {
            GetTimeFull();
        }
        private  ObservableCollection<TimeFull> GetTimeFull()
        {
            try
            {
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
            { return new ObservableCollection<TimeFull>(); }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
