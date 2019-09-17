using S3.Northwind.DataAccess;
using S3.Northwind.Entities;
using S3.Northwind.ValidationWebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3.Northwind.Gui.Desktop.ViewModels
{
    class OrderViewModel : INotifyPropertyChanged
    {
        private List<Order> orders;
        private Order selectedOrder;
        private List<Invoice> invoices;
        private decimal totalPrice;
        private string selectedCurrency;

        public List<Order> Orders
        {
            get
            {
                orders = new Repository().GetAllOrders().Where(o => o.ShippedDate == null).OrderBy(o => o.RequiredDate).ToList();
                return orders;
            }
            set { orders = value; }
        }

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public List<Invoice> Invoices
        {
            get { return invoices; }
            set
            {
                invoices = value;
                OnPropertyChanged(nameof(Invoices));
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public ExchangeRates ExchangeRates { get; set; }

        public string SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
            }
        }

        public List<string> Currencies
        {
            get
            {
                return GetCurrencies();
            }
        }
        public List<string> GetCurrencies()
        {
            ExchangeRates exchangeRates = new ExchangeRates();
            return ExchangeRates.Rates.GetType().GetProperties().Select(p => p.Name).ToList();
        }

        public decimal GetTotalPrice()
        {
            decimal price = 0;
            foreach (Invoice invoice in Invoices)
            {
                price += (decimal)(invoice.ExtendedPrice + invoice.Freight);
            }
            return price;
        }

        public List<Invoice> GetInvoices()
        {
            return new Repository().GetInvoices(SelectedOrder.OrderID);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
