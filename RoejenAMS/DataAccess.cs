using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace RoejenAMS
{
    class DataAccess
    {
        public string SelectQuery()
        {
            string query = "";
            using (var con = new SqliteConnection("Data Source=RoejenAMS.db"))
            {
                con.Open();

                var command = con.CreateCommand();
                command.CommandText = @"
                                    SELECT name
                                    FROM user
                                    WHERE id = $id
                                      ";
                command.Parameters.AddWithValue("$id", 1);

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);

                        string helloGet = ($"Hello, {name}!");
                        query = helloGet;
                    }
            }

            return query;
        }

        public void CreateTable()
        {
            using (var con = new SqliteConnection("Data Source=RoejenAMS.db"))
            {
                con.Open();
                string commandText =  @"DROP TABLE IF EXISTS test; CREATE TABLE test (fizz TEXT, buzz TEXT)";
                SqliteCommand command = new SqliteCommand(commandText, con);
                command.ExecuteNonQuery();
            }
        }

        public void InsertIntoTab(string entryOne, string entryTwo)
        {
            using (var con = new SqliteConnection("Data Source=RoejenAMS.db"))
            {
                con.Open();

                string commandText = @"INSERT INTO test (fizz, buzz) VALUES ('"+entryOne+"','"+entryTwo+"')";
                SqliteCommand command = new SqliteCommand(commandText, con);
                command.ExecuteNonQuery();
            }
        }

    }
}    

