namespace Rading.Models.Fighters
{
    public abstract class Figher : BaseHero
    {
        private const string FIGHERS_ABILITY_MESSAGE = "{0} - {1} hit for {2} damage";

        protected Figher(string name)
            : base(name)
        {
        }

        public override string CastAbility()
        {
            string message = string.Format(FIGHERS_ABILITY_MESSAGE, this.GetType().Name, this.Name, this.Power);

            return message;
        }
    }
}
