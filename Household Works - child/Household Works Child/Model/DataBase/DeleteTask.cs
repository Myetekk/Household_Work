using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works_Child.Model.DataBase
{
    class DeleteTask
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public void delete_task(string task_name, string kid_name)
        {
            conn.Open();

            command = conn.CreateCommand();
            command.CommandText = $"DELETE FROM {kid_name} WHERE name like \"{task_name}\"";
            reader = command.ExecuteReader();

            reader.Read();
            reader.Close();
            conn.Close();
        }
    }
}
