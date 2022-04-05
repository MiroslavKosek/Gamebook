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
        private GameState _game = new GameState();
        
        public StartModel(ISessionStorage<GameState> ss, ILocationProvider lp)
        {
            _ss = ss;
            _lp = lp;
        }

        public int HP { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public bool HasArmor { get; set; }
        public bool HasSword { get; set; }
        public int ID { get; set; } = 0;

        public void OnGet()
        {
            /*_game.GetArmor();
            _game.GetSword();*/
            HP = _game.HP;
            Armor = _game.Armor;
            Damage = _game.Damage;
            HasArmor = _game.HasArmor;
            HasSword = _game.HasSword;
        }

        public IActionResult OnGetArmor(bool armor, bool sword)
        {
            HP = _game.HP;
            Armor = _game.Armor;
            Damage = _game.Damage;
            HasArmor = _game.HasArmor;
            HasSword = _game.HasSword;

            if (!armor && !sword)
            {
                _game.GetArmor();
                _game.GetSword();
                HasArmor = _game.HasArmor;
                HasSword = _game.HasSword;
                HP = _game.HP;
                Armor = _game.Armor;
                Damage = _game.Damage;
                return Page();
            }

            if (!armor)
            {
                _game.GetArmor();
                HasArmor = _game.HasArmor;
                HasSword = _game.HasSword;
                HP = _game.HP;
                Armor = _game.Armor;
                Damage = _game.Damage;
                return Page();
            }

            if (!sword)
            {
                _game.GetSword();
                HasArmor = _game.HasArmor;
                HasSword = _game.HasSword;
                HP = _game.HP;
                Armor = _game.Armor;
                Damage = _game.Damage;
                return Page();
            }

            return Page();
        }
    }
}
