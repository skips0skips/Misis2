using Android.Content.Res;
using Misis2.Model;
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
    
    public class ThreePageModel : INotifyPropertyChanged 
    {
        
        public ICommand DeleteCommand { get; }
        public ICommand NCommand { get; }
        public ICommand MarkCommand { protected set; get; }
        public ThreePageModel()
        {
            DeleteCommand = new Command(EditTapped);
            MarkCommand = new Command(MarkTapped2);
            NCommand = new Command(NTapped);
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
                    OnPropertyChanged("SelectedTimeFull");
                   // Roots = GetRoot();                    
                }

            }
        }
        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;

                OnPropertyChanged("Users");
            }
        }
        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (selectedUser != value)
                {
                    selectedUser = value;
                    OnPropertyChanged("SelectedUser");
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
        private ObservableCollection<MaillRoot2> maillRoot2s;
        public ObservableCollection<MaillRoot2> MaillRoot2List
        {
            get { return maillRoot2s; }
            set
            {
                maillRoot2s = value;
                OnPropertyChanged("MaillRoot2List");
            }
        }
        private List<Name> names1;
        public List<Name>  Names
        {
            get { return names1; }
            set
            {
                names1 = value;
                OnPropertyChanged("Names");
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
                    GetUsersAsync();
                    GetRoot();
                    
                }

            }
        }
        public string StatusValue { get { return y; } set
            {
                y = value;
                OnPropertyChanged("StatusValue");
            }
        }//Статус отметки
        public string y = "НЕ ОТМЕЧЕНО";

        int xx;
        public int CountRoots { get { return xx; } set { xx = value; OnPropertyChanged("CountRoots"); } }//количество человек в группе
        int x;
        public int EditCountRoots { get { return x; } set { x = value;
                                                            OnPropertyChanged("EditCountRoots");} }//количество присутствующих человек

       
        private async Task<ObservableCollection<User>> GetUsersAsync() //чтение данных о студентах
        {
            try
            {
                var client = new HttpClient();
                var uri = Url;
                List<Name> names = new List<Name>();
                names.Add(new Name() { id = selectedTimeFull3.name, mark = null });
                var conf = new MaillRoot2() { idCode = "12" , name = names };
                var jsonString = JsonConvert.SerializeObject(conf);
                var requestContent = new StringContent(jsonString);
                var result = await client.PostAsync(uri, requestContent);
                var resultContent = await result.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(resultContent);
                var str = o.SelectToken(@"$." + "user");
                List<User> nameIdss = JsonConvert.DeserializeObject<List<User>>(str.ToString());
                List<Enabled> enableds = new List<Enabled>();
                for (int i = 0; i < CountRoots; i++)
                {
                    enableds.Add(new Enabled()
                    {
                        id = i,
                        mark = false
                    });
                }
                CountRoots = nameIdss.Count;
                return Users = new ObservableCollection<User>(nameIdss);
            }
            catch
            {return new ObservableCollection<User>();}
        }
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
                    Console.WriteLine(@"$." + selectedTimeFull3.name); // изменил добавил тройку и имя
                    var str = o.SelectToken(@"$." + selectedTimeFull3.name);                    
                    List<Root> nameIdss = JsonConvert.DeserializeObject<List<Root>>(str.ToString()); 
                  //  CountRoots = nameIdss.Count;
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
                   // EditTapped(selectedRoot);
                }
            }
        }
        private void EditTapped(object obj)
        {
            var content = obj as User;
            EditCountRoots++;
            if (MaillRootList == null)
            {
                List<MaillRoot> maillRoot = new List<MaillRoot>();
                maillRoot.Add(new MaillRoot() { id = content.id, mark = " +", firstName = content.firstName, lastName = content.lastName, patronymic=content.patronymic, data = DateTime.Now });
                MaillRootList = new ObservableCollection<MaillRoot>(maillRoot);

                Names = new List<Name>();
                Names.Add(new Name() { id = content.id, mark = "+" });
                
            }
            else
            {
                MaillRootList.Add(new MaillRoot { id = content.id, mark = " +", firstName = content.firstName, lastName = content.lastName, patronymic = content.patronymic, data = DateTime.Now });
                Names.Add(new Name() { id = content.id, mark = "+" });
            }
        }

        private void NTapped(object obj)
        {
            
            var content = obj as User;
            if (MaillRootList == null)
            {
                List<MaillRoot> maillRoot = new List<MaillRoot>();
                maillRoot.Add(new MaillRoot() { id = content.id, mark = " ++", firstName = content.firstName, lastName = content.lastName, patronymic = content.patronymic, data = DateTime.Now });
                MaillRootList = new ObservableCollection<MaillRoot>(maillRoot);

                Names = new List<Name>();
                Names.Add(new Name() { id = content.id, mark = "++" });

            }
            else
            {
                MaillRootList.Add(new MaillRoot { id = content.id, mark = " ++", firstName = content.firstName, lastName = content.lastName, patronymic = content.patronymic, data = DateTime.Now });
                Names.Add(new Name() { id = content.id, mark = "++" });
            }
        }

        public string Url = "https://script.google.com/macros/s/AKfycbwYLf4Cu8gw8xICie6DHq79VdAwAmGTzW7MUtxgx6kOWjRnqhgwwY4PJT-d5bVvMrnQ/exec";
        private  void MarkTapped2(object obj)
        {
            StatusValue = "ОТМЕЧЕНО";
            var conf = new MaillRoot2() { idCode = "111", name = Names , id= selectedDiscipline.id, title = selectedTimeFull3.name };         
            for(int i =1;i< Users.Count;i++)
            {
                int p = 0;
                for (int j = 0; j < Names.Count;j++)
                {
                    if (Names[j].id == i.ToString())
                    {
                        p = 1;
                    }
                }
                if (p!=1)
                {
                    Names.Add(new Name() { id = i.ToString(), mark = "-" });
                }  
            }
            try
            {
                var client = new HttpClient(); //передаем данные о студентах в sheets
                var uri = Url;                                     
                var jsonString = JsonConvert.SerializeObject(conf);
                var requestContent = new StringContent(jsonString);
                var result =  client.PostAsync(uri, requestContent);
                
            }
            catch
            {

            }
            

        }
        private async void MarkTapped(object obj)
        {
            StatusValue = "ОТМЕЧЕНО";
            var fileName = "Mark.json";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, fileName);

            var data = MaillRootList;           
                //var client = new HttpClient(); передаем данные о студентах в sheets
                //var uri = "https://script.google.com/macros/s/AKfycbzRkXQ30uyIPZ_WAjB5HhluxnscgCxUUKqvmZKkXubVCzLlX7v506BMsWNtMrAKBfBy/exec";
                //for (int i = 0; i<data.Count;i++)
                //{
                //    var jsonString = JsonConvert.SerializeObject(data[i]);
                //    var requestContent = new StringContent(jsonString);
                //    var result = await client.PostAsync(uri,requestContent);
                //}


                File.Create(path).Dispose();
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
            data = null;
            
            string jsondata = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<ObservableCollection<MaillRoot>>(jsondata);
            


        }
    public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
