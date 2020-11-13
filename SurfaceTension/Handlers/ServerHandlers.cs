namespace SurfaceTension.Handlers
{
    using Exiled.Events.EventArgs;
    using MEC;
    using static SurfaceTension;
    
    public class ServerHandlers
    {
        public void OnRoundEnded(RoundEndedEventArgs _)
        {
            Timing.KillCoroutines(Instance.WarheadHandlers.Handle);
        }
    }
}