using SQLite;
using shopList.Gui.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shopList.Gui.Models;

namespace shopList.Gui.Persistence
{
    internal class ShopListDatabase
    {
        private ISQLiteAsyncConnection? _connection;
        private async Task InitAsync()
        {
            if (_connection != null)
            {
                return;
            }
            _connection = new SQLiteAsyncConnection(
               Constants.DataBasePath,
               Constants.Flags
                );
            await _connection.CreateTableAsync<Item>();

        } 
        public async Task<int> SaveItemAsync(Item item)
        {
            await InitAsync();
            return await _connection!.InsertAsync(item);
        }
        public async Task<IEnumerable<Item>> GetAllIteamAsync()
        {
            await InitAsync();
            return await _connection!.Table<Item>().ToListAsync();
        }
        public async Task<int> Removeitemasync(Item item)
        {
            await InitAsync();
            return await _connection!.DeleteAsync(item);
        }
    }
}
