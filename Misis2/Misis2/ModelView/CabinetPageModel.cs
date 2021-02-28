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
        public CabinetPageModel()
        {
            LoadDataCommand = new Command(LoadData);
        }
        private decimal rate;
        public decimal Rate
        {
            get { return rate; }
            private set
            {
                rate = value;
                OnPropertyChanged("Rate");
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
                    var str = o.SelectToken(@"$.query.results.rate");
                    var rateInfo = JsonConvert.DeserializeObject<TestModel>(str.ToString());
                    this.Rate = rateInfo.Rate;
                }
            }
            catch (Exception ex)
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
