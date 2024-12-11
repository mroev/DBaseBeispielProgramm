namespace ConMySqlTest
{
    public class Person
    {
        public string Nachname { get; }
        public string Vorname { get; }
        public string Ort { get; }

        public string Faktor { get; }

        public Person(string nachname, string vorname, string ort, string faktor)
        {
            Nachname = nachname;
            Vorname = vorname;
            Ort = ort;
            Faktor = faktor;
        }
    }
}
