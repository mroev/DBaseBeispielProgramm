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
                new Person("Albrecht", "Alfons", "Rheine", "5"),
                new Person("Brinker", "Bernhard", "Rheine", "4"),
                new Person("Cencic", "Celine", "Neuenkirchen", "6"),
                new Person("Dürer", "Dennis", "Rheine", "8"),
                new Person("Elbhagen", "Erich", "Wettringen", "9"),
                new Person("Fischer", "Frida", "Elte", "1"),
            };

            // Daten einfügen
            Console.WriteLine("Neue Datensätze einfügen...");
            foreach (var person in personen)
            {
                string columns = "Nachname, Vorname, Ort, Faktor";
                string values = $"'{person.Nachname}', '{person.Vorname}', '{person.Ort}', '{person.Faktor}'";
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
