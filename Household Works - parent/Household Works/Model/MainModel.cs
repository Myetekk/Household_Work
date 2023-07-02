﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works.Model
{
    class MainModel
    {
        // kids
        private Combobox_Info.Read_kids reading_kids = new Combobox_Info.Read_kids();
        public string[] read_kids(long ile)
        {
            string[] kids_names = new string[ile];
            kids_names = reading_kids.kids_to_combobox(ile);

            return kids_names;
        }
        public long count_kids()
        {
            long ile = reading_kids.count_kids();

            return ile;
        }





        // zadania
        private Combobox_Info.Read_tasks reading_tasks = new Combobox_Info.Read_tasks();
        public string[] read_tasks(long ile)
        {
            string[] tasks_names = new string[ile];
            tasks_names = reading_tasks.tasks_to_combobox(ile);

            return tasks_names;
        }
        public long count_tasks()
        {
            long ile = reading_tasks.count_tasks();

            return ile;
        }





        // hasło
        //





        // wczytanie zadania
        private Load_task loading_task = new Load_task();
        public string task_number = "odkurzanie";
        public string[] load_task()
        {
            string[] info_about_task = loading_task.task_info(task_number);

            return info_about_task;
        }

    }
}
