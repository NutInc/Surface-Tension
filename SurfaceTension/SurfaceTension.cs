namespace SurfaceTension
{
    using Exiled.API.Features;
    using Handlers;
    using ServerEvents = Exiled.Events.Handlers.Server;
    using WarheadEvents = Exiled.Events.Handlers.Warhead;

    public class SurfaceTension : Plugin<Config>
    {
        internal static SurfaceTension Instance;
        private readonly ServerHandlers _serverHandlers = new ServerHandlers();
        internal readonly WarheadHandlers WarheadHandlers = new WarheadHandlers();

        public override void OnEnabled()
        {
            Instance = this;
            ServerEvents.RoundEnded += _serverHandlers.OnRoundEnded;
            WarheadEvents.Detonated += WarheadHandlers.OnWarheadDetonation;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvents.RoundEnded -= _serverHandlers.OnRoundEnded;
            WarheadEvents.Detonated -= WarheadHandlers.OnWarheadDetonation;
            Instance = null;
        } 
    }
}