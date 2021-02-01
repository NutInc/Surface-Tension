namespace SurfaceTension
{
    using Exiled.API.Features;
    using ServerHandlers = Exiled.Events.Handlers.Server;
    using WarheadHandlers = Exiled.Events.Handlers.Warhead;

    public class SurfaceTension : Plugin<Config>
    {
        private EventHandlers _eventHandlers;

        public override void OnEnabled()
        {
            _eventHandlers = new EventHandlers(Config);

            WarheadHandlers.Detonated += _eventHandlers.OnWarheadDetonation;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            WarheadHandlers.Detonated -= _eventHandlers.OnWarheadDetonation;
            base.OnDisabled();
        }
    }
}