using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretPost.Database
{
    public interface IConnection
    {
        SQLiteConnection GetConnection(string fileName);
    }
}
