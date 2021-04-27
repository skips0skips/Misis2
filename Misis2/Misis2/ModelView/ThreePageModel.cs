using Misis2.Model;
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
    public class ThreePageModel : INotifyPropertyChanged 
    {
        public ICommand DeleteCommand { get; }       
        public ThreePageModel()
        {
            DeleteCommand = new Command(EditTapped);          
        }
        private TimeFull selectedTimeFull;
        public TimeFull SelectedTimeFull
        {
            get { return selectedTimeFull; }
            set
            {
                if (selectedTimeFull != value)
                {
                    selectedTimeFull = value;
                    OnPropertyChanged("SelectedTimeFull");
                    Roots = GetRoot();                    
                }

            }
        }
        private ObservableCollection<Root> roots;
        public ObservableCollection<Root> Roots
        {
            get {return roots; }
            set { roots = value;
                OnPropertyChanged("Roots");
            }
        }
        private ObservableCollection<MaillRoot> maillRoots;
        public ObservableCollection<MaillRoot> MaillRootList
        {
            get { return maillRoots; }
            set
            {
                maillRoots = value;
                OnPropertyChanged("MaillRootList");
            }
        }
        private Discipline selectedDiscipline;
        public Discipline SelectedDiscipline
        {
            get { return selectedDiscipline; }
            set
            {
                if (selectedDiscipline != value)
                {
                    selectedDiscipline = value;

                }

            }
        }
        public int CountRoots { get; set; }//количество человек в группе
        int x;
        public int EditCountRoots { get { return x; } set { x = value;
                                                            OnPropertyChanged("EditCountRoots");} }//количество присутствующих человек

        private ObservableCollection<Root> GetRoot()
        {
            try
            {
                var assembly = typeof(MainPage).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Misis2.Json.ThreePageJson.json");
                using (var reader = new System.IO.StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    JObject o = JObject.Parse(json);
                    Console.WriteLine(@"$." + selectedTimeFull.groupName);
                    var str = o.SelectToken(@"$." + selectedTimeFull.groupName);                    
                    List<Root> nameIdss = JsonConvert.DeserializeObject<List<Root>>(str.ToString()); 
                    CountRoots = nameIdss.Count;
                    return Roots = new ObservableCollection<Root>(nameIdss);                   
                }

            }
            catch
            { return new ObservableCollection<Root>(); }

        }
       

        private Root selectedRoot;
        public Root SelectedRoot
        {
            get { return selectedRoot; }
            set
            {
                if (selectedRoot != value)
                {
                    selectedRoot = value;
                    OnPropertyChanged("SelectedRoot");
                    EditTapped(selectedRoot);
                }
            }
        }
        private void EditTapped(object obj)
        {
            var content = obj as Root;
            EditCountRoots++;

            if (MaillRootList == null)
            {
                List<MaillRoot> maillRoot = new List<MaillRoot>();
                maillRoot.Add(new MaillRoot() { id = content.id, mark = true });
                MaillRootList = new ObservableCollection<MaillRoot>(maillRoot);
            }
            else
            {
                MaillRootList.Add(new MaillRoot { id = content.id, mark = true });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
