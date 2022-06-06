using Gamebook.Services;
using System.Linq;

namespace Gamebook.Model
{
    public class LocationProvider : ILocationProvider
    {
        public List<Location> Locations { get; set; } = new List<Location>
        {
            new Location("Home", "You are looking on your shelf, where the dragon egg must be."),//0  ///*
            new Location("Road", "You went to a crossroads. it is a beautiful day."),//OW 1  ///*
            new Location("Nether", "Welcome to hell buddy."),//2 ///*
            new Location("Mine", "You are not scared to enter. You have been here before."),//3 ///*
            new Location("Encounter", "Kill It, before it kills you"),//OW//4 ///*
            new Location("Village", "After long trip, you finally found a Village."),//5 ///*
            new Location("Stronghold", "You are finally here, you can finish your journey."),//6 ///*
            new Location("End portal", "What a lucky day today. You don't have to go to the Fortress in Nether."),//7 ////*
            new Location("Encounter", "Kill It, before it kills you"),//Nether//8 ///*
            new Location("Fortress", "I'm surprised how easy you are to get here."),//9///*
            new Location("Road", "You are on road in Nether."),//Nether//10
            new Location("Nether Portal", "You've seen it many times, but it's still fascinating."),//11 ///*
            new Location("Village house", "You found a villager. You can try to trade with him."),//12///*
            new Location("Nether Portal to the Stronghold", "Portal to the Stronghold, let's go."),//13 
            new Location("End"," Welcome in End."),//14 ///*
            new Location("Blacksmith", "Try to ask him, if he has some bow for you.") //15
        };

        public List<Connection> Connections { get; set; } = new List<Connection>
        {
            new Connection(0, 0),
            new Connection(0, 1, "Road"),//z domu na cetsu
            new Connection(11, 2, "Nether"),//z cesty do portalu
            new Connection(1, 3, "Mine"),// z cesty do dolu
            new Connection(1, 4, "Road"),//pokracovat v ceste a enemy
            new Connection(1, 11, "Nether portal"),//z cesty do portalu
            new Connection(4, 5, "Village"),//z cesty/enemy do vesnice
            new Connection(5, 12, "House"),//dum ve versnici,
            new Connection(5, 15, "Blacksmith"),
            new Connection(15, 5, "Village"),
            new Connection(12, 5,"Village"),
            new Connection(4, 6, "Stronghold"), // z cesty do strongholdu
            new Connection(6, 7, "End portal"),//stronhgold skrz portal
            new Connection(2, 8, "Continue on Road"),//portal -enemy -  cesta nether
            new Connection(8, 10, "Road"),//cesta v nether
            new Connection(10, 13, "Portal to the Stronghold"),//cesta k portalu v netheru smer stronghold
            new Connection(10, 9, "Fortress"),//z cesty do fortress
            new Connection(13, 6, "Stronghold"),//nether do strongholdu
            new Connection(7, 14, "End portal"),// weeee
            new Connection(6, 4, "Road"),//z pet na cestu ze strongholdu
            new Connection(10, 2, "Nether"),//cesta zpet k portalu
            new Connection(9, 10,"Road"), //ze strongholdu na cestu
            new Connection(6, 13, "Nether"), //ze strongholdu do netheru
            new Connection(13, 10, "Road"),//portal cesta nether
            new Connection(5, 1, "Road"),//vratit se zpet na ceste
            new Connection(1, 0, "Home"),//z cesty domu
            new Connection(11, 1, "Return to Road"),//od portalu zpet na cestu
            new Connection(2, 11,"Over World"),
            new Connection(3, 1, "Road"),//z dolu na cestu
            new Connection(7, 6, "Stronghold corridors"),//zpet do cest ve strongholdu
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
            if (id > 15)
            {
                return Locations[0];
            }
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
