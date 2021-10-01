namespace Rading.Models.Fighters
{
    public class Rogue : Figher
    {
        private const int POWER_VALUE = 80;

        public Rogue(string name) 
            : base(name)
        {
            this.Power = POWER_VALUE;
        }
    }
}
