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
        public Zombie Zombie { get; set; }
        public Skeleton Skeleton { get; set; }
        public Creeper Creeper { get; set; }
        public Dragon Dragon { get; set; }
        public string EnemyName { get; set; }
        public int EnemyHP { get; set; } = 0;
        public int EnemyDamage { get; set; }

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
        }

        public void GetPickaxe()
        {
            HasPickaxe = true;
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
            EnemyHP -= Damage;
        }

        public void HealRepair() //doplnit armor a zdraví
        {
            Armor = 100;
            HP = 100;
        }
    }
}
