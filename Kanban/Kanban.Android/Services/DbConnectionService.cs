using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Kanban.Droid.Services;
using SQLite.Net;
using Xamarin.Forms;
using Kanban.Services.LocalDatabase;

[assembly: Dependency(typeof(DbConnectionService))]
namespace Kanban.Droid.Services
{
    public class DbConnectionService : IDbConnectionService
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