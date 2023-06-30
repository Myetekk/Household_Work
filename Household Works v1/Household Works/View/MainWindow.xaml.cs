using Household_Works.View;
using Household_Works.ViewModel;
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

namespace Household_Works
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void Parent_Click(object sender, RoutedEventArgs e)
        {
            //var newWindow = new ParentWindow();
            ////newWindow.ShowDialog();

            //newWindow.Content = null;
            //newWindow.Content = new UserControl();

            main_window.Visibility = (Visibility)1;
        }
    }
}
