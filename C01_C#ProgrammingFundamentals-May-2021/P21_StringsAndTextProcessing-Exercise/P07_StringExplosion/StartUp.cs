namespace P07_StringExplosion
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string field = Console.ReadLine();
            int bomb = 0;
            for (int i = 0; i < field.Length; i++)
            {
                if (bomb > 0 && field[i] != '>')
                {
                    field = field.Remove(i, 1); 
                    bomb--; 
                    i--; 
                }
                else if (field[i] == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString()); 
                }
            }
            Console.WriteLine(field);
        }
    }
}
