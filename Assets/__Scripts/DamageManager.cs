using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float CalculatePhysicalDamage(float multiplier)
    {
        float damage =  StatsManager.PlayerStats.GetStatValue(Stat.AttackDamage);
        float baseMultiplier = StatsManager.PlayerStats.GetStatValue(Stat.PhysicalDamageMultiplierPct);

        float calculatedDamage = damage * multiplier * baseMultiplier;

        float critRate = StatsManager.PlayerStats.GetStatValue(Stat.CriticalRatePct);
        float critRandom = Random.Range(0f,1f);
        float critMultiplier = StatsManager.PlayerStats.GetStatValue(Stat.CriticalDamageMultiplierPct);

        if (critRate > critRandom) 
        {
            print($"calculated damage is :{calculatedDamage}");
            return calculatedDamage;
        }
        print($"critical calculated damage is :{critMultiplier * calculatedDamage}" );
        return calculatedDamage * critMultiplier;
    }
    public void CalculateMagicalDamage(float multiplier)
    {

    }
}
