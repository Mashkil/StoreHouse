using StoreHouse.Model.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoreHouse
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        StoreHouseContext storeHouseContext = new StoreHouseContext();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            storeHouseContext.Database.EnsureCreated();
        }

    }
}
