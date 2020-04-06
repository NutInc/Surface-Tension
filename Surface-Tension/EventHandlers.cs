using System.Collections.Generic;
using EXILED;
using MEC;

namespace Surface_Tension
{ 
    public class EventHandlers
    {
        private readonly SurfaceTension plugin;
        public EventHandlers(SurfaceTension plugin)
        {
            this.plugin = plugin;
        }

        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public void OnRoundStart()
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
        }

        public void OnWarheadDetonation()
        {
            Log.Info("Warhead has been detonated.");
            Coroutines.Add(Timing.RunCoroutine(plugin.Methods.RaiseTheTension()));
            Log.Info("Tension Raised.");
        } 

            public void OnRoundEnd()
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
        }
    }
}