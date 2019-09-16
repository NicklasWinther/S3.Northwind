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

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = model.Employees.ToList();
            return employees;
        }

        public void Update(Employee employee)
        {
            model.Employees.AddOrUpdate(employee);  
            model.SaveChanges();
        }
        public void Insert(Employee employee)
        {
            model.Employees.Add(employee);
            model.SaveChanges();
        }
        
    }
}
