using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamFormsCRUDSQLite.Models;

namespace XamFormsCRUDSQLite.Data
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        ISQLiteAsyncConnectionService _connectionService;
        SQLiteAsyncConnection _connection;

        public Repository(ISQLiteAsyncConnectionService connectionService)
        {
            _connectionService = connectionService;
            _connection = _connectionService.GetConnection();
            _connection.CreateTableAsync<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _connection.Table<T>().ToListAsync();
        }

        public Task<int> InsertAsync(T entity)
        {
            return _connection.InsertAsync(entity);
        }

        public Task<int> UpdateAsync(T entity)
        {
            return _connection.UpdateAsync(entity);
        }

        public Task<int> DeleteAsync(T entity)
        {
            return _connection.DeleteAsync(entity);
        }
    }
}
