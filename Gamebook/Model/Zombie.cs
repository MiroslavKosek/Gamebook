namespace Gamebook.Model
{
    public class Zombie
    {
        public string Name { get; set; } = "Zombie";
        public int HP { get; set; } = 50;
        public int Damage { get; set; } = 10;

        public void GetAttacked(GameState gs)
        {
            HP -= gs.Damage;
        }

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
