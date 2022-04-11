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
        private Random _random;

        private ISession _session => _hca.HttpContext.Session;
        private IConfiguration _conf;

        public StartModel(SessionStorage<GameState> ss, ILocationProvider lp, IHttpContextAccessor hca, IConfiguration config)
        {
            _ss = ss;
            _lp = lp;
            _hca = hca;
            _conf = config;
            _random = new Random();
        }

        public Location Location { get; set; }
        public List<Connection> Targets { get; set; }
        public GameState State { get; set; }

        public int HP { get; set; }
        public int Armor { get; set; }
        public int Damage { get; set; }
        public bool HasArmor { get; set; }
        public bool HasSword { get; set; }
        public int Diamonds { get; set; }
        public bool Shield { get; set; }
        public bool HasPickaxe { get; set; }
        public int RNG { get; set; }

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
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            RNG = _random.Next(3);
            Shield = State.Shield;
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);
            Console.WriteLine(RNG);
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
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            RNG = _random.Next(3);
            Shield = State.Shield;
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);

            if (!armor && !sword)
            {
                KEY = _conf["KEY"];
                State = _ss.LoadOrCreate(KEY);
                State.GetArmor();
                State.GetSword();
                State.Diamonds = 0;
                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                RNG = _random.Next(3);
                Damage = State.Damage;
                Diamonds = State.Diamonds;
                HasPickaxe = State.HasPickaxe;
                Shield = State.Shield;
                _ss.Save(KEY, State);
                return Page();
            }

            return Page();
        }

        public IActionResult OnGetPickaxe(int id, bool pickaxe)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            RNG = _random.Next(3);
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);

            if (!pickaxe)
            {
                KEY = _conf["KEY"];
                State = _ss.LoadOrCreate(KEY);
                State.GetPickaxe();
                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                RNG = _random.Next(3);
                Damage = State.Damage;
                Diamonds = State.Diamonds;
                HasPickaxe = State.HasPickaxe;
                Shield = State.Shield;
                _ss.Save(KEY, State);
                return Page();
            }

            return Page();
        }

        public IActionResult OnGetDiamonds(int id, int diamonds)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;
            Diamonds = diamonds;
            State.GetDiamond();
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            RNG = _random.Next(3);
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);
            return Page(); 
        }
    }
}
