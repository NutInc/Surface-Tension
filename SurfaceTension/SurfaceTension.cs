namespace SurfaceTension
{
    using System;
    using Exiled.API.Features;
    using ServerHandlers = Exiled.Events.Handlers.Server;
    using WarheadHandlers = Exiled.Events.Handlers.Warhead;

    public class SurfaceTension : Plugin<Config>
    {

        public override string Author { get; } = "BuildBoy12";
        public override string Name { get; } = "Surface Tension";
        public override string Prefix { get; } = "Surface_Tension";
        public override Version Version { get; } = new Version(1, 3, 5);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 29, 0);

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