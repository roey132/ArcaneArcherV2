using Sirenix.OdinInspector;
using UnityEngine;

public class Projectile : Poolable
{
    [Required]
    [SerializeField] public ProjectileData Data;
    [SerializeField] private LayerMask _hitLayerMask;
    [Required]
    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
        _poolName = Data.ProjetileName;
    }
    private void OnEnable()
    {
    }
    private void Update()
    {

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