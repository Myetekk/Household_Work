using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works.Model
{
    class Load_task
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public string[] task_info(string task_number)
        {
            string[] result = new string[4];

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM tasks where name is '{task_number}'";
            reader = command.ExecuteReader();
            reader.Read();

            result[0] = (string)reader["name"];
            result[1] = (string)reader["discription"];
            result[2] = (string)reader["time"];
            result[3] = reader["points"].ToString();

            conn.Close();
            return result;
        }
    }
}
