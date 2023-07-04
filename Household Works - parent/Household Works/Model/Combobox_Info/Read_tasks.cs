using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works.Model.Combobox_Info
{
    class Read_tasks
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public long count_tasks()
        {
            long ile;

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT count(*) as ile FROM tasks";
            reader = command.ExecuteReader();
            reader.Read();
            ile = (long)reader["ile"];

            reader.Close();
            conn.Close();

            return ile;
        }

        public string[] tasks_to_combobox(long ile)
        {
            string[] tasks = new string[ile];
            int i = 0;

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT name FROM tasks";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                tasks[i] = (string)reader["name"];
                i++;
            }

            reader.Close();
            conn.Close();

            return tasks;
        }
    }
}
