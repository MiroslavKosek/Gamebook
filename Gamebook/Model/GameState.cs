using Gamebook.Services;

namespace Gamebook.Model
{
    public class GameState
    {

        public int HP { get; set; } = 100; // počet životů postavy
        public int Armor { get; set; } = 0; // počet armoru postavy
        public int Damage { get; set; } = 1; // počet útočného poškození
        public bool HasArmor { get; set; } = false; // má vyrobený armor
        public bool HasSword { get; set; } = false; // má vyrobený sword
        public int Location { get; set; } // místnost, kde se postava nachází
        public int Diamonds { get; set; } = 0;
        public bool Shield { get; set; } = false;
        public bool HasPickaxe { get; set; } = false;
        public bool Bow { get; set; } = false;
        public Zombie Zombie { get; set; }
        public Skeleton Skeleton { get; set; }
        public Creeper Creeper { get; set; }
        public Dragon Dragon { get; set; }
        public Blaze Blaze { get; set; }
        public Wither_Skeleton Wither_Skeleton { get; set; }
        public Zombie_Pigman Zombie_Pigman { get; set; }
        public Villager Villager { get; set; }
        public EndCrystal EndCrystal { get; set; }
        public string EnemyName { get; set; }
        public int EnemyHP { get; set; } = 0;
        public int EnemyDamage { get; set; }
        public string VillagerName { get; set; }
        public string VillagerDialog { get; set; }
        public bool WinShield { get; set; } = false;
        public bool Chance { get; set; } = true;
        

        public void GetArmor() // nasadit armor
        {
            HasArmor = true;
            Armor = 100;
        }

        public void GetSword() // nasadit sword
        {
            HasSword = true;
            Damage = 10;
        }

        public void GetDiamond()
        {
            Diamonds += 1;
        }

        public void GetShield()
        {
            Shield = true;
            Chance = false;
            WinShield = true;
        }

        public void GetPickaxe()
        {
            HasPickaxe = true;
        }

        public void GetBow()
        {
            Bow = true;
        }

        public void GetZombie() //vytvořit zombie
        {
            Zombie = new Zombie();
            EnemyName = Zombie.Name;
            EnemyHP = Zombie.HP;
            EnemyDamage = Zombie.Damage;
        }


        public void GetSkeleton() //vytvořit skeletona
        {
            Skeleton = new Skeleton();
            EnemyName = Skeleton.Name;
            EnemyHP = Skeleton.HP;
            EnemyDamage = Skeleton.Damage;
        }

        public void GetCreeper() //vytvořit creepera
        {
            Creeper = new Creeper();
            EnemyName = Creeper.Name;
            EnemyHP = Creeper.HP;
            EnemyDamage = Creeper.Damage;
        }

        public void GetDragon() //vytvořit draka
        {
            Dragon = new Dragon();
            EnemyName = Dragon.Name;
            EnemyHP = Dragon.HP;
            EnemyDamage = Dragon.Damage;
        }

        public void GetBlaze() //vytvořit blaze
        {
            Blaze = new Blaze();
            EnemyName = Blaze.Name;
            EnemyHP = Blaze.HP;
            EnemyDamage = Blaze.Damage;
        }

        public void GetWitherSkeleton() //vytvořit wither skeletona
        {
            Wither_Skeleton = new Wither_Skeleton();
            EnemyName = Wither_Skeleton.Name;
            EnemyHP = Wither_Skeleton.HP;
            EnemyDamage = Wither_Skeleton.Damage;
        }

        public void GetZombiePigman() //vytvořit zombie pigmana
        {
            Zombie_Pigman = new Zombie_Pigman();
            EnemyName = Zombie_Pigman.Name;
            EnemyHP = Zombie_Pigman.HP;
            EnemyDamage = Zombie_Pigman.Damage;
        }

        public void GetVillager() //vytvořit villagera
        {
            Villager = new Villager();
            VillagerName = Villager.Name;
            VillagerDialog = Villager.Dialog;
        }
        public void GetEndCrystal() //vytvořit EndCrystal
        {
            EndCrystal = new EndCrystal();
            EnemyName = EndCrystal.Name;
            EnemyHP = EndCrystal.HP;
            EnemyDamage = EndCrystal.Damage;
        }

        public void GetAttacked() //dostat nakládačku
        {
            if (Armor == 0)
            {
                HP -= EnemyDamage;
            }
            else
            {
                Armor -= EnemyDamage;
            }

            if (EnemyName == "Creeper")
            {
                EnemyHP = 0;
            }
        }

        public void Attack() //zaútočit
        {
            if (Bow && EnemyName == "End Crystal")
            {
                EnemyHP -= 1;
            }
            else
            {
                EnemyHP -= Damage;
            }
        }

        public void HealRepair() //doplnit armor a zdraví
        {
            Armor = 100;
            HP = 100;
        }
    }
}
