using Mobile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace Mobile.Services
{
    internal class ContactDataStore : IDataStore<Contact>
    {
        readonly String dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contact.db");

        readonly SQLiteAsyncConnection database;

        public ContactDataStore()
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Contact>().Wait();
        }

        public async Task<bool> AddItemAsync(Contact item)
        {
            return await Task.FromResult(await database.InsertAsync(item) >= 0);
        }

        public async Task<bool> UpdateItemAsync(Contact item)
        {
            return await Task.FromResult(await database.UpdateAsync(item) >= 0);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = await GetItemAsync(id);

            return await Task.FromResult(await database.DeleteAsync(oldItem) >= 0);
        }

        public async Task<Contact> GetItemAsync(int id)
        {
            return await database.Table<Contact>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<Contact>().ToListAsync();
        }
    }
}
