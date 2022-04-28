using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RainHarvest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageBmiFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageBmiFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageBmiFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageBmiFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageFlyoutMenuItem> MenuItems { get; set; }

            public MasterDetailPageBmiFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageFlyoutMenuItem { Id = 0, Title = "Rain Harvest Calculator", TargetType=typeof(MainPage)},
                    new MasterDetailPageFlyoutMenuItem { Id = 1, Title = "About", TargetType=typeof(About) },
                    new MasterDetailPageFlyoutMenuItem { Id = 2, Title = "Record", TargetType=typeof(TabbedRecord)},
                    new MasterDetailPageFlyoutMenuItem { Id = 3, Title = "Runoff Coefficient Table", TargetType=typeof(RunoffCoefficientTable) },
                    new MasterDetailPageFlyoutMenuItem { Id = 5, Title = "Malaysia's Rainfall Average Table", TargetType=typeof(MsiaRainHarvestAvgTable) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}