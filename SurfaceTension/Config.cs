namespace SurfaceTension
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Time, in seconds, to wait after the nuke is detonated before damaging players. Any value below 1 will start damage instantly.")]
        public int DelayTime { get; private set; } = 90;

        [Description("Amount of damage to deal to players")]
        public int DamageAmount { get; private set; } = 1;

        [Description("Interval in seconds to damage players")]
        public float DamageInterval { get; private set; } = 1;

        [Description("True reads the damage amount as a percentage, false as a HP value")]
        public bool DamageAsPercentage { get; private set; } = true;

        [Description("The hint sent to players when they are damaged")]
        public string DamageMessage { get; private set; } = "You are being damaged by radiation!";

        [Description("Whether or not a message should be sent by cassie when surface tension starts")]
        public bool EnableCassie { get; set; } = true;

        [Description("The message sent by cassie when surface tension starts")]
        public string CassieMessage { get; set; } = "Alpha Warhead Radiation Warning";

        [Description("Whether or not to send a broadcast to all players in the server when surface tension starts.")]
        public bool EnableBroadcast { get; set; } = false;

        [Description("The message sent in the broadcast to all players")]
        public string BroadcastMessage { get; set; } = "Radiation warning, leave the facility immediately!";

        [Description("How long the broadcast should last")]
        public ushort BroadcastDuration { get; set; } = 6;

        [Description("Whether or not to log surface tension starting in the console.")]
        public bool ConsoleLogs { get; set; } = true;
    }
}