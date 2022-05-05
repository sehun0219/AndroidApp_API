using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebserviceApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT638_A2_2021
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyDetail : ContentPage
    {
        public PropertyDetail()
        {
            InitializeComponent();
        }
        
      
        public PropertyDetail(Post prop)
        {
            InitializeComponent();
            loadData(prop);
           
        }

        private void loadData(Post prop)
        {
            pid.Text = prop.PTitle;
            pTitle.Text = prop.PTitle;
        }
    }
}