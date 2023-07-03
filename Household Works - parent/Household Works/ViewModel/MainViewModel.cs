using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Household_Works.ViewModel
{
    using Household_Works.Model;
    using System.Windows;

    class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Model.MainModel GetInfo = new Model.MainModel();



        public static bool isRun_loged = true;


        


        private ICommand log_in;
        public ICommand Log_in
        {
            get
            {
                return log_in ?? (log_in = new BaseClass.RelayCommand((p) => {

                    if (GetInfo.Correct_password(Password_check) == true)
                    {
                        load_kids();
                        load_tasks();
                        Info_new = clear_info_new();

                        isRun_loged = false;
                    }

                }, p => isRun_loged));
            }
        }


        


        private ICommand commision;
        public ICommand Commision
        {
            get
            {
                return commision ?? (commision = new BaseClass.RelayCommand((p) => {
    
                    if (GetInfo.Field_contains_text(Info_new) == false)
                        MessageBox.Show("uzupełnij wszystkie pola");
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            XD += Info_new[i];
                        }
                    }

                }, p => !isRun_loged));
            }
        }

        
        private string xd;
        public string XD
        {
            get => xd;

            set
            {
                xd = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(xd)));
            }
        }








        private string password_check;
        public string Password_check
        {
            get => password_check;

            set
            {
                password_check = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password_check)));
            }
        }





        private string[] info_new;
        public string[] Info_new
        {
            get { return info_new; }
            private set
            {
                info_new = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(info_new)));
            }
        }





        private string[] info_current;
        public string[] Info_current
        {
            get { return info_current; }
            private set
            {
                info_current = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(info_current)));
            }
        }





        private string[] clear_info_new()
        {
            string[] result = { " ", " ", " ", " " };
            return result;
        }










        public string[] kids_in_combobox;
        private ObservableCollection<Items_list> kids = new ObservableCollection<Items_list>();
        public ObservableCollection<Items_list> Kids
        {
            get { return kids; }
            set { kids = value; }
        }
        private void load_kids()
        {
            long ile = GetInfo.Count_kids();
            kids_in_combobox = new string[ile];
            string[] kids = GetInfo.Read_kids(ile);

            for (int i = 0; i < ile; i++)
            {
                kids_in_combobox[i] = kids[i];
                Kids.Add(new Items_list() { Name = kids[i] });
            }
        }



        private Items_list selected_kids = new Items_list();
        public Items_list Selected_kids
        {
            get { return selected_kids; }
            set
            {
                selected_kids = value;
                if (value != null)
                {
                    GetInfo.kid_name = value.ToString();
                    Info_current = GetInfo.Load_task_current();
                }
            }
        }





        public string[] tasks_in_combobox;
        private ObservableCollection<Items_list> tasks = new ObservableCollection<Items_list>();
        public ObservableCollection<Items_list> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }
        private void load_tasks()
        {
            long ile = GetInfo.Count_tasks();
            tasks_in_combobox = new string[ile];
            string[] tasks = GetInfo.Read_tasks(ile);

            for (int i = 0; i < ile; i++)
            {
                tasks_in_combobox[i] = tasks[i];
                Tasks.Add(new Items_list() { Name = tasks[i] });
            }
        }



        private Items_list selected_task = new Items_list();
        public Items_list Selected_task
        {
            get { return selected_task; }
            set
            {
                selected_task = value;
                if (value != null)
                {
                    GetInfo.task_new_number = value.ToString();
                    Info_new = GetInfo.Load_task_new();
                }
            }
        }












    }
}
