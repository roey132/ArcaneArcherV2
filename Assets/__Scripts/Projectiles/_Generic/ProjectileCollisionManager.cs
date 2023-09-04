using System;
using UnityEngine;

public class ProjectileCollisionManager : MonoBehaviour
{
    public event Action OnEnemyHit;
    [SerializeField] private Projectile _projectile;

    private int _penetrationCount;

    private void OnEnable()
    {
        _penetrationCount = _projectile.Data.PenetrationCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyCollider"))
        {
            collision.GetComponent<EnemyCollisionManager>().HitEnemy(_projectile.Data.DamageMultiplier);
            _penetrationCount--;
        }
        if (_penetrationCount <= 0)
        {
            _projectile.ReleaseSelfToPool();
        }
    }
}
