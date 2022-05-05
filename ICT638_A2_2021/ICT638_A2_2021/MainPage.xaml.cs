using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT638_A2_2021
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            string uname = userEntry.Text;
            string pwd = passwordEntry.Text;

            var resultReturn = await App.Database.GetNoteAsync(uname, pwd);

            if (resultReturn != null)
            {
                await Navigation.PushAsync(new HomePage(resultReturn));
            }

            else
            {
               await DisplayAlert("Error", "User not found", "ok");
                // ResultText.Text = "Username/Password not found";
            }
        }

        private async void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }    
}