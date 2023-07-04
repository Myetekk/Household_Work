using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Household_Works_Child.ViewModel
{
    using Household_Works.ViewModel.BaseClass;
    using Model;
    using System.Collections.ObjectModel;

    //using Household_Works.ViewModel.BaseClass;
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        LoadKids kid_loader = new LoadKids();
        //Model.MainModel model = new Model.MainModel();
        long counter;
        private ObservableCollection<ItemsList> Load_Kids()
        {
            counter = kid_loader.count_kids();
            ObservableCollection<ItemsList> kids_list = new ObservableCollection<ItemsList> ();
            string[] kids_list_string = new string[counter];
            kids_list_string = kid_loader.load_kids(counter);

            foreach (var kid in kids_list_string)
            {
                kids_list.Add(new ItemsList() { Name = kid} );
            }

            return kids_list;
        }

        private string logging_kid;
        public string Logging_Kid
        {
            get => logging_kid;
            set
            {
                logging_kid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(logging_kid)));
            }
        }
        
        private ObservableCollection<ItemsList> kids_list = new ObservableCollection<ItemsList>();
        public ObservableCollection<ItemsList> Kids_List 
        {
            get => kids_list;
            set
            {
                kids_list = value;
            }
        }


        private ICommand btn_login;
        public ICommand Btn_LogIn
        {
            get => btn_login ?? (btn_login = new RelayCommand((p) =>
            {//execute -> załadowania tasków jeśli dzieciak jest w bazie danych
                kids_list = Load_Kids();
                foreach (var kid in kids_list)
                {
                    Console.WriteLine(logging_kid);

                    if (logging_kid == kid.ToString())
                    {
                        logging_kid += "jest dzieć";

                    }
                }
                Console.WriteLine("nie ma dziecia");

            }//canExecute -> zawsze true
            , p => true

            ));
        }
    }
}
