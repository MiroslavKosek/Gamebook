namespace Gamebook.Model
{
    public class Creeper
    {
        public string Name { get; set; } = "Creeper";
        public int HP { get; set; } = 50;
        public int Damage { get; set; } = 100;

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
