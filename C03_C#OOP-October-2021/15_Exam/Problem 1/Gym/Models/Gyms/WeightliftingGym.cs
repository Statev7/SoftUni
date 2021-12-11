namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WeightliftingGym : Gym
    {
        public WeightliftingGym(string name) 
            : base(name, 20)
        {
        }
    }
}
