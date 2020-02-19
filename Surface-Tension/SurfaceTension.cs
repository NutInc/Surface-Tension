using System;
using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;
using MEC;

namespace Surface_Tension
{
    public class SurfaceTension : EXILED.Plugin
    {
        public EventHandlers EventHandlers { get; private set; }
        public Methods Methods { get; private set; }

        public bool Enabled;
        public bool DoDelay;
        public bool IsPercentage;
        public int Damage;
        public float DelayTime;
        public float TimeBetweenDamage;

        public override void OnEnable()
        {
            ReloadConfig();
            Log.Info("Surface Tension Configs loaded.");
                
                if (!Enabled)
                    return;
                
            EventHandlers = new EventHandlers(this);
            Methods = new Methods(this);
                
            Events.RoundStartEvent += EventHandlers.OnRoundStart;
            Events.RoundEndEvent += EventHandlers.OnRoundEnd;
            Events.WarheadDetonationEvent += EventHandlers.OnWarheadDetonation;
            Log.Info($"Surface Tension has loaded.");
        }

        public override void OnDisable()
        {
            foreach (CoroutineHandle handle in EventHandlers.Coroutines)
                Timing.KillCoroutines(handle);
            
            Events.RoundStartEvent -= EventHandlers.OnRoundStart;
            Events.RoundEndEvent -= EventHandlers.OnRoundEnd;
            Events.WarheadDetonationEvent -= EventHandlers.OnWarheadDetonation;
            EventHandlers = null;
            Methods = null;
        }

        public override void OnReload()
        {
            
        }

        public override string getName { get; } = "Surface Tension";

        private void ReloadConfig()
        {
            Log.Info($"Config Path: {Config.Path}");
            Enabled = Config.GetBool("st_enable, true");
            DoDelay = Config.GetBool("st_enable_delay", true);
            IsPercentage = Config.GetBool("st_is_damage_type_percent", true);
            Damage = Config.GetInt("st_damage", 1);
            DelayTime = Config.GetFloat("st_delay_time", 90f);
            TimeBetweenDamage = Config.GetFloat("st_time_between_dmg", 1f);
        }
    }
}