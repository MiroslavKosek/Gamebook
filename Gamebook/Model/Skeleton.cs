using Gamebook.Services;

namespace Gamebook.Model
{
    public class Skeleton
    {
        public int HP { get; set; } = 10;
        public int Damage { get; set; } = 2;

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
