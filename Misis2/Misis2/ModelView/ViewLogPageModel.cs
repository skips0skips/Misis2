using Misis2.Model;
using Misis2.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Misis2.ModelView
{
    public class ViewLogPageModel : INotifyPropertyChanged
    {
        public ICommand MarkCommand { protected set; get; }
        public ViewLogPageModel()
        {
            GetDisciplinesAsync();
            DisciplineList = GetDiscipline().OrderBy(t => t.name).ToList();
            MyDiscipline = "Выбранно: ";
            TimeFullList = GetTimeFull().OrderBy(t => t.groupName).ToList();
            MyTimeFull = "Выбранно: ";

            StartDate = new DateTime(2020, 1, 1);
            EndDate = new DateTime(2020, 3, 31);
            MarkCommand = new Command(MarkTapped);
        }
        private string _myDiscipline;
        public string MyDiscipline
        {
            get { return _myDiscipline; }
            set
            {
                if (_myDiscipline != value)
                {
                    _myDiscipline = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _myTimeFull;
        public string MyTimeFull
        {
            get { return _myTimeFull; }
            set
            {
                if (_myTimeFull != value)
                {
                    _myTimeFull = value;
                    OnPropertyChanged();
                }
            }
        }

        private TimeFull _selectedTimeFull { get; set; }
        public TimeFull SelectedTimeFull
        {
            get { return _selectedTimeFull; }
            set
            {
                if (_selectedTimeFull != value)
                {
                    _selectedTimeFull = value;
                    MyTimeFull = _selectedTimeFull.groupName;
                }
            }
        }
        private Discipline _selectedDiscipline { get; set; }
        public Discipline SelectedDiscipline
        {
            get { return _selectedDiscipline; }
            set
            {
                if (_selectedDiscipline != value)
                {
                    _selectedDiscipline = value;
                    // Do whatever functionality you want...When a selectedItem is changed..
                    // write code here..
                    MyDiscipline =_selectedDiscipline.name;
                    GetTimeFullAsync();
                }
            }
        }
        public List<TimeFull> TimeFullList { get; set; }
        public List<TimeFull> GetTimeFull()
        {
            var cities = new List<TimeFull>()
            {
                new TimeFull(){groupName= "БПИ-18"},
                new TimeFull(){groupName= "БПИ-19"}
            };

            return cities;
        }
        public List<Discipline> DisciplineList { get; set; }
        public List<Discipline> GetDiscipline()
        {
            var cities = new List<Discipline>()
            {
                new Discipline(){name= "Информатика"},
                new Discipline(){name= "Проектирование информационных систем"}
            };

            return cities;
        }
        private string _selectedDate;
        public string SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                RaisePropertyChanged("SelectedDate");
            }
        }

       
        private ObservableCollection<Discipline> disciplines;
        public ObservableCollection<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; OnPropertyChanged("Disciplines"); }
        }
        //public string Url = "https://script.google.com/macros/s/AKfycbwcVZUNWsrKaXji5z2u5_nesKI9C7vRruaPMBdoadExeOi44nNDi2ev1nr_pJbZvZ6X/exec";
        public string Url = "https://script.google.com/macros/s/AKfycbwzO83Rt1jnpm7RHV_bnl1qsArVwIFT_EG2JT9kgE9x8trXjGZC1rSiTYZ2gfuvdjv7/exec";
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
        }

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
        private async Task<ObservableCollection<TimeFull3>> GetTimeFullAsync()
        {
            try
            {
                var client = new HttpClient();
                var uri = Url;//;
                List<Name> names = new List<Name>();
                names.Add(new Name() { id = MyDiscipline, mark = null });
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

        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void RaisePropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void MarkTapped(object obj)
        {
            var bindingContext = new FourPageModel { };
            var page = new FourPage() { BindingContext = bindingContext };
            App.Current.MainPage.Navigation.PushAsync(page);
        }
    }


}
