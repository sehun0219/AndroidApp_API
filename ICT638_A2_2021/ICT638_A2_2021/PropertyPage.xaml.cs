using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebserviceApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT638_A2_2021
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyPage : ContentPage
    {

        private const string Url = "https://10.0.2.2:7167/RProperty";

        private HttpClient _client = new HttpClient();

        //private ObservableCollection<Post> _posts;
        private ObservableCollection<Post> _posts;
        public PropertyPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            HttpClientHandler handler = GetInsecureHandler();
            _client = new HttpClient(handler);
            var content = await _client.GetStringAsync(Url);
            var posts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            postsListView.ItemsSource = _posts;

            base.OnAppearing();
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        private async void OnRadioButtonCheckedChanged(object sender, SelectedItemChangedEventArgs e)
        {
            Post SelectedItem = e.SelectedItem as Post;

            await Navigation.PushAsync(new AgentPage());
        }


        private async void postsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Post SelectedItem = e.SelectedItem as Post;
            await Navigation.PushAsync(new PropertyDetail(SelectedItem));
        }
    }
}
