using Misis2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Misis2.ModelView
{
    public class OnePageModel : INotifyPropertyChanged
    {
        public OnePageModel()
        {
            Disciplines = GetDisciplines();
        }
        //private Discipline selectedDiscipline;

        //public Discipline SelectedDiscipline
        //{
        //    get { return selectedDiscipline; }
        //    set { selectedDiscipline = value; }
        //}

        private ObservableCollection<Discipline> disciplines;
        public ObservableCollection<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }
        private ObservableCollection<Discipline> GetDisciplines()
        {
            return new ObservableCollection<Discipline>
            {
                new Discipline { Name = "Математика"},
                new Discipline { Name = "Алгебра"},
                new Discipline { Name = "Физика"},
                new Discipline { Name = "История"},
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
