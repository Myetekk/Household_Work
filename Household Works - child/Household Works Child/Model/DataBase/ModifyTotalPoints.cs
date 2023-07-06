using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works_Child.Model.DataBase
{
    class ModifyTotalPoints
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public void modify_total_points(string kid_name, string points)
        {
            conn.Open();

            command = conn.CreateCommand();
            command.CommandText = $"UPDATE KIDS SET points = {points} WHERE name like \"{kid_name}\"";
            reader = command.ExecuteReader();

            reader.Read();
            reader.Close();
            conn.Close();
        }
    }
}
