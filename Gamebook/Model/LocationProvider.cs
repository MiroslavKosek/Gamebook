using Gamebook.Services;

namespace Gamebook.Model
{
    public class LocationProvider : ILocationProvider
    {
        public List<Location> Locations { get; set; } = new List<Location>
        {
            new Location("Home", "You are in home"),
            new Location("Road", "You are on road"),
            new Location("Nether", "You are in nether")
        };

        public bool ExistsLocation(int id)
        {
            /*if (Locations[id] != "" || Locations[id] != null)
            {
                return true;
            }
            else
            {
                return false;
            }*/
            throw new NotImplementedException();
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
            return Locations[id];
        }

        public bool IsNavigationLegitimate(int from, int to, GameState state)
        {
            throw new NotImplementedException();
        }

    }
}
