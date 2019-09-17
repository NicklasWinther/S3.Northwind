using S3.Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3.Northwind.DataAccess
{
    public class Repository
    {
        NorthwindModel model = new NorthwindModel();

        /// <summary>
        /// Get all orders from DB
        /// </summary>
        /// <returns>Returns a list of orders</returns>
        public List<Order> GetAllOrders()
        {
            List<Order> orders = model.Orders.ToList();
            return orders;
        }

        /// <summary>
        /// Get all invoices for an order from DB
        /// </summary>
        /// <param name="orderId">Id of the requested invoice</param>
        /// <returns>Returns a list of invoices</returns>
        public List<Invoice> GetInvoices(int orderId)
        {
            List<Invoice> invoices = model.Invoices.Where(i => i.OrderID == orderId).ToList();
            return invoices;
        }

        /// <summary>
        /// Get all employees from DB
        /// </summary>
        /// <returns>Returns a list of employees</returns>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = model.Employees.ToList();
            return employees;
        }

        /// <summary>
        /// Updates an employee in DB
        /// </summary>
        /// <param name="employee">The employee to update</param>
        public void Update(Employee employee)
        {
            model.Employees.AddOrUpdate(employee);  
            model.SaveChanges();
        }

        /// <summary>
        /// Inserts an imployee to DB
        /// </summary>
        /// <param name="employee">The employee to add to DB</param>
        public void Insert(Employee employee)
        {
            model.Employees.Add(employee);
            model.SaveChanges();
        }
        
    }
}
