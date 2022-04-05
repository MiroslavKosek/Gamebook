namespace Gamebook.Model
{
    public class Creeper
    {
        public int HP { get; set; } = 10;
        public int Damage { get; set; } = 10;

        public void Attack(GameState gs)
        {
            gs.HP -= Damage;
            HP = 0;
        }
    }
}
