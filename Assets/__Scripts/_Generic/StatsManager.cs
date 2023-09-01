using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using UnityEngine;
public class StatsManager : SerializedMonoBehaviour
{
    public static StatsManager Instance;

    [OdinSerialize] 
    private Dictionary<Stat, float> _stats = new Dictionary<Stat,float>();
    public static event Action<Stat> OnStatChange;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CreateStat(Stat stat, float value)
    {
        _stats[stat] = value;
    }

    public float GetStatValue(Stat stat)
    {
        return _stats[stat];
    }
    public void AddStatValue(Stat stat, float value)
    {
        _stats[stat] += value;
        OnStatChange?.Invoke(stat);
    }
    public void ReduceStatValue(Stat stat, float value)
    {
        _stats[stat] -= value;
        OnStatChange?.Invoke(stat);
    }
}

public enum Stat
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
