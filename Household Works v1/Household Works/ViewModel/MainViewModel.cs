using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Household_Works.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Deactivated;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private MainViewModel _selectedViewModel;
        public MainViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                //MainWindow.Content = new UserControl();


                //MainWindow window = new MainWindow();
                //window.Show();


                Deactivated?.Invoke(this, new PropertyChangedEventArgs(value.ToString()));

                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }



        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            //MainWindow.Content = new UserControl();
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
