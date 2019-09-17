using S3.Northwind.DataAccess;
using S3.Northwind.Entities;
using S3.Northwind.Gui.Desktop.ViewModels;
using S3.Northwind.ValidationWebService;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S3.Northwind.Gui.Desktop
{
    /// <summary>
    /// Interaction logic for OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl
    {
        private OrderViewModel model;
        public OrderUserControl()
        {
            InitializeComponent();
            model = new OrderViewModel();
            DataContext = model;
            model.ExchangeRates = new ExchangeRatesWebService().GetCurrencies();
        }


        private void OrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model.SelectedOrder = orderDataGrid.SelectedItem as Order;
            model.Invoices = model.GetInvoices();
            model.TotalPrice = model.GetTotalPrice();
        }

        //private void CurrencyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    model.SelectedCurrency = CurrencyComboBox.SelectedItem.ToString();
        //}
    }
}
