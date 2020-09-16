using SecretPost.Database;
using SecretPost.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecretPost.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public DatabaseManager databaseManager;
        public Main()
        {
            InitializeComponent();

            databaseManager = new DatabaseManager();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = databaseManager;
            if (databaseManager.IsEmpty)
            {
                DisplayAlert("Alerta", "Database está vazia", "OK");
            }
        }

        private void CreatePost(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CreatePost(1, databaseManager, null));
        }

        private void UpdatePost(object sender, EventArgs args)
        {
            Post post = PostList.SelectedItem as Post;
            if(post != null)
            {
                Navigation.PushAsync(new CreatePost(2, databaseManager, post));
            }
            else
            {
                DisplayAlert("Oops", "Você precisa selecionar algum post para editar.", "OK");
            }
        }
        private void DeletePost(object sender, EventArgs args)
        {
            Post post = PostList.SelectedItem as Post;
            if (post != null)
            {
                databaseManager.Delete(post);
            }
            else
            {
                DisplayAlert("Oops", "Você precisa selecionar algum post para editar.", "OK");
            }
        }
    }
}