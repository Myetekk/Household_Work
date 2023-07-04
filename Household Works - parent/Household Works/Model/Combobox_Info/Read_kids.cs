using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Household_Works.Model.Combobox_Info
{
    class Read_kids
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public string[] kids_to_combobox(long ile)
        {
            string[] kids = new string[ile];
            int i = 0;

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT name FROM sqlite_master WHERE type = 'table' AND name not like 'admin' AND name not like 'kids' AND name not like 'tasks' ";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                kids[i] = (string)reader["name"];
                i++;
            }

            reader.Close();
            conn.Close();

            return kids;
        }

        public long count_kids()
        {
            long ile;

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT count(*) as ile FROM sqlite_master WHERE name not like 'admin' AND name not like 'kids' AND name not like 'tasks' ";
            reader = command.ExecuteReader();
            reader.Read();

            ile = (long)reader["ile"];

            reader.Close();
            conn.Close();

            return ile;
        }










        public string[] kid_tasks_to_combobox(string kid_name, long ile)
        {
            string[] kid_tasks = new string[ile];

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT name FROM {kid_name} ";
            reader = command.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                kid_tasks[i] += (string)reader["name"];
                i++;
            }

            reader.Close();
            conn.Close();

            return kid_tasks;
        }
        public long count_kid_tasks(string kid_name)
        {
            long ile;

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT count(*) as ile FROM {kid_name} ";
            reader = command.ExecuteReader();
            reader.Read();

            ile = (long)reader["ile"];

            reader.Close();
            conn.Close();

            return ile;
        }










        public void Delete_task_from_kid(string task_name, string kid_name)
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"DELETE FROM {kid_name} WHERE name is '{task_name}' ";
            command.ExecuteNonQuery();

            conn.Close();
        }





        public void Insert_task_for_kid(string[] task_info, string kid_name)
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $" INSERT INTO {kid_name} (name, discription, time, points) VALUES ('{task_info[0]}', '{task_info[1]}', '{task_info[2]}', '{task_info[3]}'); ";
            command.ExecuteNonQuery();

            conn.Close();
        }


    }
}
