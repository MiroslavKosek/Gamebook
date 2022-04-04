namespace Gamebook.Model
{
    public class Connection
    {
        public int From { get; set; } //z jaké místnosti cesta vede
        public string TargetSpecialPage { get; set; } = null; //pokud toto nebude prázdné, budeme se přesměrovávat na speciální stránku
        public int Target { get; set; } //do jaké místnosti se budeme přesouvat, eventuálně vracet ze speciální stránky
        public string Description { get; set; } //popisek cesty pro zobrazení na stránce
    }
}
