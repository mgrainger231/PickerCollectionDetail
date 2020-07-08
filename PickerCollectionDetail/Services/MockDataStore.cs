using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickerCollectionDetail.Models;

namespace PickerCollectionDetail.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First Car", Description="This is an item description.", CategoryId="b3311ac3-ec93-413c-a6b3-f1b2f8cd7918"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second Car", Description="This is an item description." , CategoryId="b3311ac3-ec93-413c-a6b3-f1b2f8cd7918"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third Car", Description="This is an item description." , CategoryId="b3311ac3-ec93-413c-a6b3-f1b2f8cd7918"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth Boat", Description="This is an item description.", CategoryId="d4ad65ef-f083-46eb-98ed-623201887e59" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth Boat", Description="This is an item description." , CategoryId="d4ad65ef-f083-46eb-98ed-623201887e59"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth Boat", Description="This is an item description." , CategoryId="d4ad65ef-f083-46eb-98ed-623201887e59"}
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string categoryId, bool forceRefresh = false)
        {
            return await Task.FromResult(items.Where(c => c.CategoryId == categoryId));
        }
    }
}