using System;
using MvvmHelpers;
using PickerCollectionDetail.Models;
using PickerCollectionDetail.Services;
using Xamarin.Forms;

namespace PickerCollectionDetail.ViewModels
{
    
    public class NewItemViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        public NewItemViewModel()
        {
            Item = new Item();
        }
    }
}
