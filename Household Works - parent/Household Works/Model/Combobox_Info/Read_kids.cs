using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works.Model.Combobox_Info
{
    class Read_kids
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public long count_kids()
        {
            long ile;

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT count(*) as ile FROM kids";
            reader = command.ExecuteReader();
            reader.Read();
            ile = (long)reader["ile"];
            conn.Close();

            return ile;
        }

        public string[] kids_to_combobox(long ile)
        {
            string[] kids = new string[ile];
            int i = 0;

            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"SELECT name FROM kids";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                kids[i] = (string)reader["name"];
                i++;
            }
            conn.Close();

            return kids;
        }
    }
}
