using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BotAnalyst.Core;
using MongoDB.Driver;

namespace BotAnalyst.Application.Services
{
    public class Repository
    {
        private readonly IMongoDatabase _database;

        public Repository(IMongoDatabase database)
        {
            _database = database;
        }

        public Task SaveAsync<T>(T item) where T : IEntity
        {
            return GetCollection<T>().ReplaceOneAsync(s => s.Id == item.Id, item, new UpdateOptions {IsUpsert = true});
        }

        public async Task<T[]> FindAsync<T>(Expression<Func<T, bool>> predicate)
        {
            var items= await GetCollection<T>().Find(predicate).ToListAsync();

            return items.ToArray();
        }

        private IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name);
    }
}
