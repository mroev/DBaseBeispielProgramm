using System;
using System.Data;

namespace ConMySqlTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string connectionString =
                "SERVER=localhost;" +
                "DATABASE=test;" +
                "UID=root;" +
                "PASSWORD=;";

            DBase db = new DBase(connectionString);

            Person[] personen = new Person[]
            {
                new Person("Albrecht", "Alfons", "Rheine"),
                new Person("Brinker", "Bernhard", "Rheine"),
                new Person("Cencic", "Celine", "Neuenkirchen"),
                new Person("Dürer", "Dennis", "Rheine"),
                new Person("Elbhagen", "Erich", "Wettringen"),
                new Person("Fischer", "Frida", "Elte"),
            };

            // Daten einfügen
            Console.WriteLine("Neue Datensätze einfügen...");
            foreach (var person in personen)
            {
                string columns = "Nachname, Vorname, Ort";
                string values = $"'{person.Nachname}', '{person.Vorname}', '{person.Ort}'";
                db.InsertData("Personen", columns, values);
            }

            // Daten auslesen
            Console.WriteLine("\nVorhandene Daten:");
            Console.WriteLine("Nachname\tVorname\t\tOrt");
            Console.WriteLine(new string('-', 50));
            DataTable dataTable = db.ReadData("Personen");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["Nachname"]}\t{row["Vorname"]}\t\t{row["Ort"]}");
            }

            Console.WriteLine("\nProgramm beendet!");
            Console.ReadKey();
        }
    }
}
