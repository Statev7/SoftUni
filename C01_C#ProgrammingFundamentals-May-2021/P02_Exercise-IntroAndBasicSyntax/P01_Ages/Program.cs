namespace P01_Ages
{
    using System;

    public class Program
    {
        public static void Main()
        {
            const byte BABY_MIN_AGE_VALUE = 0;
            const byte BABY_MAX_AGE_VALUE = 2;
            const byte CHILD_MIN_AGE_VALUE = 3;
            const byte CHILD_MAX_AGE_VALUE = 13;
            const byte TEENAGER_MIN_AGE_VALUE = 14;
            const byte TEENAGER_MAX_AGE_VALUE = 19;
            const byte ADULT_MIX_AGE_VALUE = 20;
            const byte ADULT_MAX_AGE_VALUE = 65;

            byte age = byte.Parse(Console.ReadLine());

            string result = "elder";

            if (age >= BABY_MIN_AGE_VALUE && age <= BABY_MAX_AGE_VALUE)
            {
                result = "baby";
            }
            else if (age >= CHILD_MIN_AGE_VALUE && age <= CHILD_MAX_AGE_VALUE)
            {
                result = "child";
            }
            else if (age >= TEENAGER_MIN_AGE_VALUE && age <= TEENAGER_MAX_AGE_VALUE)
            {
                result = "teenager";
            }
            else if(age >= ADULT_MIX_AGE_VALUE && age <= ADULT_MAX_AGE_VALUE)
            {
                result = "adult";
            }

            Console.WriteLine(result);
        }
    }
}
