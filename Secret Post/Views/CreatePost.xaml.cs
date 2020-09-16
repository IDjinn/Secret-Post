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
    public partial class CreatePost : ContentPage
    {
        private DatabaseManager databaseManager { get; }
        private int op { get; }
        private Post post { get; }
        public CreatePost(int op, DatabaseManager databaseManager, Post post)
        {
            InitializeComponent();

            this.databaseManager = databaseManager;
            this.op = op;

            if(op == 1)
            {
                post = new Post();
                this.post = post;
            }
            else
            {
                this.post = post;
                BindingContext = post;
            }
        }

        public void Save(object sender, EventArgs args)
        {
            try
            {
                if (title.Text.Equals("") || title.Text.Equals(""))
                {
                    DisplayAlert("Erro", "Há campos em branco!", "OK");
                }
                else
                {
                    if(op == 1)
                    {
                        post.Title = title.Text;
                        post.Message = message.Text;
                        post.CreatedAt = DateTime.Now;
                        post.UserId = (uint)new Random().Next();
                        databaseManager.Add(post);
                    }
                    else
                    {
                        databaseManager.Update(post);
                    }

                    Navigation.PopAsync();
                }
            }
            catch(Exception e)
            {
                DisplayAlert("Erro", "Erro ao criar o post: " + e.ToString(), "OK");
            }
        }
    }
}