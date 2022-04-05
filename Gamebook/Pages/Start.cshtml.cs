using Gamebook.Services;
using Gamebook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamebook.Pages
{
    public class StartModel : PageModel
    {   
        private ISessionStorage<GameState> _ss;
        private ILocationProvider _lp;
        private GameState _game;
        
        public StartModel(ISessionStorage<GameState> ss, ILocationProvider lp)
        {
            _ss = ss;
            _lp = lp;
            _game = new GameState();
        }

        public int HP { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public int ID { get; set; } = 0;

        public void OnGet()
        {
            _game.Armor = 10;
            HP = _game.HP;
            Armor = _game.Armor;
            Damage = _game.Damage;
        }
    }
}
