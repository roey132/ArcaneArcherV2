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
        HandleBorderCollision(collision);
        HandleEnemyCollision(collision);
    }
    private void HandleBorderCollision(Collider2D collision)
    {
        if (!collision.CompareTag("Border")) return;
        _projectile.ReleaseSelfToPool();
    }
    private void HandleEnemyCollision(Collider2D collision)
    {
        if (!collision.CompareTag("EnemyCollider")) return;
        collision.GetComponent<EnemyCollisionManager>().HitEnemy(_projectile.Data.DamageMultiplier);
        _penetrationCount--;
        if (_penetrationCount <= 0)
        {
            _projectile.ReleaseSelfToPool();
        }
    }
}
