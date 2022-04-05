using Gamebook.Services;

namespace Gamebook.Model
{
    public class LocationProvider : ILocationProvider
    {
        public List<string> Locations { get; set; } = new List<string>() { "Home", "Road", "Portal to Nether", "Nether", "Stronghold", "End" };

        public bool ExistsLocation(int id)
        {
            if (Locations[id] != "" || Locations[id] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Connection> GetConnectionsFrom(int id)
        {
            throw new NotImplementedException();
        }

        public List<Connection> GetConnectionsTo(int id)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsNavigationLegitimate(int from, int to, GameState state)
        {
            throw new NotImplementedException();
        }

    }
}
