using Misis2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace Misis2.ModelView
{
    public class FourPageModel : INotifyPropertyChanged
    {
        public FourPageModel()
        {
            GetMaillRoot();
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
        private ObservableCollection<MaillRoot> GetMaillRoot()
        {
            try
            {
                var fileName = "Mark.json";
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, fileName);

                var data = MaillRootList;
                string jsondata = File.ReadAllText(path);
                data = JsonConvert.DeserializeObject<ObservableCollection<MaillRoot>>(jsondata);
          
                return MaillRootList = new ObservableCollection<MaillRoot>(data);
            }
            catch
            { return new ObservableCollection<MaillRoot>(); }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
