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
            new Location("Village", "After long trip, you finally found a village."),//5
            new Location("Stronghold", "You are finally here, you can finish your journey."),//6
            new Location("End", "What a lucky day today. You don't have to go to the Fortress in Nether."),//7
            new Location("Enemy", ""),//Nether//8
            new Location("Fortress", "Let's get some blaze rods."),//9
            new Location("Road", "You are on road in Nether."),//Nether//10
            new Location("Nether Portal","Your on your way to the nether"),//11
            new Location("Village house","You enter ti house in Village"),//12
            new Location("Nether Portal"," Portal to the strongholed"),//13
            new Location("END"," Welcome to the End"),//14
        };

        public List<Connection> Connections { get; set; } = new List<Connection>
        {
            new Connection(0, 0),
            new Connection(0, 1, "Walk out from home"),//z domu na cetsu
            new Connection(1, 0, "Go back Home"),//z cesty domu
            new Connection(1, 11, "Go through Nether portal"),//z cesty do portalu
            new Connection(11, 1, "Return to Over World"),//z portalu zpet na OW
            new Connection(11, 2, "Go through Nether portal"),//z cesty do portalu
            new Connection(2,11,"Return to over World "),
            new Connection(1, 3, "Go to Mine"),// z cesty do dolu
            new Connection(3, 1, "Return to Road"),//z dolu na cestu
            new Connection(1, 4, "Continue on a Road"),//pokracovat v ceste a enemy
            new Connection(4, 5, "Go to Village"),//z cesty/enemy do vesnice
            new Connection(5,12,"Enter to the house"),//dum ve versnici,
            new Connection(12,5,"Go outside"),
            new Connection(5, 1, "Go back on Road to the Home "),//vratit se zpet na ceste
            new Connection(4,6,"Go to the stronghold"),
            new Connection(4, 6, "Go to Stronghold"), // z cesty do strongholdu
            new Connection(6, 4, "Go back on Road"),//z pet na cestu ze strongholdu
            new Connection(7, 16, "Return to the Stronghold corridors"),//
            new Connection(6, 7, "Go through End portal"),//stronhgold skrz portal
            new Connection(2, 8, "Continue on Road"),//portal -enemy -  cesta nether
            new Connection(8, 10, "Go to Road"),//cesta v nether
            new Connection(10, 2, "Go back to Portal"),//cesta zpet k portalu
            new Connection(10, 9, "Go to the Fortress"),//z cesty do fortress
            new Connection(9,10,"Return to Road in Nether"),
            new Connection(6,13, "z fortres na cetsu"),
            new Connection(13,6, "Return Nether Portal to Stronghold"),//nether do strongholdu
            new Connection(10,13, "Go to portal"),//cesta k portalu v  netheru smer stronghold
            new Connection(13,10,"Return to Road"),//portal cesta nether
            new Connection(7,14,"Go to the End"),

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
