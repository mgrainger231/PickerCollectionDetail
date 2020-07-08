using System;
using MvvmHelpers;
using PickerCollectionDetail.Models;
using PickerCollectionDetail.Services;
using Xamarin.Forms;

namespace PickerCollectionDetail.ViewModels
{
    [QueryProperty("ItemId", "id")]
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        private string itemId;
        public string ItemId
        {
            get { return itemId; }
            set
            {
                if (SetProperty(ref itemId, value))
                {
                    Console.WriteLine("True, property changed.");
                    // Not sure how to call asymc in setter.
                    // Is this the right place to set the Item?
                    Item = DataStore.GetItemAsync(itemId).Result;
                }
                else
                {
                    Console.WriteLine("False, property did not change.");
                }
            }
        }

        public ItemDetailViewModel()
        {
            
        }
    }
}
