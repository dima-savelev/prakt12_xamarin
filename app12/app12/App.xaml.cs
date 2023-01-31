using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app12
{
    public partial class App : Application
    {
        public static ObservableCollection<Student> students = new ObservableCollection<Student>();
        public App()
        {
            InitializeComponent();
            if (Application.Current.Properties.TryGetValue("db", out object value) == true)
            {
                var list = JsonConvert.DeserializeObject<List<Student>>(value.ToString());
                App.students = new ObservableCollection<Student>(list);
            }
            else
            {
                string json = JsonConvert.SerializeObject(students);
                Application.Current.Properties["db"] = json;
                Application.Current.SavePropertiesAsync();
            }
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            string json = JsonConvert.SerializeObject(students);
            Application.Current.Properties["db"] = json;
            Application.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
        }
    }
}
