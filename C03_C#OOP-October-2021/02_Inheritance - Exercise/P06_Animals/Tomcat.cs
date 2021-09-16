namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DEFUALT_GENDER = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, DEFUALT_GENDER)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
