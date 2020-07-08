using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PickerCollectionDetail.Services;
using PickerCollectionDetail.Views;

namespace PickerCollectionDetail
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockCategoryDataStore>();
            MainPage = new AppShell();
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
