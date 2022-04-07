namespace Gamebook.Model
{
    public class Location
    {
        public Location(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; } //nadpis místnosti
        public string Description { get; set; } //dlouhý popis
    }
}
