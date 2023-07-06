using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works_Child.Model
{
    class LoadTotalPoints
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public string load_total_points(string kid_name)
        {
            string total_points;

            conn.Open();

            command = conn.CreateCommand();
            command.CommandText = $"SELECT points FROM KIDS WHERE name like \"{kid_name}\" ";
            reader = command.ExecuteReader();

            reader.Read();

            total_points = (string)reader["points"];

            reader.Close();
            conn.Close();

            return total_points;
        }
    }
}
