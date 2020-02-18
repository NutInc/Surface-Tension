using System;
using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;
using MEC;

namespace Surface_Tension
{
    public class SurfaceTension : EXILED.Plugin
    {
        public EventHandlers EventHandlers;

        public bool DoDelay;
        public bool IsPercentage;
        public int Damage;
        public float DelayTime;
        public float TimeBetweenDamage;

        public override void OnEnable()
        {
            try
            {
                Log.Info("loaded.");
                ReloadConfig();
                Log.Info("Configs loaded.");
                
                Log.Debug("Initializing event handlers..");
                //Set instance variable to a new instance, this should be nulled again in OnDisable
                EventHandlers = new EventHandlers(this);
                //Hook the events you will be using in the plugin. You should hook all events you will be using here, all events should be unhooked in OnDisabled 
                Events.RoundStartEvent += EventHandlers.OnRoundStart;
                Events.RoundEndEvent += EventHandlers.OnRoundEnd;
                Events.WarheadDetonationEvent += EventHandlers.OnWarheadDetonation;
                Log.Info($"Surface Tension has loaded.");
            }
            catch (Exception e)
            {
                Log.Error($"OnEnable error occured: {e}");
            }
        }

        public override void OnDisable()
        {
            foreach (CoroutineHandle handle in EventHandlers.Coroutines)
                Timing.KillCoroutines(handle);
            
            Events.RoundStartEvent -= EventHandlers.OnRoundStart;
            Events.RoundEndEvent -= EventHandlers.OnRoundEnd;
            Events.WarheadDetonationEvent -= EventHandlers.OnWarheadDetonation;
            EventHandlers = null;
        }

        public override void OnReload()
        {
            //This is only fired when you use the EXILED reload command, the reload command will call OnDisable, OnReload, reload the plugin, then OnEnable in that order. There is no GAC bypass, so if you are updating a plugin, it must have a unique assembly name, and you need to remove the old version from the plugins folder
        }

        public override string getName { get; } = "Surface Tension";
        
        public void ReloadConfig()
        {
            Log.Info($"Config Path: {Config.Path}");
            DoDelay = Config.GetBool("st_enable_delay", true);
            IsPercentage = Config.GetBool("st_is_damage_type_percent", true);
            Damage = Config.GetInt("st_damage", 1);
            DelayTime = Config.GetFloat("st_delay_time", 90f);
            TimeBetweenDamage = Config.GetFloat("st_time_between_dmg", 1f);
        }
        
        public IEnumerator<float> RaiseTheTension()
        {
            if (DoDelay)
                yield return Timing.WaitForSeconds(DelayTime);

            for (;;)
            {
                yield return Timing.WaitForSeconds(TimeBetweenDamage);
                
                foreach (ReferenceHub hub in Player.GetHubs())
                {
                    int maxHp = hub.playerStats.maxHP;
                    var postNukeDamage = Methods.DamageCalculation(IsPercentage, maxHp, Damage);
                    
                    if (hub.characterClassManager.CurClass != RoleType.Spectator)
                        hub.playerStats.HurtPlayer(new PlayerStats.HitInfo(postNukeDamage, "POST-DETONATION-DAMAGE", DamageTypes.Wall, 0), hub.gameObject);
                }
            }
        }
    }
}