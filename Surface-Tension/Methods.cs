namespace Surface_Tension
{
    public static class Methods
    {
        public static float DamageCalculation(bool isPercent, int playerMaxHp, int damage)
        {
            if (isPercent)
                return (playerMaxHp / 100) * damage;
            return damage;
        }
    }
}