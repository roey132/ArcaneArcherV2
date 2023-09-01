using UnityEngine;

public class Projectile : Poolable
{
    [SerializeField] private ProjectileData _data;
    [SerializeField] private LayerMask _hitLayerMask;
    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
        _poolName = _data.name;
    }

    public virtual void InitProjectile(Vector2 projectileDirection, Vector2 _startPosition)
    {
        transform.position = _startPosition;
        SetArrowRotation(projectileDirection);
        SetArrowSpeed(projectileDirection);
    }

    private void SetArrowRotation(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void SetArrowSpeed(Vector2 direction)
    {
        _rb.velocity = direction.normalized * _data.Speed;
    }
}