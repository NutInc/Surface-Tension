using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;
using EXILED.Patches;
using MEC;

namespace Surface_Tension
{ 
    public class EventHandlers
    {
        public SurfaceTension plugin; 
        public EventHandlers(SurfaceTension plugin) => this.plugin = plugin;
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public void OnRoundStart()
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
        }
        
        public void OnWarheadDetonation()
        {
            Coroutines.Add(Timing.RunCoroutine(plugin.RaiseTheTension()));
        }

        public void OnRoundEnd()
        {
            foreach (CoroutineHandle handle in Coroutines)
                Timing.KillCoroutines(handle);
            //foreach (ReferenceHub hub in Player.GetHubs())
        }
    }
}