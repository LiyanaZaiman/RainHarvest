using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace RainHarvest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
        }
        async void OnBacfree(object sender, EventArgs args)
        {

            await Browser.OpenAsync("https://bacfree.com.my/about-us/", BrowserLaunchMode.SystemPreferred);
        }

        async void OniRain(object sender, EventArgs args)
        {

            await Browser.OpenAsync("https://www.i-rainharvesting.com/?gclid=CjwKCAiAx8KQBhAGEiwAD3EiPwhMc40KsLKtb4WGioGs6n_VxZO-AjGr7kdO6eIx-YFdcm1sGoXluxoC5wgQAvD_BwE ", BrowserLaunchMode.SystemPreferred);

        }
    }
}