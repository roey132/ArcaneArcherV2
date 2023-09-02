using System;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [Header("Arrows")]
    [SerializeField] private ProjectileData _baseProjectileData;
    [SerializeField] private ProjectileData _currProjectileData;

    [Header("References")]
    [SerializeField] private Transform _player;
    [SerializeField] private StatsManager _playerStats;

    [Header("Variables")]
    [SerializeField] private float _minSpreadAngle;
    [SerializeField] private float _maxSpreadAngle;

    private float _nextFireTime;


    public static event Action OnArrowShoot;


    private void ShootArrows()
    {
        Vector2 mouseDirection = GetMouseDirection();
        int arrowCount = (int)_playerStats.GetStatValue(Stat.NumberOfArrows);
        if (arrowCount > 1)
        {
            ShootMultipleArrows(arrowCount, mouseDirection);
        }
        else
        {
            ShootOneArrow(mouseDirection);
        }
        OnArrowShoot?.Invoke();
        return;
    }

    private void ShootOneArrow(Vector2 direction)
    {
        GameObject currArrow = ObjectPoolsManager.Instance.PullObject(_currProjectileData.ProjetileName);
        Projectile currArrowProjectile = currArrow.GetComponent<Projectile>();

        currArrowProjectile.InitProjectile(direction, BowPosition.Instance.transform.position);
    }

    private void ShootMultipleArrows(int arrowCount, Vector2 direction)
    {
        // get max spread angle on 15 arrows or more
        float spreadAngle = Mathf.Lerp(_minSpreadAngle, _maxSpreadAngle, (arrowCount - 1) / 15f);

        float angleStep = spreadAngle / (arrowCount - 1);
        float startAngle = -spreadAngle / 2f;

        for (int i = 0; i < arrowCount; i++)
        {
            float currAngle = (startAngle + angleStep * i);
            Vector2 currDirection = (Quaternion.Euler(0, 0, currAngle) * direction).normalized;
            ShootOneArrow(currDirection);
        }
    }

    private Vector2 GetMouseDirection()
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
        if (_nextFireTime > Time.time) return;
        _nextFireTime = Time.time + 1 / _playerStats.GetStatValue(Stat.AttackSpeed);
        ShootArrows();
    }
}
