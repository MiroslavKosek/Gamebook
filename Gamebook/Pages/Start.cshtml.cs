using Gamebook.Services;
using Gamebook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamebook.Pages
{
    public class StartModel : PageModel
    {
        private const string KEY = "Player"; //identifikátor session promìnné
        private SessionStorage<GameState> _ss;
        private ILocationProvider _lp;
        private readonly IHttpContextAccessor _hca; //HttpContextAccessor zpøístupní HttpContext

        private ISession _session => _hca.HttpContext.Session;

        public StartModel(SessionStorage<GameState> ss, ILocationProvider lp, IHttpContextAccessor hca)
        {
            _ss = ss;
            _lp = lp;
            _hca = hca;
        }

        public Location Location { get; set; }
        public List<Connection> Targets { get; set; }
        public GameState State { get; set; }

        public int HP { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public bool HasArmor { get; set; }
        public bool HasSword { get; set; }
        public int ID { get; set; } = 0;

        public void OnGet(/*Room id*/)
        {
            
            State = _ss.LoadOrCreate(KEY);
            /*
            // TODO: kontroly legitimnosti pøesunu
            State.Location = id;*/
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            _ss.Save(KEY, State);
            /*
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionFrom(id);*/
        }

        public IActionResult OnGetArmor(bool armor, bool sword)
        {
            State = _ss.LoadOrCreate(KEY);
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            _ss.Save(KEY, State);

            if (!armor && !sword)
            {
                State = _ss.LoadOrCreate(KEY);
                State.GetArmor();
                State.GetSword();
                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                Damage = State.Damage;
                _ss.Save(KEY, State);
                return Page();
            }

            if (!armor)
            {
                State = _ss.LoadOrCreate(KEY);
                State.GetArmor();
                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                Damage = State.Damage;
                _ss.Save(KEY, State);
                return Page();
            }

            if (!sword)
            {
                State = _ss.LoadOrCreate(KEY);
                State.GetSword();
                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                Damage = State.Damage;
                _ss.Save(KEY, State);
                return Page();
            }

            return Page();
        }
    }
}
