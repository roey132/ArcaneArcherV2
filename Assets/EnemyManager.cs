using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyData _data;
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private HealthManager _healthManager;

    public virtual void InitEnemy() 
    {
        _healthManager.InitHealth(_data.StartingHealth);

        _statsManager.ClearStats();
        foreach ((Stat stat, float value) in _data.BaseStats)
        {
            _statsManager.CreateStat(stat, value);
        }
    }
    private void Awake()
    {
        InitEnemy();
    }
}
