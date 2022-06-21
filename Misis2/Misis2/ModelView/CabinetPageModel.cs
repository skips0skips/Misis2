using Misis2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Misis2.ModelView
{
    public class CabinetPageModel : INotifyPropertyChanged
    {
        public ICommand LoadDataCommand { protected set; get; }
        public ICommand FLPCommand { protected set; get; }
        public CabinetPageModel()
        {
            LoadDataCommand = new Command(LoadData);
            FLPCommand = new Command(GetNamePersons);
            SubjectAreans = GetSubjectAreans();
          //  NamePersons = GetNamePersons();
        }

        private string fLPname;
        public string FLPname
        {
            get { return $"{FirstName}  {LastName}  {Patronymic}"; }
            set { fLPname = value; }
        }
        private ObservableCollection<SubjectArea> subjectAreans;
        public ObservableCollection<SubjectArea> SubjectAreans
        {
            get { return subjectAreans; }
            set { subjectAreans = value; }
        }
        private ObservableCollection<SubjectArea> GetSubjectAreans()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Misis2.Json.CabinetPageJson.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                GetNamePersons();
                var json = reader.ReadToEnd();
                JObject o = JObject.Parse(json);
                var str = o.SelectToken(@"$.subjectArea");
                List<SubjectArea> mylist = JsonConvert.DeserializeObject<List<SubjectArea>>(str.ToString());
                return new ObservableCollection<SubjectArea>(mylist);
                // return new ObservableCollection<SubjectArea>
                // {
                //     new SubjectArea { Subject = "Математика"},
                ////     new SubjectArea { Subject = mylist.ToString()},
                //     new SubjectArea { Subject = "Физика"},
                //     new SubjectArea { Subject = "История"},
                // };
            }
            
        }
        //private ObservableCollection<NamePerson> namePersons;
        //public ObservableCollection<NamePerson> NamePersons
        //{
        //    get { return namePersons; }
        //    set { namePersons = value; }
        //}
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            private set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            private set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            private set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        private void GetNamePersons()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Misis2.Json.CabinetPageJson.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                JObject o = JObject.Parse(json);
                var str = o.SelectToken(@"$.NamePerson");
                var rateInfo = JsonConvert.DeserializeObject<NamePerson>(str.ToString());               
                this.FirstName = rateInfo.FirstName;
                this.LastName = rateInfo.LastName;
                this.Patronymic = rateInfo.Patronymic;  
                
            }
        }

        private void LoadData()
        {
            try
            {
                var assembly = typeof(MainPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Misis2.Json.json1.json");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    JObject o = JObject.Parse(json);
                    var str = o.SelectToken(@"$.query");
                    var rateInfo = JsonConvert.DeserializeObject<Discipline>(str.ToString());
                   // this.Rate = rateInfo.Rate;
                }
            }
            catch 
            { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
