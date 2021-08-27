namespace P07_RawData
{
    using System;

    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            if (engineSpeed <= 0 || enginePower <= 0)
            {
                throw new ArgumentException($"Engine speed and a power cannot be negative numbers");
            }

            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed { get; }

        public int EnginePower { get; }
    }
}
