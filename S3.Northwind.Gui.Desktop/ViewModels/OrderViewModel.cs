using S3.Northwind.DataAccess;
using S3.Northwind.Entities;
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

        public List<Order> Orders
        {
            get
            {
                orders = new Repository().GetAllOrders();
                return orders.Where(o => o.ShippedDate == null).OrderBy(o => o.RequiredDate).ToList(); ;
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

        public List<Invoice> Invoices { get => invoices; set { invoices = value;
                OnPropertyChanged(nameof(Invoices));
            }
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
