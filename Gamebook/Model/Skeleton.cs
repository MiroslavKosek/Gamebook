using Gamebook.Services;

namespace Gamebook.Model
{
    public class Skeleton
    {
        public string Name { get; set; } = "Skeleton";
        public int HP { get; set; } = 50;
        public int Damage { get; set; } = 10;

        public void Attack(GameState gs)
        {
            if (gs.Armor > 0)
            {
                gs.Armor -= Damage;
                HP = 0;
            }
            else
            {
                gs.HP -= Damage;
                HP = 0;
            }
        }
    }
}
