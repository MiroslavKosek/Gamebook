using Gamebook.Services;
using Gamebook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamebook.Pages
{
    public class StartModel : PageModel
    {
        /*private const string KEY = "AMAZINGADVENTURE";
        
        private ISessionStorage<GameState> _ss;
        private ILocationProvider _lp;*/
        
        public StartModel(/*ISessionStorage<GameState> ss, ILocationProvider lp*/)
        {
            /*_ss = ss;
            _lp = lp;*/
        }
        /*
        public Location Location { get; set; }
        public List<Connection> Targets { get; set; }
        public GameState State { get; set; }*/

        public void OnGet(/*Room id*/)
        {
            /*State = _ss.LoadOrCreate(KEY);
            // TODO: kontroly legitimnosti pøesunu
            State.Location = id;
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);*/
        }
    }
}
