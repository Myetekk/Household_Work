using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works.Model.Load_info
{
    class Templates_edit
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public void Save_template(string[] template_info)
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $" INSERT INTO tasks (name, discription, time, points) VALUES ('{template_info[0]}', '{template_info[1]}', '{template_info[2]}', '{template_info[3]}'); ";
            command.ExecuteNonQuery();

            conn.Close();
        }





        public void Delete_template(string[] info)
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"DELETE FROM tasks WHERE name is '{info[0]}' ";
            command.ExecuteNonQuery();

            conn.Close();
        }
    }
}
