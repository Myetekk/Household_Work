using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works_Child.Model
{
    class LoadTasks
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public long count_tasks(string kid_name)
        {
            long counter = 0;
            conn.Open();

            command = conn.CreateCommand();
            command.CommandText = $"SELECT count(*) FROM {kid_name}";
            reader = command.ExecuteReader();

            reader.Read();
            counter = (long)reader["count(*)"];
            reader.Close();
            conn.Close();

            return counter;
        }

        public ObservableCollection<FullTask> load_tasks(string kid_name)
        {
            ObservableCollection<FullTask> task_list = new ObservableCollection<FullTask>();

            conn.Open();

            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM {kid_name}";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                task_list.Add(new FullTask()
                {
                    Task_Name = (string)reader["name"],
                    Task_Desc = (string)reader["discription"],
                    Task_Time = (string)reader["time"],
                    Task_Points = (string)reader["points"],
                    Task_Commision = (string)reader["time_of_commision"]
                });
            }

            reader.Close();
            conn.Close();

            return task_list;
        }
    }
}
