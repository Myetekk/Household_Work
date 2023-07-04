using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Household_Works.Model
{
    class MainModel
    {
        // kids
        private Combobox_Info.Read_kids reading_kids = new Combobox_Info.Read_kids();
        public string[] Read_kids(long ile)
        {
            string[] kids_names = new string[ile];
            kids_names = reading_kids.kids_to_combobox(ile);

            return kids_names;
        }
        public long Count_kids()
        {
            long ile = reading_kids.count_kids();

            return ile;
        }





        // tasks for current kid
        private Combobox_Info.Read_kids reading_kid_tasks = new Combobox_Info.Read_kids();
        public string kid_task_name = "";
        public string[] Read_kid_tasks(string kid_name, long ile)
        {
            string[] kid_task_names = new string[ile];
            kid_task_names = reading_kid_tasks.kid_tasks_to_combobox(kid_name, ile);

            return kid_task_names;
        }
        public long Count_kid_tasks(string kid_name)
        {
            long ile = reading_kid_tasks.count_kid_tasks(kid_name);

            return ile;
        }










        // delete task for current kid
        public void Delete_kid_task()
        {
            reading_kid_tasks.Delete_task_from_kid(kid_task_name, kid_name);
        }





        // insert task for current kid
        public void Insert_kid_task(string[] task_info)
        {
            reading_kid_tasks.Insert_task_for_kid(task_info, kid_name);
        }









        // tasks
        private Combobox_Info.Read_tasks reading_tasks = new Combobox_Info.Read_tasks();
        public string[] Read_tasks(long ile)
        {
            string[] tasks_names = new string[ile];
            tasks_names = reading_tasks.tasks_to_combobox(ile);

            return tasks_names;
        }
        public long Count_tasks()
        {
            long ile = reading_tasks.count_tasks();

            return ile;
        }





        // load task new
        private Load_info.Load_task loading_task_new = new Load_info.Load_task();
        public string task_new_number = "odkurzanie";
        public string[] Load_task_new()
        {
            string[] info_about_task_new = loading_task_new.task_new_info(task_new_number);

            return info_about_task_new;
        }





        // load task current
        private Load_info.Load_task loading_task_current = new Load_info.Load_task();
        public string kid_name = "Marek";
        public string[] Load_task_current()
        {
            string[] info_about_task_current = loading_task_current.task_current_info(kid_name);

            return info_about_task_current;
        }










        // check if password is correct
        private Model.Check_password check_Password = new Model.Check_password();
        public bool Correct_password(string given_password)
        {
            if (given_password == check_Password.correct_password())
            {
                return true;
            }
            MessageBox.Show("Nieprawidłowe hasło");
            return false;
        }





        // check if text is not white space or null
        public bool Field_contains_text(string[] text)
        {
            for (int i = 0; i < 4; i++)
            {
                if (string.IsNullOrEmpty(text[i]) || string.IsNullOrWhiteSpace(text[i]))
                {
                    return false;
                }
            }
            
            return true;
        }





        

    }
}
