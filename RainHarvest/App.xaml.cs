using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RainHarvest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new MasterDetailPageBmi();
            //MainPage.BackgroundColor = Color.SteelBlue;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
