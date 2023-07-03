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

            conn.Close();
            return task_new;
        }

        public string[] task_current_info(string kid_number)
        {
            string[] task_current = new string[5];

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT tasks FROM kids where name is '{kid_number}'";
            reader = command.ExecuteReader();
            reader.Read();

            task_current[0] = kid_number;


            string task_number_whole = (string)reader["tasks"];
            for (int i = 0; i < task_number_whole.Length / 2; i++)
            {
                string task_number = task_number_whole.Substring(2 * i, 1);
                if (task_number != "0")
                {
                    string[] task_temp = task_small_info(task_number);

                    task_current[1] += task_temp[0] + "\n";
                    task_current[2] += task_temp[1] + "\n";
                    task_current[3] += task_temp[2] + "\n";
                    task_current[4] += task_temp[3] + "\n";
                }
                else
                {
                    task_current[1] = "brak zadań";
                    task_current[2] = "";
                    task_current[3] = "";
                    task_current[4] = "";
                }
            }


            conn.Close();
            return task_current;
        }

        private string[] task_small_info(string task_number)
        {
            string[] small_info = new string[4];

            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM tasks where id is '{task_number}'";
            reader = command.ExecuteReader();
            reader.Read();

            small_info[0] = (string)reader["name"];
            small_info[1] = (string)reader["discription"];
            small_info[2] = (string)reader["time"];
            small_info[3] = reader["points"].ToString();


            return small_info;
        }
    }
}
