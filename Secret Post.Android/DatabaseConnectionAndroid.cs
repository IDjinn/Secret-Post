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
using SecretPost.Database;
using SecretPost.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnectionAndroid))]

namespace SecretPost.Droid
{
    public class DatabaseConnectionAndroid :IConnection
    {
        public SQLiteConnection GetConnection(string fileName)
        {
            string documentsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsFolder, fileName);
            return new SQLiteConnection(path);
        }
    }
}