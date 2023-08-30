using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    private Dictionary<PlayerStat, float> _stats;
    public static event Action<PlayerStat> OnStatChange;

    [SerializeField] private PlayerBaseStats _baseStats;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        InitStats();
    }

    public float GetStatValue(PlayerStat stat)
    {
        return _stats[stat];
    }
    public void AddStatValue(PlayerStat stat, float value)
    {
        _stats[stat] += value;
        OnStatChange?.Invoke(stat);
    }
    public void ReduceStatValue(PlayerStat stat, float value)
    {
        _stats[stat] -= value;
        OnStatChange?.Invoke(stat);
    }

    private void InitStats()
    {
        _stats[PlayerStat.AttackDamage] = _baseStats.AttackDamage;
        _stats[PlayerStat.MagicDamage] = _baseStats.MagicDamage;
        _stats[PlayerStat.PhysicalDamageMultiplierPct] = _baseStats.PhysicalDamageMultiplierPct;
        _stats[PlayerStat.MagicalDamageMultiplierPct] = _baseStats.MagicalDamageMultiplierPct;
        _stats[PlayerStat.AttackSpeed] = _baseStats.AttackSpeed;
        _stats[PlayerStat.CastCooldownReductionPct] = _baseStats.CastCooldownReductionPct;
        _stats[PlayerStat.MovementSpeed] = _baseStats.MovementSpeed;
        _stats[PlayerStat.CriticalRatePct] = _baseStats.CriticalRatePct;
        _stats[PlayerStat.CriticalDamageMultiplierPct] = _baseStats.CriticalDamageMultiplierPct;
        _stats[PlayerStat.NumberOfArrows] = _baseStats.NumberOfArrows;
    }
}

public enum PlayerStat
{
    AttackDamage, // number
    MagicDamage, // number
    PhysicalDamageMultiplierPct, // percantage
    MagicalDamageMultiplierPct, // percantage
    AttackSpeed, // number
    CastCooldownReductionPct, // percantage
    MovementSpeed, // number
    CriticalRatePct, // percantage 
    CriticalDamageMultiplierPct, // percentage
    NumberOfArrows // number
}
