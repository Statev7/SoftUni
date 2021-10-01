namespace Rading.Models.Healers
{
    public class Druid : Healer
    {
        private const int POWER_VALUE = 80;

        public Druid(string name) 
            : base(name)
        {
            this.Power = POWER_VALUE;
        }
    }
}
