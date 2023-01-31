using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app12
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            StudentList.ItemsSource = App.students;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Transfer.Add == true)
            {
                App.students.Add(new Student { FIO = Transfer.FIO, Street = Transfer.Street, House = Transfer.House, Flat = Transfer.Flat });
                StudentList.ItemsSource = null;
                StudentList.ItemsSource = App.students;
                Transfer.Add = false;
                SelectedText.Text = "";
            }
            if (Transfer.Edit == true)
            {
                StudentList.ItemsSource = null;
                StudentList.ItemsSource = App.students;
                Transfer.Edit = false;
                SelectedText.Text = "";
            }
        }
        private void Remove_Clicked(object sender, EventArgs e)
        {
            Student student = StudentList.SelectedItem as Student;
            if (student != null)
            {
                App.students.Remove(student);
                StudentList.ItemsSource = null;
                StudentList.ItemsSource = App.students;
                SelectedText.Text = "";
            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            Student student = StudentList.SelectedItem as Student;
            if (student != null)
            {
                StudentList.SelectedItem = null;
                await Navigation.PushAsync(new EditPage(student));
            }
        }

        private void StudentList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student student;
            if (e.SelectedItem != null)
            {
                student = (Student)e.SelectedItem;
                SelectedText.Text = student.FIO;
            }
        }

        private async void Open_Clicked(object sender, EventArgs e)
        {
            Student student = StudentList.SelectedItem as Student;
            if (student != null)
            {
                await Navigation.PushAsync(new OpenPage(student));
            }
        }

        private void Count_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(streetText.Text))
            {
                int count = App.students.Where(x => x.Street.ToLower() == streetText.Text.ToLower()).Count();
                countText.Text = $"Кол-во студентов: {count}";
            }
            else return;
        }
    }
}
