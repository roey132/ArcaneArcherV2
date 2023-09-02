using UnityEngine;

public class Projectile : Poolable
{
    [SerializeField] public ProjectileData Data;
    [SerializeField] private LayerMask _hitLayerMask;
    [SerializeField] private Rigidbody2D _rb;

    // TODO : Delete temp timer
    private float _timer;

    private void Awake()
    {
        _timer = 2f;
        _poolName = Data.ProjetileName;
    }
    private void OnEnable()
    {
        _timer = 2f;
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            ReleaseSelfToPool();
        }
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
        _rb.velocity = direction.normalized * Data.Speed;
    }
}