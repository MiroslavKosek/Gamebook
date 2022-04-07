using Gamebook.Model;

namespace Gamebook.Services
{
    public interface ILocationProvider
    {
        bool ExistsLocation(int id); // existuje na tomto indexu místnost?
        Location GetLocation(int id); // získání dat místnosti na daném indexu
        List<Connection> GetConnectionsFrom(int id); // získání všech možnych cest z této místnosti
        List<Connection> GetConnectionsTo(int id); // získání všech možných cest do této místnosti, bude použito při kontrole regulérnosti cesty
        bool IsNavigationLegitimate(int from, int to); // test, zda byla cesta z jedné místnosti do druhé legitimní
                                                                        // rovnou přidejme i do kontroly i herní stav, možná by se mohl v pokročilejších implementacích hodit
    }
}
