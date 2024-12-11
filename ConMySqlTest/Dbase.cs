using System;
using System.Data;
using MySqlConnector;

namespace ConMySqlTest
{
    public class DBase
    {
        private readonly string _connectionString;

        public DBase(string connectionString)
        {
            _connectionString = connectionString;
            InsertData("daten", "Nachname, Vorname, Ort", "'Albrecht', 'Alfons', 'Rheine'");
        }

        public void InsertData(string table, string columns, string values)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable ReadData(string table)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // SQL-Query für SELECT
                string query = $"SELECT * FROM {table}";

                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // DataTable erstellen und füllen
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }
    }
}
