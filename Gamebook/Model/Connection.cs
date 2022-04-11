namespace Gamebook.Model
{
    public class Connection
    {
        public Connection(int from, int target)
        {
            From = from;
            Target = target;
        }

        public Connection(int from, int target, string description)
        {
            From = from;
            Target = target;
            Description = description;
        }

        public int From { get; set; } //z jaké místnosti cesta vede
        public int Target { get; set; } //do jaké místnosti se budeme přesouvat, eventuálně vracet ze speciální stránky
        public string Description { get; set; } //popisek cesty pro zobrazení na stránce
    }
}
