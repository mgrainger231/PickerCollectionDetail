using System;
using System.Collections.Generic;
using PickerCollectionDetail.Views;
using Xamarin.Forms;

namespace PickerCollectionDetail
{    
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public Dictionary<string, Type> Routes { get; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();

        }
        void RegisterRoutes()
        {
            Routes.Add("about", typeof(AboutPage));
            Routes.Add("itemdetail", typeof(ItemDetailPage));
            Routes.Add("items", typeof(ItemsPage));
            Routes.Add("newitem", typeof(NewItemPage));

            foreach (var route in Routes)
            {
                Routing.RegisterRoute(route.Key, route.Value);
            }
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
