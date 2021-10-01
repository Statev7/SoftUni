namespace Rading.Models.Fighters
{
    public class Warrior : Figher
    {
        private const int POWER_VALUE = 100;

        public Warrior(string name) 
            : base(name)
        {
            this.Power = POWER_VALUE;
        }
    }
}
