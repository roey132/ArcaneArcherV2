using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private StatsManager _stats;
    [SerializeField] private PlayerBaseStats _baseStats;
    [SerializeField] private HealthManager _healthManager;

    private void Awake()
    {
        InitStats();
        InitHealth();
    }

    private void InitStats()
    {
        _stats.CreateStat(Stat.AttackDamage, _baseStats.AttackDamage);
        _stats.CreateStat(Stat.MagicDamage, _baseStats.MagicDamage);
        _stats.CreateStat(Stat.PhysicalDamageMultiplierPct, _baseStats.PhysicalDamageMultiplierPct);
        _stats.CreateStat(Stat.MagicalDamageMultiplierPct, _baseStats.MagicalDamageMultiplierPct);
        _stats.CreateStat(Stat.AttackSpeed, _baseStats.AttackSpeed);
        _stats.CreateStat(Stat.CastCooldownReductionPct, _baseStats.CastCooldownReductionPct);
        _stats.CreateStat(Stat.MovementSpeed, _baseStats.MovementSpeed);
        _stats.CreateStat(Stat.CriticalRatePct, _baseStats.CriticalRatePct);
        _stats.CreateStat(Stat.CriticalDamageMultiplierPct, _baseStats.CriticalDamageMultiplierPct);
        _stats.CreateStat(Stat.CriticalDamageMultiplierPct, _baseStats.CriticalDamageMultiplierPct);
        _stats.CreateStat(Stat.NumberOfArrows, _baseStats.NumberOfArrows);
    }

    private void InitHealth()
    {
        _healthManager.InitHealth(_baseStats.StartingHealth);
    }
}
