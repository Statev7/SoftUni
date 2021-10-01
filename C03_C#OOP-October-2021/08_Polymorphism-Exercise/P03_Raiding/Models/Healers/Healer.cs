namespace Rading.Models.Healers
{
    public abstract class Healer : BaseHero
    {
        private const string HEALER_ABILITY_MESSAGE = "{0} - {1} healed for {2}";

        protected Healer(string name) 
            : base(name)
        {
        }

        public override string CastAbility()
        {
            string message = string.Format(HEALER_ABILITY_MESSAGE, this.GetType().Name, this.Name, this.Power);

            return message;
        }
    }
}
