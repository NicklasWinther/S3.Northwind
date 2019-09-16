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
    /// Interaction logic for StackedButtonNavigationUserControl.xaml
    /// </summary>
    public partial class StackedButtonNavigationUserControl : UserControl
    {
        MainWindow mainWindow;
        public StackedButtonNavigationUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            mainWindow.DetailUserControl.Content = new HrUserControl();
        }
    }
}
