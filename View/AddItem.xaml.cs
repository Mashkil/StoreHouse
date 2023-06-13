using StoreHouse.Model;
using System;
using System.Windows;

namespace StoreHouse.View
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item
            {
                Name = name.Text,
                Amount = Convert.ToInt32(amount.Text),
                Cost = Convert.ToDouble(cost.Text),
                Status = Enums.Status.Accepted,
                TimestampCreated = DateTimeOffset.UtcNow,
                Description = desciption.Text                
            };

            await DatabaseCommunication.AddItem(item);

            this.Close();
        }
    }
}
