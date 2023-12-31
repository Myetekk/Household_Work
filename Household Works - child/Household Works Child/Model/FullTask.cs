﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works_Child.Model
{
    public class FullTask
    {

        private string task_name;
        public string Task_Name
        {
            get => task_name;
            set
            {
                task_name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_name)));
            }
        }

        private string task_desc;
        public string Task_Desc
        {
            get => task_desc;
            set
            {
                task_desc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_desc)));
            }
        }

        private string task_time;
        public string Task_Time
        {
            get => task_time;
            set
            {
                task_time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_time)));
            }
        }

        private string task_points;
        public string Task_Points
        {
            get => task_points;
            set
            {
                task_points = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_points)));
            }
        }

        private string task_commision;
        public string Task_Commision
        {
            get => task_commision;
            set
            {
                task_commision = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(task_commision)));
            }
        }

        public virtual event PropertyChangedEventHandler PropertyChanged;
        public virtual void NotifyPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                PropertyChanged(this, new PropertyChangedEventArgs("HasError"));
            }
        }
    }
}
