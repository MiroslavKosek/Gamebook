namespace Gamebook.Model
{
    public class Dragon
    {
        public string Name { get; set; } = "Dragon";
        public int HP { get; set; } = 100;
        public int Damage { get; set; } = 10;

        public void GetAttacked(GameState gs)
        {
            HP -= gs.Damage;
        }

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
