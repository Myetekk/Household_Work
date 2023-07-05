using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace Household_Works_Child.Model
{
    class LoadKids
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteDataReader reader;
        SQLiteCommand command;

        public long count_kids()
        {
            long counter = 0;
            conn.Open();

            command = conn.CreateCommand();
            command.CommandText = $"SELECT max(id) FROM kids";
            reader = command.ExecuteReader();

            reader.Read();
            counter = (long)reader["max(id)"];
            reader.Close();
            conn.Close();

            return counter;
        }
        

        public string[] load_kids(long counter)
        {
            string[] kids_list = new string[counter];

            conn.Open();


            command = conn.CreateCommand();
            command.CommandText = $"SELECT * FROM kids";
            reader = command.ExecuteReader();

            int i = 0;
            while (reader.Read())
            {
                kids_list[i++] = (string)reader["name"];
            }

            reader.Close();
            conn.Close();

            return kids_list;
        }
    }
}
