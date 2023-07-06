using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works.Model.Load_info
{
    class Load_task
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;


        public string[] task_current_info(string kid_number)
        {
            string[] task_current = new string[7];

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM '{kid_number}' ";
            reader = command.ExecuteReader();

            task_current[0] = kid_number;
            task_current[6] = "Zadania dla: " + kid_number;

            int i = 0;
            while (reader.Read())
            {
                task_current[1] += (string)reader["name"] + "\n";
                task_current[2] += (string)reader["discription"] + "\n";
                task_current[3] += (string)reader["time"] + "\n";
                task_current[4] += (string)reader["points"] + "\n";
                task_current[5] += (string)reader["time_of_commision"] + "\n";
                i++;
            }

            reader.Close();
            conn.Close();

            return task_current;
        }





        public string[] task_new_info(string task_number)
        {
            string[] task_new = new string[4];

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM tasks where name is '{task_number}'";
            reader = command.ExecuteReader();
            reader.Read();

            task_new[0] = (string)reader["name"];
            task_new[1] = (string)reader["discription"];
            task_new[2] = (string)reader["time"];
            task_new[3] = reader["points"].ToString();

            reader.Close();
            conn.Close();

            return task_new;
        }
    }
}
