namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGym : Gym
    {
        public BoxingGym(string name) 
            : base(name, 15)
        {
        }
    }
}
