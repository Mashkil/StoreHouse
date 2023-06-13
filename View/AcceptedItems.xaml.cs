using StoreHouse.Enums;
using StoreHouse.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StoreHouse.View
{
    /// <summary>
    /// Логика взаимодействия для AcceptedItems.xaml
    /// </summary>
    public partial class AcceptedItems : Window
    {
        public AcceptedItems()
        {
            InitializeComponent();
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new();
            addItem.ShowDialog();
        }

        private void goToSoldItems_Click(object sender, RoutedEventArgs e)
        {
            SoldItems soldItems = new();
            this.Close();
            soldItems.ShowDialog();
        }

        private void goToStore_Click(object sender, RoutedEventArgs e)
        {
            Store store = new();
            this.Close();
            store.ShowDialog();

        }

        private async void showItems_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await DatabaseCommunication.GetItems(Enums.Status.Accepted);
        }

        private async void toStoreClick(object sender, RoutedEventArgs e)
        {
            var idOfItem = new DataGridCellInfo(grid.Items[grid.SelectedIndex], grid.Columns[0]);
            var idTxt = idOfItem.Column.GetCellContent(idOfItem.Item) as TextBlock;

            await DatabaseCommunication.ToStore(Convert.ToInt32(idTxt.Text));

            grid.ItemsSource = await DatabaseCommunication.GetItems(Status.Accepted);
        }
    }
}
