using Gamebook.Services;
using System.Linq;

namespace Gamebook.Model
{
    public class LocationProvider : ILocationProvider
    {
        public List<Location> Locations { get; set; } = new List<Location>
        {
            new Location("Home", "You are looking on your shelf, where the dragon egg must be."),
            new Location("Road", "You are on road"),
            new Location("Nether", "You are in nether")
        };

        public List<Connection> Connections { get; set; } = new List<Connection>
        {
            new Connection(0, 0),
            new Connection(0, 1, null, "Walk out from home"),
            new Connection(1, 2, null, "Go through nether portal")
        };

        public bool ExistsLocation(int id)
        {
            if (Locations[id] != null)
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
            List<Connection> connections = new List<Connection>();
            foreach (var item in Connections)
            {
                if (item.From == id)
                {
                    connections.Add(item);
                }
            }
            return connections;
        }

        public List<Connection> GetConnectionsTo(int id)
        {
            List<Connection> connections = new List<Connection>();
            foreach (var item in Connections)
            {
                if (item.Target == id)
                {
                    connections.Add(item);
                }
            }
            return connections;
        }

        public Location GetLocation(int id)
        {
            return Locations[id];
        }

        public bool IsNavigationLegitimate(int from, int to)
        {
            if (Connections.Exists(x => x.From == from && x.Target == to))
            {
                return true;
            }
            return false;
        }

    }
}
