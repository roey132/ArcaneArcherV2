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
        _stats.ClearStats();
        foreach ((Stat stat, float value) in _baseStats.BasePlayerStats)
        {
            _stats.CreateStat(stat, value);
        }
    }

    private void InitHealth()
    {
        _healthManager.InitHealth(_baseStats.StartingHealth);
    }
}