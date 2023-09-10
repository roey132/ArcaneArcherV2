using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyManager : Poolable
{
    [Required]
    [SerializeField] private EnemyData _data;
    [Required]
    [SerializeField] private StatsManager _statsManager;
    [Required]
    [SerializeField] private HealthManager _healthManager;

    public float NextAttackTime { get; private set; }

    private void Awake()
    {
        _poolName = _data.Name;
        InitEnemy();
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

    public virtual void InitEnemy() 
    {
        _healthManager.InitHealth(_data.StartingHealth);
        NextAttackTime = 0;
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
    public void AttackPerformed()
    {
        NextAttackTime = Time.time + _statsManager.GetStatValue(Stat.AttackCooldown);
    }
    public bool CanAttack()
    {
        return NextAttackTime < Time.time;
    }

    public EnemyData GetEnemyData()
    {
        return _data;
    }
}
