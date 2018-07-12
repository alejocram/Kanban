using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Kanban.iOS.Services;
using Kanban.Services.LocalDatabase;
using SQLite.Net;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbConnectionService))]
namespace Kanban.iOS.Services
{
    class DbConnectionService : IDbConnectionService
    {
        public SQLiteConnectionWithLock GetConnection()
        {
            var sqliteFilename = "SQLite.db3";

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connectionString = new SQLiteConnectionString(path, false);
            var connection = new SQLiteConnectionWithLock(platform, connectionString);

            return connection;
        }

    }
}