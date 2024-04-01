using Pr2Dataset.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pr2Dataset
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public Page3()
        {
            InitializeComponent();
            OrdersDataGrid.ItemsSource = orders.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            orders.InsertQuery(Convert.ToInt32(NameTb.Text), Convert.ToInt32 (NameTb1.Text));
            OrdersDataGrid.ItemsSource = orders.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (OrdersDataGrid.SelectedItem as DataRowView).Row[0];
            orders.UpdateQuery(Convert.ToInt32(NameTb.Text),Convert.ToInt32 (NameTb1.Text),  Convert.ToInt32(id));
            OrdersDataGrid.ItemsSource = orders.GetData();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (OrdersDataGrid.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery(Convert.ToInt32(id));
            OrdersDataGrid.ItemsSource = orders.GetData();
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem != null)
            {
                DataRowView row = OrdersDataGrid.SelectedItem as DataRowView;
                if (row != null)
                {
                    NameTb.Text = row.Row["ID_Customer"].ToString();
                    NameTb1.Text = row.Row["ID_Burger"].ToString();                   
                }
            }
        }
    }
}
