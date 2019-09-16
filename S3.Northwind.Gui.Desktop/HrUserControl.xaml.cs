using S3.Northwind.DataAccess;
using S3.Northwind.Entities;
using S3.Northwind.Gui.Desktop.ViewModels;
using S3.Northwind.ValidationWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for HrUserControl.xaml
    /// </summary>
    public partial class HrUserControl : UserControl
    {
        private HrViewModel model;
        public HrUserControl()
        {
            InitializeComponent();
            model = new HrViewModel();
            DataContext = model;
            searchRegionComboBox.IsEnabled = false;
            model.SelectedEmployee = new Employee();
            datePickerBirthDate.DisplayDateEnd = DateTime.Today;
        }

        private void FillRegionComboBox(string country)
        {
            List<Employee> employees = new List<Employee>();
            employees = model.Employees.Where(em => em.Country == country).ToList();

            List<string> regions = new List<string>();
            foreach (Employee employee in employees)
                if (!(employee.Region is null))
                    regions.Add(employee.Region);


            if (regions.Count == 0)
                searchRegionComboBox.IsEnabled = false;

            else
            {
                searchRegionComboBox.IsEnabled = true;
                foreach (string region in regions.Distinct())
                    searchRegionComboBox.Items.Add(region);
            }
        }
        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model.SelectedEmployee = employeeDataGrid.SelectedItem as Employee;
            if (model.SelectedEmployee != null)
            {
                model.SelectedBoss = model.SelectedEmployee.Employee1;
                buttonUpdate.IsEnabled = true;
            }
            else
            {
                buttonUpdate.IsEnabled = false;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextBoxSearchName_TextChanged(object sender, TextChangedEventArgs e)
        {
            employeeDataGrid.ItemsSource = model.Employees.Where(em => (em.FirstName + " " + em.LastName).ToLower().Contains(textBoxSearchName.Text.ToLower()));
        }
        private void TextBoxSearchInitials_TextChanged(object sender, TextChangedEventArgs e)
        {
            employeeDataGrid.ItemsSource = model.Employees.Where(em => (em.Initials).ToLower().Contains(textBoxSearchInitials.Text.ToLower()));
        }
        private void SearchCountryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Employee> employees = model.Employees.Where(em => em.Country == searchCountryComboBox.SelectedValue.ToString()).ToList();
            employeeDataGrid.ItemsSource = employees;

            searchRegionComboBox.Items.Clear();
            FillRegionComboBox(searchCountryComboBox.SelectedValue.ToString());

        }
        private void SearchRegionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchRegionComboBox.SelectedValue != null)
            {
                List<Employee> employees = model.Employees.Where(em => em.Region == searchRegionComboBox.SelectedValue.ToString()).ToList();
                employeeDataGrid.ItemsSource = employees;
            }
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            model.Update();
            model.SelectedEmployee = new Employee();
            employeeDataGrid.SelectedItem = null;
            MessageBox.Show("Person opdateret!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            model.NewEmployee = new Employee()
            {
                FirstName = textBoxFirstname.Text,
                LastName = textBoxLastname.Text,
                Title = textBoxTitel.Text,
                TitleOfCourtesy = textBoxTitelOfCourtesy.Text,
                BirthDate = datePickerBirthDate.SelectedDate,
                HireDate = datePickerHireDate.SelectedDate,
                Address = textBoxAddress.Text,
                City = textBoxCity.Text,
                Region = textBoxRegion.Text,
                Country = textBoxCountry.Text,
                Extension = textBoxExtension.Text,
                Notes = textBoxNotes.Text,
                Initials = textBoxInitials.Text
            };

            PhoneNumberWebService phoneNumberWebService = new PhoneNumberWebService();
            if (!phoneNumberWebService.ValidatePhoneNumber(textBoxHomePhone.Text))
            {
                textBoxHomePhone.BorderBrush = Brushes.Red;
                MessageBox.Show("Telefonnummer er ugyldigt", "Fejl", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                model.NewEmployee.HomePhone = textBoxHomePhone.Text;
            }
            TextWebService textWebService = new TextWebService();
            var textResult = textWebService.CheckForProfanity(textBoxNotes.Text);
            if (textResult.containsProfanity)
            {
                MessageBox.Show("Noter indeholder bandeord", "Advarsel", MessageBoxButton.OK, MessageBoxImage.Warning);
                model.NewEmployee.Notes = textResult.returnText;
            }
            else
                model.NewEmployee.Notes = textResult.returnText;

            MessageBox.Show("Person Tilføjet!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            model.Insert();
        }
        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            model.SelectedEmployee = new Employee();
            buttonUpdate.IsEnabled = false;
        }

    }
}
