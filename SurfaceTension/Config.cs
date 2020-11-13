namespace SurfaceTension
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description(
            "Time, in seconds, to wait after the nuke is detonated before damaging players. Any value below 1 will start damage instantly.")]
        public int DelayTime { get; private set; } = 90;

        [Description("Amount of damage to deal to players")]
        public int DamageAmount { get; private set; } = 1;

        [Description("Interval in seconds to damage players")]
        public float DamageInterval { get; private set; } = 1;

        [Description("True reads the damage amount as a percentage, false as a HP value")]
        public bool DamageAsPercentage { get; private set; } = true;
    }
}