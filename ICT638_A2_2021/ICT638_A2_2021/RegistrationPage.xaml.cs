using ICT638_A2_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT638_A2_2021
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var reg = new UserDetails();
            reg.UniqueUserName =entryUserName.Text;
            reg.Password =entryPassword.Text;
            await App.Database.SaveNoteAsync(reg);
            await DisplayAlert("Saved", "Your new details are saved", "ok");
            await Navigation.PushAsync(new MainPage());

        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}