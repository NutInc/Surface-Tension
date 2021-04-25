namespace SurfaceTension
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using System.Collections.Generic;

    public class EventHandlers
    {
        public EventHandlers(Config config) => _config = config;
        private readonly Config _config;

        private float DamageCalculation(bool isPercent, int playerMaxHp, int damage)
        {
            return isPercent ? playerMaxHp / 100 * damage : damage;
        }

        private IEnumerator<float> DamageOverTime()
        {
            if (_config.DelayTime > 0)
                yield return Timing.WaitForSeconds(_config.DelayTime);
                

            while (Warhead.IsDetonated)
            { 
                yield return Timing.WaitForSeconds(_config.DamageInterval > 0 ? _config.DamageInterval : 0.1f);
                foreach (Player ply in Player.List)
                {
                    if (!ply.IsAlive)
                        continue;

                    ply.Hurt(DamageCalculation(_config.DamageAsPercentage, ply.MaxHealth, _config.DamageAmount));
                    ply.ShowHint(duration: _config.DamageInterval, message: $"{_config.DamageMessage}");
                }
            }
        }

        public void OnWarheadDetonation()
        {
            Timing.RunCoroutine(DamageOverTime());
            Log.Info($"Warhead detonated. Surface Tension starting in {_config.DelayTime} seconds!");
        }

    }
}