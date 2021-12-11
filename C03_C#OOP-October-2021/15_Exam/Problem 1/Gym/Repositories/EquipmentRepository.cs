namespace Gym.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> equipment;

        public EquipmentRepository()
        {
            this.equipment = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)this.equipment;

        public void Add(IEquipment model)
        {
            this.equipment.Add(model);
        }

        public bool Remove(IEquipment model)
        {
            return this.equipment.Remove(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.equipment.FirstOrDefault(e => e.GetType().Name == type);
        }
    }
}
