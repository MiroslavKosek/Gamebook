using Gamebook.Services;
using Gamebook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gamebook.Pages
{
    public class StartModel : PageModel
    {
        private string KEY; //identifikátor session promìnné
        private SessionStorage<GameState> _ss;
        private ILocationProvider _lp;
        private readonly IHttpContextAccessor _hca; //HttpContextAccessor zpøístupní HttpContext

        private ISession _session => _hca.HttpContext.Session;
        private IConfiguration _conf;

        public StartModel(SessionStorage<GameState> ss, ILocationProvider lp, IHttpContextAccessor hca, IConfiguration config)
        {
            _ss = ss;
            _lp = lp;
            _hca = hca;
            _conf = config;
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

        [TempData]
        public string End { get; set; }

        [TempData]
        public string End_Description { get; set; }

        public void OnGet(int id)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            // TODO: kontroly legitimnosti pøesunu
            if (!_lp.IsNavigationLegitimate(State.Location, id))
            {
                End = "Are you trying to cheat?";
                End_Description = "Start over again to cool your head!";
                Response.Redirect("End");
            }
            State.Location = id;
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);
        }

        public IActionResult OnGetArmor(int id, bool armor, bool sword)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);

            if (!armor && !sword)
            {
                KEY = _conf["KEY"];
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
                KEY = _conf["KEY"];
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
                KEY = _conf["KEY"];
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
