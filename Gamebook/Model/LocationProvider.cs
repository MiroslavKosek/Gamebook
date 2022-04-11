using Gamebook.Services;
using System.Linq;

namespace Gamebook.Model
{
    public class LocationProvider : ILocationProvider
    {
        public List<Location> Locations { get; set; } = new List<Location>
        {
            new Location("Home", "You are looking on your shelf, where the dragon egg must be."),//0
            new Location("Road", "You are on road."),//OW 1
            new Location("Nether", "You are in nether."),//2
            new Location("Mine", "You are not scared to enter. You have been here before."),//3
            new Location("Enemy", ""),//OW//4
            new Location("Village", "After long trip, you finally found village."),//5
            new Location("Stronghold", "You are finally here, you can finish my journey."),//6
            new Location("End", "What a lucky day today. You don't have to go to the Fortress in Nether."),//7
            new Location("Enemy", ""),//Nether//8
            new Location("Fortress", "You are in nether."),//9
            new Location("Road", "You are on road in Nether.")//Nether//10

        };

        public List<Connection> Connections { get; set; } = new List<Connection>
        {
            new Connection(0, 0),
            new Connection(0, 1, null, "Walk out from home"),//z domu na cetsu
            new Connection(1, 0,null, "Go back Home"),//z cesty domu
            new Connection(1, 2, null, "Go through nether portal"),//z cesty do portalu
            new Connection(2, 1, null, "Return to Over World"),//z portalu zpet na OW
            new Connection(1, 3, null, "Go to Mine"),// z cesty do dolu
            new Connection(3, 1, null, "Return to Road"),//z dolu na cestu
            new Connection(1, 4, null, "Continue on a Road"),//pokracovat v ceste a enemy
            new Connection(4, 5, null,"Go to Village"),//z cesty/enemy do vesnice
            new Connection(5, 1, null, "Go back on Road to the Home "),//vratit se zpet na ceste
            new Connection(5, 4, null, "Return to Road"),//z vesnice na cestu
            new Connection(4, 6, null, "Go to Stronghold"), // z cesty do strongholdu
            new Connection(6,4, null, "Go back on Road"),//z pet na cestu ze strongholdu
            new Connection(6, 7, null, "Go through Endportal"),//stronhgold skrz portal
            new Connection(2, 8, null,"Continue on Road"),//portal -enemy -  cesta nether
            new Connection(8, 10, null, "Go to Road"),//cesta v nether
            new Connection(10, 2, null, "Go back to Portal"),//cesta zpet k portalu
            new Connection(10, 9, null, "Go to the Fortress"),//z cesty do fortress
            new Connection(9, 10, null, "Return to Road in Nether"),//z fortress na cestu
            new Connection(6,10, null, "Return to The Nether"),//zpet do netheru ze strongholdu
            new Connection(10,6, null,"Go through Nether Portal to Stronghold")//nether do stronghold
        };

        public bool ExistsLocation (int id)
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
