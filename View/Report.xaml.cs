using StoreHouse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StoreHouse.View
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }

        private async void createReport_Click(object sender, RoutedEventArgs e)
        {
            List<ChangeStatus> report = new List<ChangeStatus>();

            if (accepted.IsChecked == true)
            {
                report.AddRange(await DatabaseCommunication.CreateReport(false, true, false, false, (DateTimeOffset)from.SelectedDate, (DateTimeOffset)to.SelectedDate));

                grid.ItemsSource = report;
                amount.Text = grid.Items.Count.ToString();
            }
            else if (onStore.IsChecked == true)
            {
                report.AddRange(await DatabaseCommunication.CreateReport(false, false, true, false, (DateTimeOffset)from.SelectedDate, (DateTimeOffset)to.SelectedDate));
                grid.ItemsSource = report;
                amount.Text = grid.Items.Count.ToString();
            }
            else if (sold.IsChecked == true)
            {
                report.AddRange(await DatabaseCommunication.CreateReport(false, false, false, true, (DateTimeOffset)from.SelectedDate, (DateTimeOffset)to.SelectedDate));
                grid.ItemsSource = report;
                amount.Text = grid.Items.Count.ToString();
            }

            else
            {
                accepted.IsChecked = true;
                onStore.IsChecked = true;
                sold.IsChecked = true;

                grid.ItemsSource = await DatabaseCommunication.CreateReport(true, false, false, false, (DateTimeOffset)from.SelectedDate, (DateTimeOffset)to.SelectedDate);
                amount.Text = grid.Items.Count.ToString();
            }
        }

        private void all_Checked(object sender, RoutedEventArgs e)
        {
            //accepted.IsChecked = true;
            //onStore.IsChecked = true;
            //sold.IsChecked = true;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Store store = new();
            this.Close();
            store.ShowDialog();
        }
    }
}
