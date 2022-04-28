using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace RainHarvest
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public MainPage()
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

        async void OnSaveRecord(object sender, EventArgs e)
        {
            /*var writerRecord = selectDate.Date.ToString("dd/MM/yyyy") +
                "\nWeight: " + inputWeight.Text + "kg" +
                "\nBMI Value: " + outputResult.Text +
                "\nBMI Status: " + outputBmiStatus.Text +
                "\n";
            File.AppendAllText(fileName, writerRecord + Environment.NewLine);*/

            var selectdate = selectDate.Date.ToString("dd/MM/yyyy");
            var title = inputtitle.Text;
            var note = inputnote.Text;
            var state = findState.ToString();
            var rainfall = Double.Parse(inputRainfall.Text);
            var catchmentarea = Double.Parse(inputCatchmentarea.Text);
            var runoffcoeff = Double.Parse(inputRunoffcoeff.Text);
            var totalRainfall = Double.Parse(outputResult.Text);
            await firebaseHelper.AddRecord(selectdate, title, note, state, rainfall, catchmentarea, runoffcoeff, totalRainfall);

            await DisplayAlert("Record Saved", "Rain Harvest Record has been saved", "OK");

        }
        void showCurrentRecord(object sender, EventArgs e)
        {
            if ((inputRainfall.Text == null) || (inputCatchmentarea.Text == null) || (inputRunoffcoeff.Text == null))
            {
                currentCalc.Text = "(xxxx.xx) X (xx.xx) X (xx.xx) X 0.623= xxx.xx liters";
            }    
            else { 

            var rainfall = Double.Parse(inputRainfall.Text);
            var catchmentarea = Double.Parse(inputCatchmentarea.Text);
            var runoffcoeff = Double.Parse(inputRunoffcoeff.Text);
            var totalRainfall = Double.Parse(outputResult.Text);
            

            //Console.WriteLine(rainfall + "X" + catchmentarea + "X" + runoffcoeff + "=" + totalRainfall);

                if ((rainfall != 0.00) || (catchmentarea != 0.00) || (runoffcoeff != 0.00))
                {
                    var writerRecord = rainfall + "X" + catchmentarea + "X" + runoffcoeff + "X" + 0.623 + "=" + totalRainfall;
                    //return writerRecord;
                    currentCalc.Text = writerRecord;
                }
                else
                {
                    currentCalc.Text = "(xxxx.xx) X (xx.xx) X (xx.xx) X 0.623= xxx.xx liters";
                }
            }
        }

        void onDatePickerSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate.ToString();
        }
        void OnCalculateRH(object sender, EventArgs e)
        {
            var rainfall = 0.0;
            var catchmentarea = 0.0;
            var runoffcoeff = 0.0;
            var totalRainfall = 0.0;

            if ((Double.TryParse(inputRainfall.Text, out rainfall)) && (Double.TryParse(inputCatchmentarea.Text, out catchmentarea)) && (Double.TryParse(inputRunoffcoeff.Text, out runoffcoeff)))
            {
                totalRainfall = rainfall * catchmentarea * runoffcoeff * 0.623;
                outputResult.Text = string.Format("{0:##.00}", totalRainfall);
            }
            else
            {
                outputResult.Text = "Please enter a valid value";
            }

        }
        void OnReset(object sender, EventArgs e)
        {
            inputRainfall.Text = null;
            inputCatchmentarea.Text = null;
            outputResult.Text = "0.00";
        }
        private async void Button_Cliked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPageMetric());
        }
    }
}
