using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works.Model
{
    class Edit_kids
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source= .\..\..\..\..\database.db; Version=3");
        SQLiteCommand command;

        public void Add_kid(string kid_name)
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $" CREATE TABLE '{kid_name}' ('id'    INTEGER NOT NULL, 'name'  TEXT, 'discription'   TEXT, 'time'  TEXT, 'points'    TEXT, PRIMARY KEY('id') ); ";
            command.ExecuteNonQuery();

            conn.Close();


            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $" INSERT INTO KIDS (name, points) VALUES ('{kid_name}', '0'); ";
            command.ExecuteNonQuery();

            conn.Close();
        }





        public void Delete_kid(string kid_name)
        {
            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"DROP TABLE '{kid_name}' ";
            command.ExecuteNonQuery();

            conn.Close();


            conn.Open();
            command = conn.CreateCommand();
            command.CommandText = $"DELETE FROM KIDS WHERE name is '{kid_name}' ";
            command.ExecuteNonQuery();

            conn.Close();
        }
    }
}
