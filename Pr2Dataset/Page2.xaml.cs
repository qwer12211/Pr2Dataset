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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        CustomersTableAdapter customers = new CustomersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            CustomersDataGrid.ItemsSource = customers.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            customers.InsertQuery(NameTbl1.Text, NameTbl2.Text, NameTbl3.Text, NameTbl4.Text, NameTbl5.Text);
            CustomersDataGrid.ItemsSource = customers.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (CustomersDataGrid.SelectedItem as DataRowView).Row[0];
            customers.UpdateQuery(NameTbl1.Text, NameTbl2.Text, NameTbl3.Text, NameTbl4.Text, NameTbl5.Text, Convert.ToInt32(id));
            CustomersDataGrid.ItemsSource = customers.GetData();
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (CustomersDataGrid.SelectedItem as DataRowView).Row[0];
            customers.DeleteQuery(Convert.ToInt32(id));
            CustomersDataGrid.ItemsSource = customers.GetData();
        }

        private void CustomersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem != null)
            {
                DataRowView row = CustomersDataGrid.SelectedItem as DataRowView;
                if (row != null)
                {
                    NameTbl1.Text = row.Row["CustomerName"].ToString();
                    NameTbl2.Text = row.Row["CustomerSurename"].ToString();
                    NameTbl3.Text = row.Row["CustomerMiddleName"].ToString();
                    NameTbl4.Text = row.Row["CustomerCard"].ToString();
                    NameTbl5.Text = row.Row["CustomerNumberOfPhone"].ToString();
                }
            }
        }
    }
}
