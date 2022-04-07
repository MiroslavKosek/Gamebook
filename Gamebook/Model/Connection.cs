namespace Gamebook.Model
{
    public class Connection
    {
        public Connection(int from, int target)
        {
            From = from;
            Target = target;
        }

        public Connection(int from, int target, string targetSpecialPage, string description)
        {
            From = from;
            TargetSpecialPage = targetSpecialPage;
            Target = target;
            Description = description;
        }

        public int From { get; set; } //z jaké místnosti cesta vede
        public string TargetSpecialPage { get; set; } = null; //pokud toto nebude prázdné, budeme se přesměrovávat na speciální stránku
        public int Target { get; set; } //do jaké místnosti se budeme přesouvat, eventuálně vracet ze speciální stránky
        public string Description { get; set; } //popisek cesty pro zobrazení na stránce
    }
}
