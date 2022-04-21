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
        public string EnemyName { get; set; }
        public int EnemyHP { get; set; } = 0;
        public int EnemyDamage { get; set; }
        public string VillagerName { get; set; }
        public string VillagerDialog { get; set; }
        public bool WinShield { get; set; } = false;
        public bool Chance { get; set; } = true;
        public bool Bow { get; set; } = false;

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

            if (State.HP == 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
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
            WinShield = State.WinShield;
            Chance = State.Chance;
            Bow = State.Bow;

            if (ID == 4)
            {
                switch (RNG)
                {
                    case 0:
                        State.GetZombie();
                        EnemyName = State.EnemyName;
                        EnemyHP = State.EnemyHP;
                        EnemyDamage = State.EnemyDamage;
                        break;
                    case 1:
                        State.GetSkeleton();
                        EnemyName = State.EnemyName;
                        EnemyHP = State.EnemyHP;
                        EnemyDamage = State.EnemyDamage;
                        break;
                    default:
                        State.GetCreeper();
                        EnemyName = State.EnemyName;
                        EnemyHP = State.EnemyHP;
                        EnemyDamage = State.EnemyDamage;
                        break;
                }
            }

            if (ID == 8)
            {
                State.GetZombiePigman();
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
            }

            if (ID == 9)
            {
                switch (RNG)
                {
                    case 0:
                        State.GetWitherSkeleton();
                        EnemyName = State.EnemyName;
                        EnemyHP = State.EnemyHP;
                        EnemyDamage = State.EnemyDamage;
                        break;
                    case 1:
                        State.GetBlaze();
                        EnemyName = State.EnemyName;
                        EnemyHP = State.EnemyHP;
                        EnemyDamage = State.EnemyDamage;
                        break;
                    default:
                        State.GetWitherSkeleton();
                        EnemyName = State.EnemyName;
                        EnemyHP = State.EnemyHP;
                        EnemyDamage = State.EnemyDamage;
                        break;
                }
            }

            if (ID == 12 || ID == 15)
            {
                State.GetVillager();
                VillagerName = State.VillagerName;
                VillagerDialog = State.VillagerDialog;
                if (ID == 15)
                {
                    State.VillagerDialog = "Do you need a bow?";
                    VillagerDialog = State.VillagerDialog;
                }
            }

            if (ID == 14)
            {
                State.GetEndCrystal();
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
            }

            if (ID == 14 && EnemyHP == 0)
            {
                State.GetDragon();
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
            }

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

            if (State.HP == 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }

            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;
            Bow = State.Bow;

            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);

            if (!armor && !sword)
            {
                KEY = _conf["KEY"];
                State = _ss.LoadOrCreate(KEY);
                State.GetArmor();
                State.GetSword();

                if (State.HP == 0)
                {
                    End = "You Died!";
                    End_Description = "Start over again.";
                    Response.Redirect("End");
                }

                State.Diamonds = 0;
                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                Damage = State.Damage;
                Diamonds = State.Diamonds;
                HasPickaxe = State.HasPickaxe;
                Shield = State.Shield;
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
                Bow = State.Bow;

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

            if (State.HP == 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }

            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;
            Bow = State.Bow;

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
                Damage = State.Damage;
                Diamonds = State.Diamonds;
                HasPickaxe = State.HasPickaxe;
                Shield = State.Shield;
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
                Bow = State.Bow;

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

            if (State.HP == 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }

            Diamonds = diamonds;
            RNG = _random.Next(3);
            switch (RNG)
            {
                case 0:
                    if(State.Diamonds + 1 <= 26)
                    {
                        State.GetDiamond();
                    }
                    break;
                case 1:
                    if (State.Diamonds + 2 <= 26)
                    {
                        State.GetDiamond();
                        State.GetDiamond();
                    }   
                    break;
                default:
                    if (State.Diamonds + 3 <= 26)
                    {
                        State.GetDiamond();
                        State.GetDiamond();
                        State.GetDiamond();
                    }
                    break;
            }
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;
            Bow = State.Bow;

            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);
            return Page(); 
        }

        public IActionResult OnGetAttack(int id)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);

            if (State.HP <= 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }

            Shield = State.Shield;

            State.Attack();

            RNG = _random.Next(3);

            if (Shield)
            {
                if (RNG != 0)
                {
                    State.GetAttacked();

                    if (State.HP <= 0)
                    {
                        End = "You Died!";
                        End_Description = "Start over again.";
                        Response.Redirect("End");
                    }
                }
            }
            if (!Shield)
            {
                State.GetAttacked();
                if (State.HP <= 0)
                {
                    End = "You Died!";
                    End_Description = "Start over again.";
                    Response.Redirect("End");
                }
            }

            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;

            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Bow = State.Bow;

            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);
            return Page();
        }

        public IActionResult OnGetBowAttack(int id)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);

            if (State.HP <= 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }

            Shield = State.Shield;
            RNG = _random.Next(4);

            if (RNG == 0)
            {
                State.Attack();
            }

            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;

            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Bow = State.Bow;

            if (EnemyHP == 0)
            {
                State.GetDragon();
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
            }

            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);
            return Page();
        }

        public IActionResult OnGetFinish()
        {
            End = "You Won!";
            End_Description = "Congratulations, you got your coveted Dragon Egg!";
            return RedirectToPage("End");
        }

        public IActionResult OnGetHealRepair(int id)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;

            if (State.HP == 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }
            State.HealRepair();
            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;
            Bow = State.Bow;

            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);

            return Page();
        }

        public IActionResult OnGetGamble(int id, bool chance, bool win)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;

            if (State.HP == 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }

            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;
            VillagerName = State.VillagerName;
            Bow = State.Bow;

            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);

            if (chance && !win)
            {
                KEY = _conf["KEY"];
                State = _ss.LoadOrCreate(KEY);

                RNG = _random.Next(3);
                if (RNG != 2)
                {
                    State.GetShield();
                    Chance = State.Chance;
                    WinShield = State.WinShield;
                }
                else
                {
                    State.Chance = false;
                    Chance = State.Chance;
                    WinShield = State.WinShield;
                }

                if (State.HP == 0)
                {
                    End = "You Died!";
                    End_Description = "Start over again.";
                    Response.Redirect("End");
                }

                Diamonds = State.Diamonds;
                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                Damage = State.Damage;
                Diamonds = State.Diamonds;
                HasPickaxe = State.HasPickaxe;
                Shield = State.Shield;
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
                VillagerName = State.VillagerName;
                Bow = State.Bow;

                _ss.Save(KEY, State);

                return Page();
            }

            return Page();
        }

        public IActionResult OnGetBow(int id, bool bow)
        {
            KEY = _conf["KEY"];
            ID = id;
            State = _ss.LoadOrCreate(KEY);
            State.Location = id;

            if (State.HP == 0)
            {
                End = "You Died!";
                End_Description = "Start over again.";
                Response.Redirect("End");
            }

            HP = State.HP;
            Armor = State.Armor;
            Damage = State.Damage;
            Diamonds = State.Diamonds;
            HasArmor = State.HasArmor;
            HasSword = State.HasSword;
            HasPickaxe = State.HasPickaxe;
            Shield = State.Shield;
            EnemyName = State.EnemyName;
            EnemyHP = State.EnemyHP;
            EnemyDamage = State.EnemyDamage;
            VillagerName = State.VillagerName;
            Bow = State.Bow;

            _ss.Save(KEY, State);
            Location = _lp.GetLocation(id);
            Targets = _lp.GetConnectionsFrom(id);

            if (!bow)
            {
                KEY = _conf["KEY"];
                State = _ss.LoadOrCreate(KEY);
                State.GetBow();

                HasArmor = State.HasArmor;
                HasSword = State.HasSword;
                HP = State.HP;
                Armor = State.Armor;
                Damage = State.Damage;
                Diamonds = State.Diamonds;
                HasPickaxe = State.HasPickaxe;
                Shield = State.Shield;
                EnemyName = State.EnemyName;
                EnemyHP = State.EnemyHP;
                EnemyDamage = State.EnemyDamage;
                VillagerName = State.VillagerName;
                Bow = State.Bow;

                _ss.Save(KEY, State);
                return Page();
            }

            return Page();
        }
    }
}
