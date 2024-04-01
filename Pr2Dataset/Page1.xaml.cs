using Pr2Dataset.DataSet1TableAdapters;
using Pr2Dataset.THRDataSetTableAdapters;
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
using System.Xml;
using BurgersTableAdapter = Pr2Dataset.DataSet1TableAdapters.BurgersTableAdapter;

namespace Pr2Dataset
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        BurgersTableAdapter burgers = new BurgersTableAdapter();



        public Page1()
        {
            InitializeComponent();
            BurgersDataGrid.ItemsSource = burgers.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal value3, value4, value5;
            if (decimal.TryParse(NamTbl3.Text, out value3) &&
                decimal.TryParse(NamTbl4.Text, out value4) &&
                decimal.TryParse(NamTbl5.Text, out value5))
            {
                burgers.InsertQuery(NamTbl1.Text, NamTbl2.Text, value3, value4, value5);
                BurgersDataGrid.ItemsSource = burgers.GetData();
            }
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (BurgersDataGrid.SelectedItem as DataRowView).Row[0];
            burgers.UpdateQuery(NamTbl1.Text, NamTbl2.Text,Convert.ToDecimal (NamTbl3.Text), Convert.ToDecimal(NamTbl4.Text), Convert.ToDecimal(NamTbl5.Text), Convert.ToInt32(id));
            BurgersDataGrid.ItemsSource = burgers.GetData();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (BurgersDataGrid.SelectedItem as DataRowView).Row[0];
            burgers.DeleteQuery(Convert.ToInt32(id));
            BurgersDataGrid.ItemsSource = burgers.GetData();
        }

        private void BurgersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BurgersDataGrid.SelectedItem != null)
            {
                DataRowView row = BurgersDataGrid.SelectedItem as DataRowView;
                if (row != null)
                {
                    NamTbl1.Text = row.Row["BurgerName"].ToString();
                    NamTbl2.Text = row.Row["BurgerIngredient"].ToString();
                    NamTbl3.Text = row.Row["BurgerSum"].ToString();
                    NamTbl4.Text = row.Row["BurgerWeight"].ToString();
                    NamTbl5.Text = row.Row["BurgerLength"].ToString();
                }
            }
        }
    }
    
}
