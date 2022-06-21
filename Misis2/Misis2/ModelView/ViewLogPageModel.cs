using Misis2.Model;
using Misis2.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Misis2.ModelView
{
    public class ViewLogPageModel : INotifyPropertyChanged
    {
        public ICommand MarkCommand { protected set; get; }
        public ViewLogPageModel()
        {
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
