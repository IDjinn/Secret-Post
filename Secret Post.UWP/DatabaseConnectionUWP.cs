using SecretPost.Database;
using SecretPost.UWP;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnectionUWP))]
namespace SecretPost.UWP
{
    public class DatabaseConnectionUWP :IConnection
    {
        public SQLiteConnection GetConnection(string fileName)
        {
            string documentsFolder = ApplicationData.Current.LocalFolder.Path;
            string path = Path.Combine(documentsFolder, fileName);
            return new SQLiteConnection(path);
        }
    }
}
