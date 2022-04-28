using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RainHarvest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MsiaRainHarvestAvgTable : ContentPage
    {
        public MsiaRainHarvestAvgTable()
        {
            InitializeComponent();

            findState.Items.Add("Selangor");
            findState.Items.Add("Melaka");
            findState.Items.Add("Negeri Sembilan");
            findState.Items.Add("Kedah");
            findState.Items.Add("Perak");
            findState.Items.Add("Pahang");
            findState.Items.Add("Johor");
            findState.Items.Add("Kelantan");
            findState.Items.Add("Terengganu");
            findState.Items.Add("Pulau Pinang");
            findState.Items.Add("Perlis");
            findState.Items.Add("Sabah");
            findState.Items.Add("Sarawak");
        }
    }
}