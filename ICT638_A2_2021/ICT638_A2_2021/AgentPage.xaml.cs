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
    public partial class AgentPage : ContentPage
    {
        private const string Url = "https://10.0.2.2:7167/RAgent";

        private HttpClient _client = new HttpClient();

        //private ObservableCollection<Post> _posts;
        private ObservableCollection<Agent> _posts;
        public AgentPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            HttpClientHandler handler = GetInsecureHandler();
            _client = new HttpClient(handler);
            var content = await _client.GetStringAsync(Url);
            var posts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Agent>>(content);
            _posts = new ObservableCollection<Agent>(posts);
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
        private async void postsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Agent SelectedItem = e.SelectedItem as Agent;
            await Navigation.PushAsync(new PropertyDetail());
        }
        private void Agent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}