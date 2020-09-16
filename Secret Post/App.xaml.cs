using SecretPost.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Secret_Post
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Main());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
