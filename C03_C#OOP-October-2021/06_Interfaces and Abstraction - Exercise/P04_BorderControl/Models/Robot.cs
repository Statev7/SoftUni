namespace BorderControl.Models
{
    using BorderControl.Models.Interfaces;

    public class Robot : ICreatures
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
