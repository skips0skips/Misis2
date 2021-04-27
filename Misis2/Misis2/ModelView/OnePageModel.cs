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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Misis2.ModelView
{
    public class OnePageModel : INotifyPropertyChanged
    {
        public ICommand CabinetPageCommand { protected set; get; }
        public OnePageModel()
        {
            Disciplines = GetDisciplines();
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
        //public void ShowDetails()
        //{
        //    var bindingContext = new TwoPageModel { SelectedDiscipline = SelectedDiscipline };
        //    var page = new TwoPage() { BindingContext = new TwoPageModel { SelectedDiscipline = SelectedDiscipline } };
        //    App.Current.MainPage.Navigation.PushAsync(page);
        //}

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
            set { disciplines = value; }
        }
        private ObservableCollection<Discipline> GetDisciplines()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Misis2.Json.OnePageJson.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<Discipline> mylist = JsonConvert.DeserializeObject<List<Discipline>>(json);
                return disciplines = new ObservableCollection<Discipline>(mylist);
            }
            //return new ObservableCollection<Discipline>
            //{
            //    new Discipline { Name = "Математика"},
            //    new Discipline { Name = "Алгебра"},
            //    new Discipline { Name = "Физика"},
            //    new Discipline { Name = "История"},
            //};
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
