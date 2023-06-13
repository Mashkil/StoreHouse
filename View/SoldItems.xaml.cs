using StoreHouse.Enums;
using StoreHouse.Model;
using System.Windows;

namespace StoreHouse.View
{
    /// <summary>
    /// Логика взаимодействия для SoldItems.xaml
    /// </summary>
    public partial class SoldItems : Window
    {
        public SoldItems()
        {
            InitializeComponent();
        }

        private void goToAcceptedItems_Click(object sender, RoutedEventArgs e)
        {
            AcceptedItems acceptedItems = new();
            this.Close();
            acceptedItems.ShowDialog();
            
        }

        private void goToStore_Click(object sender, RoutedEventArgs e)
        {
            Store store = new();
            this.Close();
            store.ShowDialog();
            
        }

        private async void showItems_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await DatabaseCommunication.GetItems(Status.Sold);
        }
    }
}
