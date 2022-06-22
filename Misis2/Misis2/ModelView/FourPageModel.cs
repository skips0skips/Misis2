using Misis2.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Misis2.ModelView
{
    public class FourPageModel : INotifyPropertyChanged
    {
        public FourPageModel()
        {
           
        }

        private MaillRoot selectedMaillRoot;
        public MaillRoot SelectedMaillRoot
        {
            get { return selectedMaillRoot; }
            set
            {
                if (selectedMaillRoot != value)
                {
                    selectedMaillRoot = value;
                    OnPropertyChanged("SelectedMaillRoot");                    
                }

            }
        }
        private ObservableCollection<MaillRoot22> maillRoots;
        public ObservableCollection<MaillRoot22> MaillRootList
        {
            get { return maillRoots; }
            set
            {
                maillRoots = value;
                OnPropertyChanged("MaillRootList");
                
            }
        }
        private MaillRoot223 maillRoot223;
        public MaillRoot223 MaillRoot223s
        {
            get { return maillRoot223; }
            set
            {
                maillRoot223 = value;
                OnPropertyChanged("MaillRoot223s");
                GetTimeFullAsync();
            }
        }
        public string Url = "https://script.google.com/macros/s/AKfycbwleHosh-OKQlOfRdfVwOdAUlZKi2jwkau8wGDd-1aPawIjVMJCKaO1oEbSLi1DwhN6/exec";
        private async Task<ObservableCollection<MaillRoot22>> GetTimeFullAsync()
        {
            try
            {
                var client = new HttpClient();
                var uri = Url;//;
                
                var conf = new MaillRoot223() { idCode = MaillRoot223s.idCode , name = maillRoot223.name, date = maillRoot223.date, grop=maillRoot223.grop , id =maillRoot223.id};
                var jsonString = JsonConvert.SerializeObject(conf);
                var requestContent = new StringContent(jsonString);
                var result = await client.PostAsync(uri, requestContent);
                var resultContent = await result.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(resultContent);
                var str = o.SelectToken(@"$." + "user");
                List<MaillRoot22> timeFullss = JsonConvert.DeserializeObject<List<MaillRoot22>>(str.ToString());
                return MaillRootList = new ObservableCollection<MaillRoot22>(timeFullss);
            }
            catch { return new ObservableCollection<MaillRoot22>(); }

        }
        //private ObservableCollection<MaillRoot> GetMaillRoot()
        //{
        //    try
        //    {
        //        var fileName = "Mark.json";
        //        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
        //        var path = Path.Combine(documentsPath, fileName);

        //        var data = MaillRootList;
        //        string jsondata = File.ReadAllText(path);
        //        data = JsonConvert.DeserializeObject<ObservableCollection<MaillRoot>>(jsondata);
          
        //        return MaillRootList = new ObservableCollection<MaillRoot>(data);
        //    }
        //    catch
        //    { return new ObservableCollection<MaillRoot>(); }

        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
