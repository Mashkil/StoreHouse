using StoreHouse.Enums;
using StoreHouse.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace StoreHouse.View
{
    /// <summary>
    /// Логика взаимодействия для Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        public Store()
        {
            InitializeComponent();
        }

        private async void showItems_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = await DatabaseCommunication.GetItems(Status.OnStoreHouse);
        }

        private void goToAcceptedItems_Click(object sender, RoutedEventArgs e)
        {
            AcceptedItems acceptedItems = new();
            this.Close();
            acceptedItems.ShowDialog();
            
        }

        private void goToSoldItems_Click(object sender, RoutedEventArgs e)
        {
            SoldItems soldItems = new();
            this.Close();
            soldItems.ShowDialog();
            
        }

        private async void sold_click(object sender, RoutedEventArgs e)
        {
            var idOfItem = new DataGridCellInfo(grid.Items[grid.SelectedIndex], grid.Columns[0]);
            var idTxt = idOfItem.Column.GetCellContent(idOfItem.Item) as TextBlock;

            await DatabaseCommunication.Sold(Convert.ToInt32(idTxt.Text));

            grid.ItemsSource = await DatabaseCommunication.GetItems(Status.OnStoreHouse);
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
            Report report = new();
            this.Close();
            report.ShowDialog();
        }
    }
}
