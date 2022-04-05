namespace Gamebook.Model
{
    public class Dragon
    {
        public int HP { get; set; } = 100;
        public int Damage { get; set; } = 10;

        public void Attack(GameState gs)
        {
            if(gs.Armor > 0)
            {
                gs.Armor -= Damage;
            }
            else
            {
                gs.HP -= Damage;
            }
        }
    }
}
