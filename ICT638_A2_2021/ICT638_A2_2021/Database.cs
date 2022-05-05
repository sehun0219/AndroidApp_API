using ICT638_A2_2021.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICT638_A2_2021
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserDetails>().Wait();
        }

        public Task<int> SaveNoteAsync(UserDetails user)
        {
            return database.InsertAsync(user);
        }
        public Task<int> UpdateUserAsync(UserDetails user)
        {
            return database.UpdateAsync(user);
        }
        public Task<UserDetails> GetNoteAsync(string uname, string pwd)
        {
            return database.Table<UserDetails>()
                            .Where(i => i.UniqueUserName == uname && i.Password == pwd)
                            .FirstOrDefaultAsync();
        }
    }
}
