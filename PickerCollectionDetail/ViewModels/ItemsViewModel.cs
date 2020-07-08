using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using PickerCollectionDetail.Models;
using PickerCollectionDetail.Views;
using PickerCollectionDetail.Services;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using System.Linq;
using System.Collections.Generic;

namespace PickerCollectionDetail.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public Item SelectedItem { get; set; }
        public Category SelectedCategory { get; set; }

        public ObservableRangeCollection<Item> Items { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public ICommand LoadItemsCommand { get; set; }
        public ICommand AddItemCommand { get; set; }
        public ICommand SelectedItemCommand { get; set; }
        public ICommand CategoryPickerCommand { get; set; }

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IDataStore<Category> CategoryDataStore => DependencyService.Get<IDataStore<Category>>();

        public ItemsViewModel()
        {
            Title = "Browse by Category";
            Categories = new ObservableCollection<Category>();
            Items = new ObservableRangeCollection<Item>();

            LoadItemsCommand = new AsyncCommand(ExecuteLoadItemsCommand, CanExecuteLoadItemsCommand);
            AddItemCommand = new AsyncCommand(ExecuteAddItemCommand, CanExecuteAddItemCommand);
            SelectedItemCommand = new AsyncCommand(ExecuteSelectedItemCommand, CanExecuteSelectedItemCommand);
            CategoryPickerCommand = new AsyncCommand(ExecuteLoadItemsCommand, CanExecuteCategoryPickerCommand);

            //TODO Not sure this should be in the constructor
            _ = LoadCategories();

        }
        
        private async Task ExecuteSelectedItemCommand()
        {
            string itemId = Uri.EscapeDataString(SelectedItem.Id);
            
            // Navigate to details page
            await Shell.Current.GoToAsync($"itemdetail?id={itemId}");

            // Unselect item from CollectionView
            SelectedItem = null;
        }

        private async Task ExecuteAddItemCommand()
        {
            await Shell.Current.GoToAsync($"newitem");
        }
                
        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                if (SelectedCategory != null)
                {
                    IEnumerable<Item> items = await DataStore.GetItemsAsync(SelectedCategory.Id, true);
                    Items.ReplaceRange(items);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task LoadCategories()
        {
            IsBusy = true;

            try
            {
                Categories.Clear();
                var categories = await CategoryDataStore.GetItemsAsync(true);
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanExecuteLoadItemsCommand(object arg)
        {
            return true;
        }
        private bool CanExecuteAddItemCommand(object arg)
        {
            return true;
        }
        private bool CanExecuteSelectedItemCommand(object arg)
        {
            return true;
        }
        private bool CanExecuteCategoryPickerCommand(object arg)
        {
            return true;
        }
    }
}