using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PickerCollectionDetail.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            Subtitle = "Picker Collection Detail";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}