namespace Gamebook.Model
{
    public class Zombie
    {
        public int HP { get; set; } = 10;
        public int Damage { get; set; } = 2;

        public void Attack(GameState gs)
        {
            gs.HP -= Damage;
        }
    }
}
