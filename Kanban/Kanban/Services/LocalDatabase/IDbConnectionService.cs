using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.LocalDatabase
{
    public interface IDbConnectionService
    {
        SQLiteConnectionWithLock GetConnection();
    }
}
