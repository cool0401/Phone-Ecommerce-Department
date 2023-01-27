using Mobile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace Mobile.Services
{
    public class PhoneDataStore : IDataStore<Phone>
    {
        readonly String dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "phone.db");

        readonly SQLiteAsyncConnection database;

        public PhoneDataStore()
        {            
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Phone>().Wait();
        }

        public async Task<bool> AddItemAsync(Phone item)
        {
            /*if (item.Id != 0)
            {
                // Update an existing phone.
                return await Task.FromResult(await database.UpdateAsync(item) >= 0);
            }
            else
            {
                // Save a new phone.
                return await Task.FromResult(await database.InsertAsync(item) >= 0);
            }*/
            return await Task.FromResult(await database.InsertAsync(item) >= 0);
        }

        public async Task<bool> UpdateItemAsync(Phone item)
        {
            return await Task.FromResult(await database.UpdateAsync(item) >= 0);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = await GetItemAsync(id);

            return await Task.FromResult(await database.DeleteAsync(oldItem) >= 0);
        }

        public async Task<Phone> GetItemAsync(int id)
        {
            return await database.Table<Phone>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        //public Phone getItem()
        //{
        //    using (SqlCommand sqlCmd2 = new SqlCommand("SELECT ItemImage  from InventoryMaster where ItemImage is not null ", database))
        //    using (SqlDataReader sqlReader2 = sqlCmd2.ExecuteReader())
        //    {
        //        while (sqlReader2.Read())
        //            byte[] imgByte = (byte[])sqlReader2.GetValue(0));
        //    }
        //}

        public async Task<IEnumerable<Phone>> GetItemsAsync(bool forceRefresh = false)
        {
            return await database.Table<Phone>().ToListAsync();
        }
    }
}