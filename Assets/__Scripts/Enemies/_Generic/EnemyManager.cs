using UnityEngine;

public class EnemyManager : Poolable
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

    private void OnDeath()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        InitEnemy();
        _healthManager.OnDeath += OnDeath;
    }
    private void OnDisable()
    {
        _healthManager.OnDeath -= OnDeath;
    }

    private void Awake()
    {
        _poolName = _data.Name;
        InitEnemy();
    }
}
