using Kanban.Models;
using SQLite.Net;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kanban.Services.LocalDatabase
{
    class LocalDatabaseService
    {
        IDbConnectionService dbConnectionService;
        SQLiteAsyncConnection database;

        public LocalDatabaseService()
        {
            dbConnectionService = DependencyService.Get<IDbConnectionService>();

            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => dbConnectionService.GetConnection());
            database = new SQLiteAsyncConnection(connectionFactory);
        }

        public async Task Initialize()
        {
            await database.CreateTableAsync<TaskModel>();
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await database.Table<TaskModel>().ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(string id)
        {
            return await database.GetAsync<TaskModel>(id);
        }

        public async Task Create(TaskModel task)
        {
            await database.InsertAsync(task);
        }

        public async Task Update(TaskModel task)
        {
            await database.UpdateAsync(task);
        }

        public async Task Delete(string id)
        {
            await database.DeleteAsync<TaskModel>(id);
        }
    }
}
