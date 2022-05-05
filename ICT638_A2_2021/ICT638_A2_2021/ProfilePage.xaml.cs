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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        private UserDetails getUser;
        public ProfilePage(UserDetails user)
        {
            InitializeComponent();
            getUser = user;
            entryUserName.IsEnabled = true;
            entryPassword.IsEnabled = true;

            entryUserName.Text = getUser.UniqueUserName;
            entryPassword.Text = getUser.Password;
            entryPhone.Text = getUser.PhoneNum;// need to complete from database

        }


        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            getUser.UniqueUserName= entryUserName.Text;
            getUser.Password= entryPassword.Text;
            getUser.PhoneNum= entryPhone.Text;
            await App.Database.UpdateUserAsync(getUser);
            await DisplayAlert("Saved", "Your new details are saved", "ok");
            // var reg = new UserDetails();
            //entryUserName.Text=getUser.UniqueUserName;
            //reg.Password = entryPassword.Text;
           // await App.Database.SaveNoteAsync(reg);
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}