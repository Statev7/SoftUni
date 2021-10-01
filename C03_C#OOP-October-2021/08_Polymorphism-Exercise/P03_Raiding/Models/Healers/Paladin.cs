namespace Rading.Models.Healers
{
    public class Paladin : Healer
    {
        private const int POWER_VALUE = 100;

        public Paladin(string name) 
            : base(name)
        {
            this.Power = POWER_VALUE;
        }
    }
}
