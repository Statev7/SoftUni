namespace P03_Songs.Models
{
    public class Song
    {
        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }

        public string TypeList { get; private set; }

        public string Name { get; private set; }

        public string Time { get; private set; }

        public override string ToString()
        {
            string result = $"{this.Name}";

            return result.ToString();
        }
    }
}
