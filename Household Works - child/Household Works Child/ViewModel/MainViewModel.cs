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
    using Household_Works_Child.Model.DataBase;
    using Model;
    using System.Collections.ObjectModel;

    //using Household_Works.ViewModel.BaseClass;
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool Btn_LogIn_Clicked = false;

        //loaders
        LoadKids kid_loader = new LoadKids();
        LoadTasks task_loader = new LoadTasks();
        LoadTotalPoints total_points_loader = new LoadTotalPoints();
        DeleteTask task_deleter = new DeleteTask();
        ModifyTotalPoints total_points_modifier = new ModifyTotalPoints();
        CheckDates date_checker = new CheckDates();

        long counter;



        //functions imported from model classes
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

        private ObservableCollection<FullTask> Load_Tasks(string kid_name)
        {
            ObservableCollection<FullTask> loaded_task_list = new ObservableCollection<FullTask>();
            loaded_task_list = task_loader.load_tasks(kid_name);

            foreach (var task in loaded_task_list)
            {
                if (!On_Time(task.Task_Commision, task.Task_Time))
                {
                    Delete_Task(task.Task_Name, Logging_Kid);
                    task.Task_Points = "-" + task.Task_Points;
                    Modify_Total_Points(Logging_Kid, task.Task_Points);
                }
            }

            loaded_task_list = task_loader.load_tasks(kid_name);

            return loaded_task_list;
        }

        private string Load_Total_Points(string kid_name)
        {
            return total_points_loader.load_total_points(kid_name);
        }

        private void Delete_Task(string task_name, string kid_name)
        {
            task_deleter.delete_task(task_name, kid_name);
            selected_task = null;
        }

        private void Modify_Total_Points(string kid_name, string points)
        {
            total_points_modifier.modify_total_points(kid_name, points);
        }

        private bool On_Time(string task_comm, string task_time)
        {//convert 5h into 05:00:00

            int ind = 0;
            int h = 0, m = 0;
            string temp;

            for (int i = 0; i < task_time.Length; i++)
            {
                if (task_time[i] == 'm')
                {
                    ind = i;
                    temp = task_time.Remove(ind);
                    //task_time = task_time.Substring(ind);
                    m = Int32.Parse(temp);

                    break;
                }
                else if (task_time[i] == 'h')
                {
                    ind = i;
                    temp = task_time.Remove(ind);
                    //task_time = task_time.Substring(ind);
                    h = Int32.Parse(temp);

                    break;
                }
            }
            
            DateTime temp2 = new DateTime(2023, 7, 6, h, m, 0);
            //string temp = task_time.Substring(ind);
            string temp3 = temp2.ToString();
            temp3 = temp3.Remove(0, 12);
            return date_checker.on_time(task_comm, temp3);
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
                if (selected_task == null)
                {
                    selected_task_name = string.Empty;
                    selected_task_points = string.Empty;
                    selected_task_commision = string.Empty;
                    selected_task_time = string.Empty;
                }
                else if (selected_task != null)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(nameof(selected_task)));
                        Selected_Task_Name = selected_task.Task_Name;
                        Selected_Task_Points = selected_task.Task_Points;
                        Selected_Task_Commision = selected_task.Task_Commision;
                        Selected_Task_Time = selected_task.Task_Time;
                        if (!On_Time(Selected_Task_Commision, Selected_Task_Time))
                        {
                            Delete_Task(Selected_Task_Name, Logging_Kid);
                            Selected_Task_Points = "-" + Selected_Task_Points;
                            Modify_Total_Points(Logging_Kid, Selected_Task_Points);
                        }
                    }
                }
            }
        }

        private string selected_task_name;
        public string Selected_Task_Name
        {
            get => selected_task_name;
            set 
            {
                selected_task_name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(selected_task_name)));
            } 
        }

        private string selected_task_points;
        public string Selected_Task_Points
        {
            get => selected_task_points;
            set
            {
                selected_task_points = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(selected_task_points)));
            }
        }

        private string selected_task_commision;
        public string Selected_Task_Commision
        {
            get => selected_task_commision;
            set
            {
                selected_task_commision = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(selected_task_commision)));
            }
        }

        private string selected_task_time;
        public string Selected_Task_Time
        {
            get => selected_task_time;
            set
            {
                selected_task_time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(selected_task_time)));
            }
        }



        private string total_points;
        public string Total_Points
        {
            get => total_points;
            set
            {
                total_points = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(total_points)));
            }
        }




        private ICommand btn_login;
        public ICommand Btn_LogIn
        {
            get => btn_login ?? (btn_login = new RelayCommand((p) =>
            {//execute -> load tasks if the kid is in the DB
                Kids_List = Load_Kids();
                foreach (var kid in Kids_List)
                {
                    if (Logging_Kid == kid.ToString())
                    {//the kid is in the DB
                        Btn_LogIn_Clicked = true;
                        Task_List = Load_Tasks(Logging_Kid);
                        Total_Points = Load_Total_Points(Logging_Kid);
                        
                        break;
                    }
                }

            }//canExecute -> if no one has logged in yet
            , p => !Btn_LogIn_Clicked

            ));
        }


        private ICommand btn_dowork;
        public ICommand Btn_DoWork
        {
            get => btn_dowork ?? (btn_dowork = new RelayCommand((p) =>
            {//execute -> delete task from table and put points into kid's total_points
                Total_Points = Load_Total_Points(Logging_Kid);

                int tempA = Convert.ToInt32(Total_Points);
                int tempB = Convert.ToInt32(Selected_Task_Points);
                int result = tempA + tempB;

                string resultS = result.ToString();

                Modify_Total_Points(Logging_Kid, resultS);

                //refresh total_points in view
                Total_Points = Load_Total_Points(Logging_Kid);
                
                Delete_Task(Selected_Task_Name, Logging_Kid);
                Task_List = Load_Tasks(Logging_Kid);
            }
            , p => Selected_Task != null
                
            ));
        }
    }
}
