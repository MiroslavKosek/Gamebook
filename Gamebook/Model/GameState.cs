using Gamebook.Services;

namespace Gamebook.Model
{
    public class GameState
    {
        public int HP { get; set; } = 10; // počet životů postavy
        public int Armor { get; set; } = 0; // počet armoru postavy
        public int Damage { get; set; } = 1;
        public int Location { get; set; } // místnost, kde se postava nachází
    }
}
