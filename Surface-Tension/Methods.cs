using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;
using MEC;

namespace Surface_Tension
{
    public class Methods
    {
        private readonly SurfaceTension plugin;
        public Methods(SurfaceTension plugin) => this.plugin = plugin;
        
        public static float DamageCalculation(bool isPercent, int playerMaxHp, int damage)
        {
            if (isPercent)
                return (playerMaxHp / 100) * damage;
            return damage;
        }
        
        public IEnumerator<float> RaiseTheTension()
        {
            Log.Info("Raising the tension");

            if (plugin.DoDelay)
            {
                yield return Timing.WaitForSeconds(plugin.DelayTime);
            }
            
            Log.Info("Delay finished, starting to damage players.");
            
            for (;;)
            {
                yield return Timing.WaitForSeconds(plugin.TimeBetweenDamage);

                foreach (ReferenceHub hub in Player.GetHubs())
                {
                    if (hub.characterClassManager.CurClass == RoleType.Spectator) 
                        continue;
                    
                    int maxHp = hub.playerStats.maxHP;
                    var postNukeDamage = DamageCalculation(plugin.IsPercentage, maxHp, plugin.Damage);
                    
                    hub.playerStats.HurtPlayer(new PlayerStats.HitInfo(postNukeDamage, "POST-DETONATION-DAMAGE", DamageTypes.Wall, 0), hub.gameObject);
                }
            }
        }
    }
}