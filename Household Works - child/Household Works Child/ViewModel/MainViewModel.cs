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

        private bool Btn_LogIn_Clicked = false;


        
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
                kids_list.Add(new ItemsList() {Kid_Name = kid} );
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

        private ObservableCollection<FullTask> task_list = new ObservableCollection<FullTask>();
        public ObservableCollection<FullTask> Task_List
        {
            get => task_list;
            set
            {
                task_list = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Task_List"));
            }
        }

        private FullTask selected_task;
        public FullTask Selected_Task
        {
            get => selected_task;
            set
            {
                selected_task = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(selected_task)));
                    Selected_Task_Name = selected_task.Task_Name;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(selected_task_name)));
                }
            }
        }

        private string selected_task_name;
        public string Selected_Task_Name
        {
            get => selected_task_name;
            set => selected_task_name = value;
        }


        LoadTasks task_loader = new LoadTasks();
        private ObservableCollection<FullTask> Load_Tasks(string kid_name)
        {
            //załadować load_tasks tak żeby dało się odpalić w MainVM
            ObservableCollection<FullTask> loaded_task_list = new ObservableCollection<FullTask>();
            loaded_task_list = task_loader.load_tasks(kid_name);

            return loaded_task_list;
        }




        //private string task_name;
        //public string Task_Name
        //{
        //    get => task_name;
        //    set
        //    {
        //        task_name = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_name)));
        //    }
        //}

        //private string task_desc;
        //public string Task_Desc
        //{
        //    get => task_desc;
        //    set
        //    {
        //        task_desc = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_desc)));
        //    }
        //}

        //private string task_time;
        //public string Task_Time
        //{
        //    get => task_time;
        //    set
        //    {
        //        task_time = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_time)));
        //    }
        //}

        //private string task_points;
        //public string Task_Points
        //{
        //    get => task_points;
        //    set
        //    {
        //        task_points = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_points)));
        //    }
        //}



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
                        Btn_LogIn_Clicked = true;
                        Task_List = Load_Tasks(logging_kid);

                        
                        break;
                    }
                }

            }//canExecute -> zawsze true
            , p => !Btn_LogIn_Clicked

            ));
        }


        //private ICommand btn_dowork;
        //public ICommand Btn_DoWork
        //{
        //    get => btn_dowork ?? (btn_dowork = new RelayCommand((p) =>
        //    {

        //    }
        //    , 
        //        )
        //}
    }
}
