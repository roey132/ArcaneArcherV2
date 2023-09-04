using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyMovementState : ObjectState
{
    [Header("Managers")]
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private StatsManager _stats;

    [Header("States")]
    [SerializeField] private ObjectState _attackState;

    [Header("EnemyTransform")]
    [SerializeField] private Transform _enemyTransform;
    public override void OnStateEnd()
    {
    }

    public override void OnStateStart()
    {
    }

    public override ObjectState StateBehaviour()
    {
        HandleMovement();
        if (_enemyManager.CanAttack()) return _attackState; 
        return null;
    }

    private void HandleMovement()
    {
        float movementSpeed = _stats.GetStatValue(Stat.MovementSpeed);
        Vector2 targetPosition = PlayerManager.Instance.transform.position;
        Vector2 currPosition = _enemyTransform.position;

        _enemyTransform.position = Vector2.MoveTowards(currPosition, targetPosition, movementSpeed * Time.deltaTime);
    }
}
