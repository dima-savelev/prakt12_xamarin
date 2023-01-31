using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app12
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }
        private async void Add_Clicked(object sender, EventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(fioText.Text))
            {
                errors.AppendLine("Введите ФИО");
            }
            if (string.IsNullOrEmpty(streetText.Text))
            {
                errors.AppendLine("Введите улицу");
            }
            if (string.IsNullOrEmpty(houseText.Text))
            {
                errors.AppendLine("Введите дом");
            }
            if (!int.TryParse(flatText.Text, out int flat) || flat <= 0)
            {
                errors.AppendLine("Квартира введена неверно");
            }
            if (errors.Length > 0)
            {
                await DisplayAlert("Ошибка", errors.ToString(), "ОК");
                return;
            }
            Transfer.FIO = fioText.Text;
            Transfer.Street = streetText.Text;
            Transfer.House = houseText.Text;
            Transfer.Flat = flat;
            Transfer.Add = true;
            await Navigation.PopAsync();
        }
    }
}