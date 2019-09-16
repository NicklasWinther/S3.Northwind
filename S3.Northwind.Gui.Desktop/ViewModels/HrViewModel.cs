using S3.Northwind.DataAccess;
using S3.Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3.Northwind.Gui.Desktop.ViewModels
{
    class HrViewModel : INotifyPropertyChanged
    {
        private Employee selectedEmployee;
        private List<Employee> allEmployees;
        private Employee selectedBoss;
        private Employee newEmployee;
        private ObservableCollection<Employee> bosses;

        public ObservableCollection<Employee> Bosses
        {
            get
            {
                bosses = new ObservableCollection<Employee>();
                foreach (Employee employee in Employees)
                {
                    if (employee.Employees1.Count > 0)
                    {
                        bosses.Add(employee);
                    }
                }

                return bosses;
            }
            set
            {
                bosses = value;
                OnPropertyChanged(nameof(Bosses));
            }
        }
        public Employee SelectedBoss
        {
            get
            {
                return selectedBoss;
            }
            set
            {
                selectedBoss = value;
                OnPropertyChanged(nameof(SelectedBoss));
            }
        }
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                OnPropertyChanged(nameof(SelectedBoss));
            }
        }
        public Employee NewEmployee
        {
            get => newEmployee;
            set
            {
                newEmployee = value;
                OnPropertyChanged(nameof(NewEmployee));
            }
        }
        public List<Employee> Employees
        {
            get
            {
                allEmployees = new Repository().GetAllEmployees();
                return allEmployees;
            }
            set
            {
                allEmployees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        public List<string> Countries
        {
            get
            {
                List<string> countries = new List<string>();
                foreach (Employee employee in Employees)
                {
                    countries.Add(employee.Country);
                }
                return countries.Distinct().ToList();
            }
        }


        public void Update()
        {
            new Repository().Update(SelectedEmployee);
        }

        public void Insert()
        {
            new Repository().Insert(NewEmployee);
            OnPropertyChanged(nameof(Employees));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
