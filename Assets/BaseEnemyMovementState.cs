using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyMovementState : ObjectState
{
    [Header("Stats")]
    [SerializeField] private StatsManager _stats;

    [Header("States")]
    [SerializeField] private ObjectState _attackState;

    [Header("EnemyTransform")]
    [SerializeField] private Transform _enemyTransform;
    public override void OnStateEnd()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateStart()
    {
        throw new System.NotImplementedException();
    }

    public override ObjectState StateBehaviour()
    {
        HandleMovement();
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
