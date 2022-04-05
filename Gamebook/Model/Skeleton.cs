using Gamebook.Services;

namespace Gamebook.Model
{
    public class Skeleton
    {
        public int HP { get; set; } = 10;
        public int Damage { get; set; } = 2;

        public void Attack(GameState gs)
        {
            gs.HP -= Damage;
        }
    }
}
