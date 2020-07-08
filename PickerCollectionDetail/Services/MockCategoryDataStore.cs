using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickerCollectionDetail.Models;

namespace PickerCollectionDetail.Services
{
    public class MockCategoryDataStore : IDataStore<Category>
    {
        readonly List<Category> items;

        public MockCategoryDataStore()
        {
            items = new List<Category>()
            {
                new Category { Id = "b3311ac3-ec93-413c-a6b3-f1b2f8cd7918", Name = "Cars" },
                new Category { Id = "d4ad65ef-f083-46eb-98ed-623201887e59", Name = "Boats" }
            };
        }

        public async Task<bool> AddItemAsync(Category item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Category item)
        {
            var oldItem = items.Where((Category arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Category arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Category> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
        public async Task<IEnumerable<Category>> GetItemsAsync(string categoryId, bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}