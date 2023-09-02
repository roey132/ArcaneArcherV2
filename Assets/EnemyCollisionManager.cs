using UnityEngine;

public class EnemyCollisionManager : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private HealthManager _healthManager;
    
    public void HitEnemy(float damage)
    {
        _healthManager.ReduceHealth(damage);
    }
}
