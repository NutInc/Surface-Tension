namespace SurfaceTension.Handlers
{
    using Exiled.API.Features;
    using MEC;
    using System.Collections.Generic;
    using static SurfaceTension;

    public class WarheadHandlers
    {
        internal CoroutineHandle Handle;

        public void OnWarheadDetonation()
        {
            Handle = Timing.RunCoroutine(DamageOverTime());
        }

        private IEnumerator<float> DamageOverTime()
        {
            if (Instance.Config.DelayTime > 0)
                yield return Timing.WaitForSeconds(Instance.Config.DelayTime);
            
            while (true)
            {
                yield return Timing.WaitForSeconds(Instance.Config.DamageInterval > 0 ? Instance.Config.DamageInterval : 0.1f);
                foreach (Player ply in Player.List)
                {
                    if (ply.Role == RoleType.Spectator)
                        continue;

                    ply.Health -= DamageCalculation(Instance.Config.DamageAsPercentage, ply.MaxHealth,
                        Instance.Config.DamageAmount);
                    if (ply.Health <= 0)
                        ply.Kill(DamageTypes.Decont);
                }
            }
        }
        
        private float DamageCalculation(bool isPercent, int playerMaxHp, int damage)
        {
            if (isPercent)
                return (playerMaxHp / 100) * damage;
            return damage;
        }
    }
}