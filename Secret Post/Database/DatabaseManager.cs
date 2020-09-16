using SecretPost.Database.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SecretPost.Database
{
    public class DatabaseManager
    {
        private bool isEmpty;
        private SQLiteConnection database;
        public ObservableCollection<Post> posts { get; set; }

        public DatabaseManager()
        {
            database = DependencyService.Get<IConnection>().GetConnection("dados.db3");
            database.CreateTable<Post>();

            posts = new ObservableCollection<Post>(database.Table<Post>().OrderBy(post => post.CreatedAt));

            isEmpty = !database.Table<Post>().Any();
        }

        public void Add(Post post)
        {
            posts.Add(post);
            database.Insert(post);
        }

        public void Update(Post post)
        {
            if (post.Id > 0)
                database.Update(post);
        }

        public void Delete(Post post)
        {
            posts.Remove(post);
            if (post.Id > 0)
                database.Delete<Post>(post.Id);
        }
    

        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    }
}
