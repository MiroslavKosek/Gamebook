﻿using Gamebook.Services;

namespace Gamebook.Model
{
    public class GameState
    {

        public int HP { get; set; } = 10; // počet životů postavy
        public int Armor { get; set; } = 0; // počet armoru postavy
        public int Damage { get; set; } = 1; // počet útočného poškození
        public bool HasArmor { get; set; } = false; // má vyrobený armor
        public bool HasSword { get; set; } = false; // má vyrobený sword
        public int Location { get; set; } // místnost, kde se postava nachází

        public void GetArmor()
        {
            HasArmor = true;
            Armor = 100;
        }

        public void GetSword()
        {
            HasSword = true;
            Damage = 5;
        }
    }
}
