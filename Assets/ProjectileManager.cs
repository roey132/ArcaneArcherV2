using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ProjectileData _baseProjectileData;
    [SerializeField] private ProjectileData _currProjectileData;

    [SerializeField] private Transform _player;

    public static event Action OnArrowShoot;


    // temp timer
    private float _timer = 0.1f;

    private void ShootArrows()
    {
        ShootOneArrow();
        OnArrowShoot?.Invoke();
    }

    private void ShootOneArrow()
    {
        GameObject currArrow = ObjectPoolsManager.Instance.PullObject(_currProjectileData.ProjetileName);
        Projectile currArrowProjectile = currArrow.GetComponent<Projectile>();

        currArrowProjectile.InitProjectile(GetArrowDirection(), BowPosition.Instance.transform.position);
    }

    private Vector2 GetArrowDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mousePosition - (Vector2)_player.position).normalized;
    }


    private void Awake()
    {
        _currProjectileData = _baseProjectileData;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            ShootArrows();
            _timer = 0.1f;
        }
    }
}
