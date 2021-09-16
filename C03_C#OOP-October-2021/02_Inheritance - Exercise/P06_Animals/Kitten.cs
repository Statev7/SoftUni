namespace Animals
{
    public class Kitten : Cat
    {
        private const string DEFUALT_GENDER = "Female";

        public Kitten(string name, int age) 
            : base(name, age, DEFUALT_GENDER)
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
